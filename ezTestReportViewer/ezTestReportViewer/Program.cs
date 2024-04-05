using System;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;


namespace ezTestReportViewer
{

    public class Window
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        private static string filePath;
        private static string windowType;

        [STAThread]

        private protected static void Main(string[] args)
        {
            windowType = args[0];
            filePath = args[1];
            

            if (File.Exists(filePath))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (windowType == "tiny")
                {
                    //Application.Run(new tiny(fpyPercent));
                }
                else if (windowType == "medium")
                {
                    Application.Run(new medium(filePath));
                }
                else if (windowType == "large")
                {
                    Application.Run(new large());
                }
            }

        }

        //private static void fileChanged(object sender, FileSystemEventArgs e)
        //{
        //    if (e.ChangeType == WatcherChangeTypes.Changed)
        //    {
        //        var (passUnits, failUnits, unitsProcessed) = ReadDocument();
        //        double fpyPercent = calculateFPY((double)passUnits, (double)unitsProcessed);

        //        if (windowType == "medium") 
        //        {
        //            medium.fileModified((int)passUnits, (int)failUnits, fpyPercent);
        //        }
                
        //    }
        //}

        
    }
}
