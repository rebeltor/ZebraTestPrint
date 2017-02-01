using System;
using System.Runtime.InteropServices;


namespace ZebraTestPrint
{
    class PlainTextPrinter
    {
        private const int BUFFER_SIZE = 4096;

        public void Print(string rawdata, string printer_name)
        {
            IntPtr hPrinter = IntPtr.Zero;
            int pcWritten = 0;

            DOCINFO di = new DOCINFO();
            di.pDataType = "RAW";
            di.pDocName = "AIMS";

            OpenPrinter(printer_name, ref hPrinter, 0);
            if (hPrinter == IntPtr.Zero)
            {
                return;
            }
            try
            {
                StartDocPrinter(hPrinter, 1, ref di);
                StartPagePrinter(hPrinter);


                WritePrinter(hPrinter, rawdata, rawdata.Length, ref pcWritten);


                EndPagePrinter(hPrinter);
                EndDocPrinter(hPrinter);
            }
            finally
            {
                ClosePrinter(hPrinter);
            }
        }
        ///// <summary>
        ///// Determine if a printer exists on the PC or not
        ///// I wanted to put this in EDC_Library but it wouldnt let me reference System.Drawing.Printing...
        ///// </summary>
        //private bool PrinterExists(string printername)
        //{
        //    foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
        //    {
        //        if (printername == printer)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        #region Win32 API Calls

        [StructLayout(LayoutKind.Sequential)]
        private struct DOCINFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern long OpenPrinter(string pPrinterName, ref IntPtr hPrinter, int pDefault);
        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        private static extern long StartDocPrinter(IntPtr hPrinter, int Level, ref DOCINFO pDocInfo);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.drv", CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long WritePrinter(IntPtr hPrinter, string data, int buf, ref int pcWritten);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.drv", CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern long ClosePrinter(IntPtr hPrinter);

        #endregion
    }
}