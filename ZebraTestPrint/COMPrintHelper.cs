using System;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;

namespace ZebraTestPrint
{
    class COMPrintHelper
    {
        #region Constants

        private const string END_COMMAND = "\r\n";

        #endregion

        #region Class Attributes

        SerialPort com = null;

        private string comPort = "COM4";
        private int baudRate = 57600;

        public string ComPortNumber
        {
            get
            {
                return this.comPort;
            }
        }

        public int ComPortBaudRate { get { return this.baudRate; } }

        #endregion

        public COMPrintHelper(string comPort, int baudRate)
        {
            this.comPort = comPort;
            this.baudRate = baudRate;
        }
        #region Initialize / Uninitialize Commands

        public bool Open()
        {
            bool done = false;
            do
            {
                try
                {
                    com = new SerialPort(ComPortNumber, ComPortBaudRate, Parity.None, 8, StopBits.One);
                    com.Handshake = Handshake.XOnXOff;
                    com.Open();
                    done = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        com.Dispose();
                        com = null;
                        GC.Collect();
                    }
                    catch (Exception) { }

                    if (System.Windows.Forms.MessageBox.Show(
                        "Unable to connect to printer: " + ex.Message,
                        "Bluetooth Failed",
                        System.Windows.Forms.MessageBoxButtons.RetryCancel,
                        System.Windows.Forms.MessageBoxIcon.Exclamation,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1
                        ) == System.Windows.Forms.DialogResult.Retry)
                    {
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }
                }
            } while (!done);

            return this.IsOpen;
        }
        public void Close()
        {
            try
            {
                if (this.IsOpen)
                {
                    com.Close();
                }
                com = null;
                GC.Collect();
            }
            catch (Exception)
            {
                // do nothing
            }
        }
        public bool IsOpen
        {
            get
            {
                return ((com != null) && (com.IsOpen));
            }
        }

        #endregion

        #region Printer Commands

        public void Print(string line)
        {
            line = line.Replace("\\n", string.Empty);
            line = Misc.StripChars(line, new char[] { '\r', '\n' });
            line = line.Trim();
            if (string.IsNullOrEmpty(line))
            {
                return;
            }

            //if (this.IsOpen)
            //{
            //    try
            //    {
            //        com.WriteLine(line);
            //    }
            //    catch (IOException)
            //    {
            //        this.Close();
            //    }
            //}
            this.Print(Encoding.ASCII.GetBytes(line + END_COMMAND));
        }

        public void Print(byte[] data)
        {
            if (this.IsOpen)
            {
                try
                {
                    com.Write(data, 0, data.Length);
                }
                catch (IOException)
                {
                    this.Close();
                }
            }
        }

        #endregion
    }
}