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


        private static FileSystemWatcher watcher;
        private static string filePath;


        [STAThread]

        private protected static void Main(string[] args)
        {
            string windowType = args[0];
            
            filePath = args[1];

            if (File.Exists(filePath))
            {
                var (passUnits, failUnits, unitsProcessed) = ReadDocument();


                double fpyPercent = ((double)passUnits * 100) / (double)unitsProcessed;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (windowType == "tiny")
                {
                    Application.Run(new tiny(fpyPercent));
                }
                else if (windowType == "medium")
                {
                    Application.Run(new medium(passUnits, failUnits, fpyPercent));
                }
                else if (windowType == "large")
                {
                    Application.Run(new large());
                }
            }

            watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName(filePath);
            watcher.Filter = Path.GetFileName(filePath);
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += fileChanged;
            watcher.EnableRaisingEvents = true;

        }

        private static void fileChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                var (passUnits, failUnits, unitsProcessed) = ReadDocument();
            }
        }

        private static (int,int,int) ReadDocument()
        {
            int passUnits, failUnits, unitsProcessed;
            using (var wb = new XLWorkbook(filePath))
            {
                var ws = wb.Worksheet("Reports");

                unitsProcessed = Int32.Parse(ws.Cell("K6").ToString());
                passUnits = Int32.Parse(ws.Cell("K7").ToString());
                failUnits = Int32.Parse(ws.Cell("K8").ToString());

                wb.Dispose();

            }
            return (passUnits, failUnits, unitsProcessed);
        }
    }
}
