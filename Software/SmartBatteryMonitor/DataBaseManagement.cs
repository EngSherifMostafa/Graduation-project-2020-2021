using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Smart_Battery_Monitor
{
    internal class DataBaseManagement
    {
        #region initializer

        private static readonly string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        private static readonly SqlConnection Con = new(ConStr);
        private static readonly SqlCommand Cmd = new();

        #endregion

        #region publicMethods

        public static string SelectStm() =>
            ExecuteScalar(@"SELECT COUNT(*) FROM tblLogFile");

        public static string SelectStm(ICollection<RecordInfo> recordsList, string whereStm = null) =>
            ExecuteReader(recordsList,
                @$"SELECT colIndex AS [Index],
                        FORMAT ([colDate], 'dd MMMM yyyy') AS [Date], 
                        (SELECT FORMAT (CAST ([colTime] AS DATETIME), 'hh:mm:ss tt')) AS [Time],
                        [colBatteryPercent] AS [Battery Status],
                        TRIM([colChargerStatus]) AS [Charger Status],
                        [colCpuPerformance] AS [Cpu Utilization],
                        [colRamPerformance] AS [Ram Utilization],
                        [colHardDiskPerformance] AS [Hard Disk Utilization]
                        FROM [tblLogFile] {whereStm}");

        public static string SelectStm(ICollection<ReportInfo> reportList, string startDate, string endDate) =>
            ExecuteReader(reportList,
                $@"SELECT
	                    [vWReport].[colCurrentDate], [vWReport].[colLagDate],
                        (DATEDIFF(SECOND, [vWReport].[colLagDate], [vWReport].[colCurrentDate])) AS [colDateTimeDiff],
	                    [vWReport].[colBatteryPercent], [vWReport].[colLagBatteryPercent],
                        ([vWReport].[colBatteryPercent] - [vWReport].[colLagBatteryPercent]) AS [colBatteryPercentDiff],
                        ABS(ISNULL(
	                    (DATEDIFF(SECOND, [vWReport].[colLagDate], [vWReport].[colCurrentDate])) /
	                    NULLIF(([vWReport].[colBatteryPercent] - [vWReport].[colLagBatteryPercent]), 0), 0))
	                    AS [colBatteryUsagePerSecond],
	                    [vWReport].[colCpuPerformance], [vWReport].[colRamPerformance], [vWReport].[colHardDiskPerformance],
                        [vWReport].[colChargerStatus]
                        FROM vWReport
                        WHERE [vWReport].[colCurrentDate] BETWEEN '{startDate}' AND '{endDate}'
                        ORDER BY [vWReport].[colIndex]");

        public static string InsertStm(int batteryPercentage, string chargerStatus,
            int cpuUtilization, int ramUtilization, int hdUtilization) =>
            ExecuteNonQuery(
                @$"INSERT INTO tblLogFile VALUES (
                (FORMAT (GETDATE(), 'dd MMMM yyyy')), (FORMAT (GETDATE(), 'hh:mm:ss tt')), 
                {batteryPercentage}, '{chargerStatus}',
                {cpuUtilization}, {ramUtilization}, {hdUtilization})");

        public static string DeleteStm(int recIndex) =>
            ExecuteNonQuery($"DELETE FROM tblLogFile WHERE colIndex = {recIndex}");

        #endregion

        #region executionMethods

        private static string ExecuteReader(ICollection<RecordInfo> recordsList, string cmdStm)
        {
            //clear list to refill it
            recordsList.Clear();

            Cmd.CommandText = cmdStm;
            Cmd.Connection = Con;

            try
            {
                Con.Open();
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    recordsList.Add(new RecordInfo
                    {
                        Index = Convert.ToInt32(reader["Index"]),
                        Date = reader["Date"].ToString(),
                        Time = reader["Time"].ToString(),
                        BatteryPercent = Convert.ToInt32(reader["Battery Status"]),
                        ChargerStatus = reader["Charger Status"].ToString(),
                        CpuUtilization = Convert.ToInt32(reader["Cpu Utilization"]),
                        RamUtilization = Convert.ToInt32(reader["Ram Utilization"]),
                        HdUtilization = Convert.ToInt32(reader["Hard Disk Utilization"])
                    });
                }
            }
            catch (Exception e)
            {
                return e.Message + " - RecordInfo";
            }
            finally
            {
                Con.Close();
            }

            return string.Empty;
        }

        private static string ExecuteReader(ICollection<ReportInfo> reportList, string cmdStm)
        {
            Cmd.CommandText = cmdStm;
            Cmd.Connection = Con;

            try
            {
                Con.Open();
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    reportList.Add(new ReportInfo()
                    {
                        CurrentDate = reader["colCurrentDate"].ToString(),
                        LagDate = reader["colLagDate"].ToString(),
                        DateTimeDiff = reader["colDateTimeDiff"].ToString(),
                        BatteryPercent = Convert.ToInt32(reader["colBatteryPercent"]),
                        LagBatteryPercent = Convert.ToInt32(reader["colLagBatteryPercent"]),
                        BatteryPercentDiff = Convert.ToInt32(reader["colBatteryPercentDiff"]),
                        BatteryUsagePerSecond = Convert.ToInt32(reader["colBatteryUsagePerSecond"]),
                        CpuPerformance = Convert.ToInt32(reader["colCpuPerformance"]),
                        RamPerformance = Convert.ToInt32(reader["colRamPerformance"]),
                        HdPerformance = Convert.ToInt32(reader["colHardDiskPerformance"]),
                        ChargerStatus = reader["colChargerStatus"].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                return e.Message + " - ReportInfo";
            }
            finally
            {
                Con.Close();
            }

            return string.Empty;
        }

        private static string ExecuteNonQuery(string cmdStm)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = cmdStm;

            try
            {
                Con.Open();
                Cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return e.Message + " - NonQuery";
            }
            finally
            {
                Con.Close();
            }

            return string.Empty;
        }

        private static string ExecuteScalar(string cmdStm)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = cmdStm;

            try
            {
                Con.Open();
                return Cmd.ExecuteScalar().ToString();
            }
            catch (Exception e)
            {
                return e.Message + " - Scalar";
            }
            finally
            {
                Con.Close();
            }
        }

        #endregion
    }
}