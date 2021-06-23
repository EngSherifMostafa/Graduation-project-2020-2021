using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Smart_Battery_Charger
{
    internal class DataBaseManagement
    {
        #region initializer

        private static readonly string ConStr = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        private static readonly SqlConnection Con = new(ConStr);
        private static readonly SqlCommand Cmd = new();

        #endregion

        #region publicMethods

        public static string SelectStm(List<RecordInfo> recordsList, string whereStm = null) =>
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

        public static string SelectStm(List<ReportInfo> reportList, string startDate, string endDate) =>
            ExecuteReader(reportList,
                @$"SELECT
                            [vWReport].[colCurrentDate], [vWReport].[colLagDate],
                            (DATEDIFF(SECOND,[vWReport].[colLagDate],[vWReport].[colCurrentDate])) AS [colDateTimeDiff],
	                        [tblLogFile].[colBatteryPercent], [vWReport].[colLagBatteryPercent],
                            ([tblLogFile].[colBatteryPercent] - [vWReport].[colLagBatteryPercent]) AS [colBatteryPercentDiff],
	                        [tblLogFile].[colCpuPerformance], [tblLogFile].[colRamPerformance], [tblLogFile].[colHardDiskPerformance],
                            [tblLogFile].[colChargerStatus]
                            FROM vWReport, tblLogFile
                            WHERE [vWReport].[colCurrentDate] BETWEEN '{startDate}' AND '{endDate}'
                            ORDER BY [vWReport].[colCurrentDate], [vWReport].[colLagDate]"
            );

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

        private static string ExecuteReader(List<RecordInfo> recordsList, string cmdStm)
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
                return e.Message;
            }
            finally
            {
                Con.Close();
            }

            return string.Empty;
        }

        private static string ExecuteReader(List<ReportInfo> recordsList, string cmdStm)
        {
            Cmd.CommandText = cmdStm;
            Cmd.Connection = Con;

            try
            {
                Con.Open();
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    recordsList.Add(new ReportInfo()
                    {
                        CurrentDate = reader["colCurrentDate"].ToString(),
                        LagDate = reader["colLagDate"].ToString(),
                        DateTimeDiff = reader["colDateTimeDiff"].ToString(),
                        BatteryPercent = Convert.ToInt32(reader["colBatteryPercent"]),
                        LagBatteryPercent = Convert.ToInt32(reader["colLagBatteryPercent"]),
                        BatteryPercentDiff = Convert.ToInt32(reader["colBatteryPercentDiff"]),
                        CpuPerformance = Convert.ToInt32(reader["colCpuPerformance"]),
                        RamPerformance = Convert.ToInt32(reader["colRamPerformance"]),
                        HdPerformance = Convert.ToInt32(reader["colHardDiskPerformance"]),
                        ChargerStatus = reader["colChargerStatus"].ToString()
                    });
                }
            }
            catch (Exception e)
            {
                return e.Message;
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
                return e.Message;
            }
            finally
            {
                Con.Close();
            }

            return string.Empty;
        }

        private static string ExecuteScalar(string cmdStm, object retObj)
        {
            Cmd.Connection = Con;
            Cmd.CommandText = cmdStm;

            try
            {
                Con.Open();
                retObj = Cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                Con.Close();
            }

            return string.Empty;


            #endregion
        }
    }
}