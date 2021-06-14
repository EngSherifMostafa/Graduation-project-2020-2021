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
                @$"Select colIndex as [Index], 
                        format ([colDate], 'dd MMMM yyyy') as [Date], 
                        (SELECT format (cast ([colTime] as datetime), 'hh:mm:ss tt')) as [Time], 
                        [colBatteryPercent] as [Battery Status], 
                        trim([colChargerStatus]) as [Charger Status],
                        [colCpuPerformance] as [Cpu Utilization],
                        [colRamPerformance] as [Ram Utilization],
                        [colHardDiskPerformance] as [Hard Disk Utilization]
                        from [tblLogFile] {whereStm}");

        public static string InsertStm(int batteryPercentage, string chargerStatus,
            int cpuUtilization, int ramUtilization, int hdUtilization) =>
            ExecuteNonQuery(
                @$"insert into tblLogFile values (
                (format (GETDATE(), 'dd MMMM yyyy')), (format (GETDATE(), 'hh:mm:ss tt')), 
                {batteryPercentage}, '{chargerStatus}',
                {cpuUtilization}, {ramUtilization}, {hdUtilization})");

        public static string DeleteStm(int recIndex) =>
            ExecuteNonQuery($"Delete from tblLogFile where colIndex = {recIndex}");

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
                        Index = (int)reader["Index"],
                        Date = reader["Date"].ToString(),
                        Time = reader["Time"].ToString(),
                        BatteryPercent = (int)reader["Battery Status"],
                        ChargerStatus = reader["Charger Status"].ToString(),
                        CpuUtilization = (int)reader["Cpu Utilization"],
                        RamUtilization = (int)reader["Ram Utilization"],
                        HdUtilization = (int)reader["Hard Disk Utilization"]
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