using System;
using System.Threading;
using System.Windows.Forms;

namespace Smart_Battery_Monitor
{
    public class BatteryMonitor
    {
        #region initializer

        // 1- define delegate or use EventHandler<Generic>
        // 2- define event on delegate
        public event EventHandler PercentChanged;

        //constructor
        public BatteryMonitor()
        {
            var monitorThread = new Thread(CheckPercentageChanging)
                { Name = "threadCheckPercentageChanging", IsBackground = true };
            monitorThread.Start();
        }

        #endregion


        #region eventHandler

        //looping till battery percent change by 1%
        private void CheckPercentageChanging()
        {
            var batteryInfo = SystemInformation.PowerStatus;
            var percentSnapshot = (int)(batteryInfo.BatteryLifePercent * 100);

        tryAgain:
            if (percentSnapshot != (int)(batteryInfo.BatteryLifePercent * 100))
            {
                percentSnapshot = (int)(batteryInfo.BatteryLifePercent * 100);
                OnPercentChanged();
            }
            Thread.Sleep(1000);
            goto tryAgain;
            // ReSharper disable once FunctionNeverReturns
        }

        // 3- raise event
        protected virtual void OnPercentChanged() => PercentChanged?.Invoke(this, EventArgs.Empty);

        #endregion
    }
}