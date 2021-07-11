namespace Smart_Battery_Monitor
{
    public class RecordInfo
    {
        public int Index { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int BatteryPercent { get; set; }
        public string ChargerStatus { get; set; }
        public int CpuUtilization { get; set; }
        public int RamUtilization { get; set; }
        public int HdUtilization { get; set; }
    }
}