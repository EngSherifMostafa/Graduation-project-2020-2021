using System;
using System.Data;
using System.Data.SqlClient;

namespace SmartBatteryCharger
{
    class DataBaseMngt
    {
        public static string InsertStm(int batteryPercentage, int chargerStatus)
        {
            try
            {
                var insertStatement =
                    @"insert into tblLogFile values((SELECT CAST(GETDATE() AS Date)) ,(SELECT CONVERT(TIME(0), GETDATE()))," +
                    batteryPercentage + "," + chargerStatus + ")";

                return ExecSqlCmd(insertStatement, new DataTable());
            }

            catch (Exception)
            {
                return null;
            }
        }

        public static string ExecSqlCmd(string sqlStm, DataTable dataTbl)
        {
            //declare connection string
            const string connStr =
                @"Data Source=EngSherif;Initial Catalog=DBTheSmartBatteryCharger;Integrated Security=True";

            try
            {
                //connect to database using string connection
                var conn = new SqlConnection(connStr);

                //open connection
                conn.Open();

                //execute sql command
                if (sqlStm != string.Empty)
                    dataTbl.Load(new SqlCommand(sqlStm, conn).ExecuteReader());

                //close connection
                conn.Close();


                return "Statement executed";
            }

            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}