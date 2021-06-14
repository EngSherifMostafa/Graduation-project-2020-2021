using System.Diagnostics;
using System.Windows.Forms;

namespace Smart_Battery_Charger
{
    public record ResourcesMonitor
    {
        #region initializer

        //initialize PowerStatus to provide info about battery and charger
        private readonly PowerStatus _batteryInfo;

        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _ramCounter;
        //private readonly PerformanceCounter _gpuCounter;
        private readonly PerformanceCounter _hdCounter;
        //get total amount of ram in machine
        private readonly ulong _ramTotalSize;

        //constructor
        public ResourcesMonitor()
        {
            //initialize BatteryMonitor to provide streaming battery percentages
            BatteryMonitor = new BatteryMonitor();
            _batteryInfo = SystemInformation.PowerStatus;

            //initialize PerformanceCounter object
            _cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total", true);
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            //_gpuCounter = new PerformanceCounter("GPU Engine", "Utilization Percentage", "*", true);
            _hdCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total", true);
            //1,000,000 = 1000 * 1000 ( Byte => M.Byte )
            _ramTotalSize = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (ulong)1e6;
        }

        #endregion


        #region accessors

        public int CpuMonitor => (int)_cpuCounter.NextValue();
        public int RamMonitor => (int)((_ramTotalSize - _ramCounter.NextValue()) / _ramTotalSize * 100);
        //public int GpuMonitor => (int) _gpuCounter.NextValue();
        public int HdMonitor => (int)_hdCounter.NextValue();

        public int BatteryPercent => (int)(_batteryInfo.BatteryLifePercent * 100);
        public string ChargerStatus => _batteryInfo.PowerLineStatus.ToString();

        public BatteryMonitor BatteryMonitor { get; }

        #endregion
    }
}