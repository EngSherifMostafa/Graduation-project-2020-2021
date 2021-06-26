namespace Smart_Battery_Monitor
{
    internal record ReportInfo
    {
        public string CurrentDate { get; set; }
        public string LagDate { get; set; }
        public string DateTimeDiff { get; set; }
        public int BatteryPercent { get; set; }
        public int LagBatteryPercent { get; set; }
        public int BatteryPercentDiff { get; set; }
        public int BatteryUsagePerSecond { get; set; }
        public int CpuPerformance { get; set; }
        public int RamPerformance { get; set; }
        public int HdPerformance { get; set; }
        public string ChargerStatus { get; set; }
    }
}