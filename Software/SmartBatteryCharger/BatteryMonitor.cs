using System.Threading;
using System.Windows.Forms;

namespace Smart_Battery_Charger
{
    internal class BatteryMonitor
    {
        private const int StartChargePercentage = 20;
        private const int StopChargePercentage = 80;

        public BatteryMonitor()
        {
            //SerialPort serialPort = new SerialPort();
            var monitorThread = new Thread(CheckPercentage);
            monitorThread.Start();
        }

        private static void CheckPercentage()
        {
            var breakLoop = false;
            var pwrStatus = SystemInformation.PowerStatus;

            while (true)
            {
                var currentPercentage = (int) (pwrStatus.BatteryLifePercent * 100);

                switch (currentPercentage)
                {
                    case <= StartChargePercentage:
                        MessageBox.Show(@"Start Charge !");
                        breakLoop = true;
                        break;
                    
                    case >= StopChargePercentage:
                        MessageBox.Show(@"Stop Charge !");
                        breakLoop = true;
                        break;
                }

                if (breakLoop) break;
            }

 

        }

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