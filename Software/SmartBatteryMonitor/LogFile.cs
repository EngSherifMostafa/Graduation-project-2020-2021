using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using static System.IO.Directory;

namespace Smart_Battery_Monitor
{
    internal class LogFile
    {
        private readonly StreamWriter _logFile;
        private readonly List<ReportInfo> _reportList;
        
        private static string PrintLine()
        {
            var line = string.Empty;
            for (var i = 0; i < 370; i++)
                line += "-";
            return line;
        }

        public LogFile()
        {
            //create log files in logs folder
            CreateDirectory(".\\Logs");

            _logFile = new StreamWriter(
                $"{".\\Logs\\" + "Log - " + DateTime.Now.ToString("dd-MM-yyyy - HH.mm.ss tt") + ".txt"}", true);

            _reportList = new List<ReportInfo>();
        }

        public void GenerateReport(
            string fromYear, string fromMonth, string fromDay,
            string fromHour, string fromMin, string fromSec, string fromTt,
            string toYear, string toMonth, string toDay,
            string toHour, string toMin, string toSec, string toTt)
        {
            fromHour = Convert12To24HourSystem(Convert.ToInt32(fromHour), fromTt);
            toHour = Convert12To24HourSystem(Convert.ToInt32(toHour), toTt);

            //build dates that user want to report from and to
            var startDate = @$"{fromYear}-{fromMonth}-{fromDay} {fromHour}:{fromMin}:{fromSec}";

            var endDate = @$"{toYear}-{toMonth}-{toDay} {toHour}:{toMin}:{toSec}";

            var errMsg = DataBaseManagement.SelectStm(_reportList, startDate, endDate);
            
            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg);
                return;
            }

