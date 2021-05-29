using System;
using System.Threading;
using System.Windows.Forms;

namespace Smart_Battery_Charger
{
    internal class BatteryMonitor
    {
        #region initializer
        private const int StartChargePercentage = 20;
        private const int StopChargePercentage = 66;

        // 1- define delegate
        public delegate void ChangeBatteryPercentageEventHandler(object source, EventArgs args);
        
        // 2- define event on delegate
        public event ChangeBatteryPercentageEventHandler PercentChanged;
        #endregion

        #region eventHandler
        //constructor
        public BatteryMonitor()
        {
            //SerialPort serialPort = new SerialPort();
            var monitorThread = new Thread(CheckPercentageChanging) {Name = "CheckPercentageChanging_Thread", IsBackground = true};
            monitorThread.Start();
        }

        private void CheckPercentageChanging()
        {
            var pwrStatus = SystemInformation.PowerStatus;
            var batteryPercentNow = (int) (pwrStatus.BatteryLifePercent * 100);

            tryAgain:
            Thread.Sleep(1000);
            if (batteryPercentNow != (int) (pwrStatus.BatteryLifePercent * 100))
            {

                MessageBox.Show(@"In Thread Now is: {Thread.CurrentThread.Name} {Thread.CurrentThread.ManagedThreadId}");
                OnPercentChanged();
            }

            else
                goto tryAgain;
        }

        // 3- raise event
        protected virtual void OnPercentChanged() => PercentChanged?.Invoke(this, EventArgs.Empty);
        #endregion


        //private void SendSignal(string command, int timeInSecond)
        //{


        //    check if bluetooth module port is open :
        //    if (serialPort.IsOpen)
        //    {

        //        serialPort.Write(command);
        //        Thread.Sleep(timeInSecond);
        //    }

        //}

        //private void ReceiveSignal(ref string dataReceived)
        //{

        //    if (serialPort.IsOpen)
        //    {
        //        if (serialPort.BytesToRead > 0)
        //            dataReceived = serialPort.ReadLine();

        //    }
        //}

    }
}