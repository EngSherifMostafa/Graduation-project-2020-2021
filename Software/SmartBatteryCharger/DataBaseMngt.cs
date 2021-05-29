using System;
using System.Data;
using System.Data.SqlClient;

namespace Smart_Battery_Charger
{
    internal class DataBaseMngt
    {
        public static string SelectStm(ref DataTable retData, string whereStm = null) =>
            ExecSqlCmd(
                @$"Select colIndex as [Index], 
                format ([colDate], 'dd MMMM yyyy') as [Date], 
                (SELECT format (cast ([colTime] as datetime), 'hh:mm:ss tt')) as [Time], 
                [colBatteryStatus] as [Battery Status], 
                [colChargerStatus] as [Charger Status] 
                from [tblLogFile] {whereStm}", ref retData);

        /*************************************************************************************************************************/

        public static string InsertStm(ref int batteryPercentage, ref string chargerStatus, ref DataTable retData) =>
            ExecSqlCmd(
                @$"insert into tblLogFile values (
                (format (GETDATE(), 'dd MMMM yyyy')), (format (GETDATE(), 'hh:mm:ss tt')), 
                {batteryPercentage}, '{chargerStatus}')",
                ref retData);

        /*************************************************************************************************************************/

        public static string DeleteStm(int recIndex, ref DataTable retData) =>
            ExecSqlCmd($"Delete from tblLogFile where colIndex = {recIndex}", ref retData);

        /*************************************************************************************************************************/

        private static string ExecSqlCmd(string sqlStm, ref DataTable retData)
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

        /*************************************************************************************************************************/

    }
}