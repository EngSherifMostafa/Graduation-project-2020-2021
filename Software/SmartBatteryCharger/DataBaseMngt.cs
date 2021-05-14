using System;
using System.Data;
using System.Data.SqlClient;

namespace SmartBatteryCharger
{
    class DataBaseMngt
    {
        public static string SelectStm(ref DataTable retData) =>
            ExecSqlCmd(
                @"Select colIndex as [Index], [colDate] as [Date], [colTime] as [Time], [colBatteryStatus] as [Battery Status], 
                [colChargerStatus] as [Charger Status] from [tblLogFile]", ref retData);

        public static string InsertStm(int batteryPercentage, int chargerStatus, ref DataTable retData) =>
            ExecSqlCmd(
                @$"insert into tblLogFile values ((SELECT CAST(GETDATE() AS Date)) ,(SELECT CONVERT(TIME(0), GETDATE())), 
                {batteryPercentage}, UPPER('{chargerStatus}'))", ref retData);

        public static string DeleteStm(int recIndex, ref DataTable retData) =>
            ExecSqlCmd($"Delete from tblLogFile where colIndex = {recIndex}",ref retData);

        private static string ExecSqlCmd(string sqlStm,ref DataTable retData)
        {
            //clear data table to refill it
            retData.Clear();
            
            //declare connection string
            const string connStr =
                @"Data Source=EngSherif;Initial Catalog=DBTheSmartBatteryCharger;Integrated Security=True";

            try
            {
                //connect to database using string connection
                var conn = new SqlConnection(connStr);

                //open connection
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                //execute sql command
                retData.Load(new SqlCommand(sqlStm, conn).ExecuteReader());

                //close connection
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                return null;
            }

            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}