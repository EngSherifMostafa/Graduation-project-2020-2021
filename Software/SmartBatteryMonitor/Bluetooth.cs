using System;
using System.IO.Ports;
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
            var errPortMsg = string.Empty;
            string[] arrCom = {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"};

            foreach (var port in arrCom)
            {
                try
                {
                    //initialize object from SerialPort lib
                    _serialPort = new SerialPort {PortName = port, BaudRate = 9600};

                    //open port
                    _serialPort.Open();
                }

                catch (Exception err)
                {
                    errPortMsg = err.Message;
                    continue;
                }

                if (port.Equals(arrCom[^1]) && errPortMsg != string.Empty) //^1 => last index in array
                    MessageBox.Show(errPortMsg, @"Bluetooth");

                break;
            }
        }

        #endregion


        #region singnal

        //true  => Connect charger
        //false => Disconnect charger
        public void SendSignal(bool command)
        {
            try
            {
                if (!_serialPort.IsOpen) _serialPort.Open();
                _serialPort.Write(command ? "1" : "0");
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message, @"SendSignal");
            }

            finally
            {
                _serialPort.Close();
            }
        }

        #endregion
    }
}