            try
            {
                _logFile.Write($"This report was created @: {DateTime.Now:dd-MM-yyyy    hh:mm:ss tt}\n" +
                               $"From Date: {fromDay}-{fromMonth}-{fromYear}\t{fromHour}:{fromMin}:{fromSec} {fromTt}\n" +
                               $"To Date  : {toDay}-{toMonth}-{toYear}\t{toHour}:{toMin}:{toSec} {toTt}\n" +
                               $"{PrintLine()}\n");

                _logFile.Write(
                    $"\nAverage Battery Usage Up/Down 1%       : {Math.Ceiling(_reportList.Average(batteryPerSec => batteryPerSec.BatteryUsagePerSecond))} Second" +
                    "\nAverage Processor Usage                : " +
                    $"{Math.Ceiling(_reportList.Average(cpuUsage => cpuUsage.CpuPerformance))}" +
                    "\nAverage RAM Usage                      : " +
                    $"{Math.Ceiling(_reportList.Average(ramUsage => ramUsage.RamPerformance))}" +
                    "\nAverage Hard Disk Usage                : " +
                    $"{Math.Ceiling(_reportList.Average(hdUsage => hdUsage.HdPerformance))}" +
                    "\n# of Charger Online                    : " +
                    $"{_reportList.Count(onlineCharger => Strings.Trim(onlineCharger.ChargerStatus) == "Online")}" +
                    "\n# of Charger Offline                   : " +
                    $"{_reportList.Count(onlineCharger => onlineCharger.ChargerStatus == "Offline")}" +
                    "\n# of Records                           : " +
                    $"{_reportList.Count}" +
                    $"\n{PrintLine()}\n\n"
                );

                _logFile.Write(
                    "Start Date                     \t" +
                    "Battery Percent at Start Date  \t\t" +
                    "End Date                       \t\t" +
                    "Battery Percent at End Date    \t\t" +
                    "Diff Date in Seconds           \t" +
                    "Diff Battery                   \t" +
                    "Battery Consumption per Second \t\t" +
                    "Processor Utilization          \t" +
                    "RAM Utilization                \t" +
                    "Hard Disk Utilization          \t" +
                    "Charger Status                 \n");

                foreach (var item in _reportList)
                {
                    _logFile.Write($"\n{Convert.ToDateTime(item.CurrentDate):dd-MM-yyyy hh:mm:ss tt}");
                    _logFile.Write($"\t\t{item.BatteryPercent}");

                    _logFile.Write($"\t\t\t\t\t{Convert.ToDateTime(item.LagDate):dd-MM-yyyy hh:mm:ss tt}");
                    _logFile.Write($"\t\t\t{item.LagBatteryPercent}");

                    _logFile.Write($"\t\t\t\t\t{item.DateTimeDiff}");
                    _logFile.Write($"\t\t\t\t{item.BatteryPercentDiff}");
                    _logFile.Write($"\t\t\t\t{item.BatteryUsagePerSecond}");

                    _logFile.Write($"\t\t\t\t\t{item.CpuPerformance}");
                    _logFile.Write($"\t\t\t\t{item.RamPerformance}");
                    _logFile.Write($"\t\t\t\t{item.HdPerformance}");
                    _logFile.Write($"\t\t\t\t{item.ChargerStatus}");
                }

                MessageBox.Show(@"Log File was created successfully", @"Create Log File");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, @"btnReport_Click");
            }
            finally
            {
                _logFile.Close();
            }
        }

        public static KeyValuePair<string, string> Convert24To12HourSystem(int hoursIn24) =>
            hoursIn24 switch
            {
                0 => new KeyValuePair<string, string>(@"AM", "12"),
                1 => new KeyValuePair<string, string>(@"AM", "01"),
                2 => new KeyValuePair<string, string>(@"AM", "02"),
                3 => new KeyValuePair<string, string>(@"AM", "03"),
                4 => new KeyValuePair<string, string>(@"AM", "04"),
                5 => new KeyValuePair<string, string>(@"AM", "05"),
                6 => new KeyValuePair<string, string>(@"AM", "06"),
                7 => new KeyValuePair<string, string>(@"AM", "07"),
                8 => new KeyValuePair<string, string>(@"AM", "08"),
                9 => new KeyValuePair<string, string>(@"AM", "09"),
                10 => new KeyValuePair<string, string>(@"AM", "10"),
                11 => new KeyValuePair<string, string>(@"AM", "11"),

                12 => new KeyValuePair<string, string>(@"PM", "12"),
                13 => new KeyValuePair<string, string>(@"PM", "01"),
                14 => new KeyValuePair<string, string>(@"PM", "02"),
                15 => new KeyValuePair<string, string>(@"PM", "03"),
                16 => new KeyValuePair<string, string>(@"PM", "04"),
                17 => new KeyValuePair<string, string>(@"PM", "05"),
                18 => new KeyValuePair<string, string>(@"PM", "06"),
                19 => new KeyValuePair<string, string>(@"PM", "07"),
                20 => new KeyValuePair<string, string>(@"PM", "08"),
                21 => new KeyValuePair<string, string>(@"PM", "09"),
                22 => new KeyValuePair<string, string>(@"PM", "10"),
                23 => new KeyValuePair<string, string>(@"PM", "11"),
                _ => new KeyValuePair<string, string>(string.Empty, string.Empty)
            };

        public static string Convert12To24HourSystem(int hoursIn12, string tt) =>
            tt switch
            {
                @"AM" when hoursIn12 == 12 => "00",
                @"AM" when hoursIn12 == 1 => "01",
                @"AM" when hoursIn12 == 2 => "02",
                @"AM" when hoursIn12 == 3 => "03",
                @"AM" when hoursIn12 == 4 => "04",
                @"AM" when hoursIn12 == 5 => "05",
                @"AM" when hoursIn12 == 6 => "06",
                @"AM" when hoursIn12 == 7 => "07",
                @"AM" when hoursIn12 == 8 => "08",
                @"AM" when hoursIn12 == 9 => "09",
                @"AM" when hoursIn12 == 10 => "10",
                @"AM" when hoursIn12 == 11 => "11",

                @"PM" when hoursIn12 == 12 => "12",
                @"PM" when hoursIn12 == 1 => "13",
                @"PM" when hoursIn12 == 2 => "14",
                @"PM" when hoursIn12 == 3 => "15",
                @"PM" when hoursIn12 == 4 => "16",
                @"PM" when hoursIn12 == 5 => "17",
                @"PM" when hoursIn12 == 6 => "18",
                @"PM" when hoursIn12 == 7 => "19",
                @"PM" when hoursIn12 == 8 => "20",
                @"PM" when hoursIn12 == 9 => "21",
                @"PM" when hoursIn12 == 10 => "22",
                @"PM" when hoursIn12 == 11 => "23",
                _ => string.Empty
            };
    }
}
