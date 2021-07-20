using System;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace Smart_Battery_Monitor
{
    public class Bluetooth
    {
        #region initializer

        //declare object from SerialPort lib
        private readonly SerialPort _serialPort;

        public Bluetooth()
        {
            //initialize object from SerialPort lib
            _serialPort = new SerialPort { PortName = "COM6", BaudRate = 9600 };

            //open port
            try
            {
                _serialPort.Open();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, @"Bluetooth");
            }
        }

        #endregion


        #region singnal

        //true  => Connect charger
        //false => Disconnect charger
        public void SendSignal(bool command)
        {
            if (!_serialPort.IsOpen) return;
            _serialPort.Write(command ? "1" : "0");
            Thread.Sleep(1000);
        }

        #endregion
    }
}