using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Smart_Battery_Monitor
{
    public class ResourcesMonitor
    {
        #region initializer

        //initialize PowerStatus to provide info about battery and charger
        private readonly PowerStatus _batteryInfo;
        //get total amount of ram in machine
        private readonly ulong _ramTotalSize;

        private readonly PerformanceCounter _cpuCounter;
        private readonly PerformanceCounter _ramCounter;
        //private readonly PerformanceCounter _gpuCounter;
        private readonly PerformanceCounter _hdCounter;

        //constructor
        public ResourcesMonitor()
        {
            //initialize BatteryMonitor to provide streaming battery percentages
            BatteryMonitor = new BatteryMonitor();
            _batteryInfo = SystemInformation.PowerStatus;

            //1,000,000 = 1000 * 1000 ( Byte => M.Byte )
            _ramTotalSize = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / (ulong)1e6;

            //initialize PerformanceCounter object
            _cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total", true);
            _ramCounter = new PerformanceCounter("Memory", "Available MBytes", true);
            //_gpuCounter = new PerformanceCounter("GPU Engine", "Utilization Percentage", "*", true);
            _hdCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total", true);
        }

        #endregion

        #region accessors

        public BatteryMonitor BatteryMonitor { get; }
        public int BatteryPercent => (int)(_batteryInfo.BatteryLifePercent * 100);
        public string ChargerStatus => _batteryInfo.PowerLineStatus.ToString();

        public int CpuMonitor()
        {
            var cpuTemp = (int)_cpuCounter.NextValue();
            return cpuTemp > 100 ? 100 : cpuTemp;
        }

        public int RamMonitor()
        {
            var ramTemp = Convert.ToInt32((_ramTotalSize - _ramCounter.NextValue()) / _ramTotalSize * 100);
            return ramTemp > 100 ? 100 : ramTemp;
        }

        public int HdMonitor()
        {
            var hdTemp = (int)_hdCounter.NextValue();
            return hdTemp > 100 ? 100 : hdTemp;
        }

        #endregion
    }
}