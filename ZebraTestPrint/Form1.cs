using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace ZebraTestPrint
{
    public partial class Form1 : Form
    {
        private int refreshing = 0;

        public Form1()
        {
            InitializeComponent();

            this.RefreshData();
        }

        private void RefreshData()
        {
            if (this.refreshing <= 0)
            {
                this.refreshing += 1;
                try
                {

                    // initialize the combobox
                    cboPrinterName.Items.Clear();

                    foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    {
                        cboPrinterName.Items.Add(printer);
                    }

                    // initialize the combobox
                    cboPorts.Items.Clear();
                    foreach (string port in SerialPort.GetPortNames())
                    {
                        cboPorts.Items.Add(port);
                    }
                }
                finally
                {
                    this.refreshing -= 1;
                }
            }
        }

        private void btnTestPrint_Click(object sender, EventArgs e)
        {
            if (this.refreshing <= 0)
            {
                this.refreshing += 1;
                try
                {
                    if (!(cboPrinterName.SelectedItem is string))
                    {
                        MessageBox.Show("Please select a printer", "Invalid Option");
                        return;
                    }

                    string printerName = (string)cboPrinterName.SelectedItem;

                    if (string.IsNullOrEmpty(printerName))
                    {
                        MessageBox.Show("Please select a printer", "Invalid Option");
                        return;
                    }

                    string data = GetTestPrintFormat();

                    //PrintHelper.SendStringToPrinter(printerName, data);

                    //data = "^XA^FWN^MD30" + System.Environment.NewLine +
                    //    "^FO0100,0040^A0,N,100,30^FD TEMPORARY ^FS" + System.Environment.NewLine +
                    //    "^FO0020,0140^A0,N,100,30^FD PARKING PERMIT ^FS" + System.Environment.NewLine +
                    //    "^XZ";

                    byte[] b = Encoding.ASCII.GetBytes(data);
                    RawPrinter.Print(b, printerName);

                    //PlainTextPrinter p = new PlainTextPrinter();
                    //p.Print(data, printerName);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Test Print Error");
                }
                finally
                {
                    this.refreshing -= 1;
                }
            }
        }


        private string GetTestPrintFormat()
        {
            string s = @"!15 203 203 1500 1
LABEL
TONE 0
CENTER
T 5 1 0 245 TICKET INFORMATION
IL 0 235 550 235 55
LEFT
T 5 2 0 295 Ticket #: 17X00001
T 7 0 0 345 Date: 01/30/2017
T 7 0 300 345 Time: 17:55
T 7 0 0 370 Location:[ N DWIGHT PARK DRIVE
T 7 0 0 395 Block: 100
T 7 0 300 395 Meter: M12345
CENTER
T 5 1 0 430 VEHICLE INFORMATION
IL 0 420 550 420 55
LEFT
T 7 0 0 480 Plate: ABC1234 NY
T 7 0 0 505 Reg Exp: 12/20
T 7 0 300 505 VIN4: 1234
T 7 0 0 530 Permit: P123456
T 7 0 0 555 Vehicle: 2017 FORD TAURUS
T 7 0 0 580 Color: WHITE
T 7 0 300 580 Body: 4DRSD
T 7 0 0 605 Plate Type: PAS
CENTER
T 5 1 0 640 VIOLATION INFORMATION
IL 0 630 550 630 55
LEFT
T 7 0 0 690 Chalk Time: 01/30/2017 15:33
T 7 0 0 715 Elapsed Time: 15m
T 7 0 0 740 Stem 1 Pos.: 12
T 7 0 300 740 Stem 2 Pos.: 6
T 7 0 0 765 Violation: 001     		Amount: $25.00
T 7 0 0 790 METER VIOLATION
T 7 0 0 815 Violation #2: 002     		Amount: $10.00
T 7 0 0 840 OVERTIME PARKING
T 7 0 0 865 Violation #3: 003     		Amount: $20.00
T 7 0 0 890 FAILURE TO DISPLAY
CENTER
T 5 1 0 925 PAYMENT INFORMATION
IL 0 915 550 915 55
LEFT
T 5 2 0 975 Total Amount: $55.00
LINE 0 1075 430 1075 3
T 7 0 0 1100 NEXT VIOLATION WILL BE TOW
CENTER
B 39 1 2 50 0 1175 17X00001
LEFT
T 7 0 20 1380 Officer: 100
FORM
PRINT";
            return s;
        }

        private string[] GetTestPrintArry()
        {
            List<string> lines = new List<string>();
            lines.Add("!15 203 203 1500 1");
            lines.Add("LABEL");
            lines.Add("TONE 0");
            lines.Add("CENTER");
            lines.Add("T 5 1 0 245 TICKET INFORMATION");
            lines.Add("IL 0 235 550 235 55");
            lines.Add("LEFT");
            lines.Add("T 5 2 0 295 Ticket #: 17X00001");
            lines.Add("T 7 0 0 345 Date: 01/30/2017");
            lines.Add("T 7 0 300 345 Time: 17:55");
            lines.Add("T 7 0 0 370 Location:[ N DWIGHT PARK DRIVE");
            lines.Add("T 7 0 0 395 Block: 100");
            lines.Add("T 7 0 300 395 Meter: M12345");
            lines.Add("CENTER");
            lines.Add("T 5 1 0 430 VEHICLE INFORMATION");
            lines.Add("IL 0 420 550 420 55");
            lines.Add("LEFT");
            lines.Add("T 7 0 0 480 Plate: ABC1234 NY");
            lines.Add("T 7 0 0 505 Reg Exp: 12/20");
            lines.Add("T 7 0 300 505 VIN4: 1234");
            lines.Add("T 7 0 0 530 Permit: P123456");
            lines.Add("T 7 0 0 555 Vehicle: 2017 FORD TAURUS");
            lines.Add("T 7 0 0 580 Color: WHITE");
            lines.Add("T 7 0 300 580 Body: 4DRSD");
            lines.Add("T 7 0 0 605 Plate Type: PAS");
            lines.Add("CENTER");
            lines.Add("T 5 1 0 640 VIOLATION INFORMATION");
            lines.Add("IL 0 630 550 630 55");
            lines.Add("LEFT");
            lines.Add("T 7 0 0 690 Chalk Time: 01/30/2017 15:33");
            lines.Add("T 7 0 0 715 Elapsed Time: 15m");
            lines.Add("T 7 0 0 740 Stem 1 Pos.: 12");
            lines.Add("T 7 0 300 740 Stem 2 Pos.: 6");
            lines.Add("T 7 0 0 765 Violation: 001     		Amount: $25.00");
            lines.Add("T 7 0 0 790 METER VIOLATION");
            lines.Add("T 7 0 0 815 Violation #2: 002     		Amount: $10.00");
            lines.Add("T 7 0 0 840 OVERTIME PARKING");
            lines.Add("T 7 0 0 865 Violation #3: 003     		Amount: $20.00");
            lines.Add("T 7 0 0 890 FAILURE TO DISPLAY");
            lines.Add("CENTER");
            lines.Add("T 5 1 0 925 PAYMENT INFORMATION");
            lines.Add("IL 0 915 550 915 55");
            lines.Add("LEFT");
            lines.Add("T 5 2 0 975 Total Amount: $55.00");
            lines.Add("LINE 0 1075 430 1075 3");
            lines.Add("T 7 0 0 1100 NEXT VIOLATION WILL BE TOW");
            lines.Add("CENTER");
            lines.Add("B 39 1 2 50 0 1175 17X00001");
            lines.Add("LEFT");
            lines.Add("T 7 0 20 1380 Officer: 100");
            lines.Add("FORM");
            lines.Add("PRINT");
            return lines.ToArray();
        }

        private string[] GetTestZPL()
        {
            List<string> lines = new List<string>();
            lines.Add("^XA^FWN^MD30");
            lines.Add("^FO0100,0040^A0,N,100,30^FD TEMPORARY ^FS");
            lines.Add("^FO0020,0140^A0,N,100,30^FD PARKING PERMIT ^FS");
            lines.Add("^XZ");

            return lines.ToArray();
        }
        private void btnCOMTest_Click(object sender, EventArgs e)
        {
            if (this.refreshing <= 0)
            {
                this.refreshing += 1;
                try
                {
                    if (!(cboPorts.SelectedItem is string))
                    {
                        MessageBox.Show("Please select a port", "Invalid COM Option");
                        return;
                    }

                    string portName = (string)cboPorts.SelectedItem;

                    if (string.IsNullOrEmpty(portName))
                    {
                        MessageBox.Show("Please select a port", "Invalid COM Option");
                        return;
                    }

                    string[] lines;
              
                    if (rbCPCL.Checked)
                    {
                        lines = GetTestPrintArry();
                    }
                    else
                    {
                        lines = GetTestZPL();
                    }

                    Console.Write("Opening COM Port... " + portName);
                    COMPrintHelper com = new COMPrintHelper(portName, 9600);
                    Console.WriteLine("... Open!");

                    try
                    {
                        com.Open();

                        if (com.IsOpen)
                        {
                            foreach (string line in lines)
                            {
                                Console.Write("Sending data... " + line);
                                com.Print(line);
                                Console.WriteLine("... Sent!");
                            }
                        }
                        else
                        {
                            throw new ApplicationException("Cannot write to a closed COM port");
                        }
                    }
                    catch (Exception printEx)
                    {
                        Console.WriteLine("Error: " + printEx.Message);
                        MessageBox.Show(printEx.Message, "COM Print Error");
                    }
                    finally
                    {
                        com.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Test Print Error");
                }
                finally
                {
                    this.refreshing -= 1;
                }
            }
        }

    }
}
