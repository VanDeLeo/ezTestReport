using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace ezTestReportViewer
{
    public partial class medium : Form
    {
        //Global Things
        private static DateTime lastModification;

        private static FileSystemWatcher watcher;

        private static Label pLabel;
        private static Label fLabel;
        private static Label yLabel;

        private static Chart dChart;

        private static string filePath;

        public medium(string path, string appVersion)
        {
            InitializeComponent();

            pLabel = passLabel;
            fLabel = failLabel;
            yLabel = fpyLabel;

            dChart = chartFPY;

            watcher = fileSystemWatcher1;

            filePath = path;

            version.Text = appVersion;

            var (passUnits, failUnits, unitsProcessed) = ReadDocument();
            double fpyPercent = calculateFPY((double)passUnits, (double)unitsProcessed);
            double failPercent = (double)100 - fpyPercent;

            dChart.Series["s1"].Points.AddXY("PASS", fpyPercent.ToString("N2"));
            dChart.Series["s1"].Points.AddXY("FAIL", failPercent.ToString("N2"));

            pLabel.Text = "Pass Units = " + passUnits.ToString();
            fLabel.Text = "Fail Units = " + failUnits.ToString();
            yLabel.Text = fpyPercent.ToString("N2") + "%";


            lastModification = File.GetLastWriteTime(filePath); //This is a reference to compare files
            timer.Start();
            watcher.Path = Path.GetDirectoryName(filePath);
            watcher.EnableRaisingEvents = true;
            
        }

        public static void fileModified() //If the file was modified this method read it and update the application with new data 
        {
            DateTime newModification = File.GetLastWriteTime(filePath);
            if (newModification != lastModification) 
            {
                var (passUnits, failUnits, unitsProcessed) = ReadDocument();
                double fpyPercent = calculateFPY((double)passUnits,(double)unitsProcessed);

                double failPercent = (double)100 - fpyPercent;

                pLabel.Text = "Pass Units = " + passUnits.ToString();
                fLabel.Text = "Fail Units = " + failUnits.ToString();
                yLabel.Text = fpyPercent.ToString("N2") + "%";

                dChart.Series["s1"].Points.Clear();
                dChart.Series["s1"].Points.AddXY("PASS", fpyPercent.ToString("N2"));
                dChart.Series["s1"].Points.AddXY("FAIL", failPercent.ToString("N2"));

                lastModification = newModification;
            }
            
        }

        private static (int, int, int) ReadDocument()
        {
            int passUnits, failUnits, unitsProcessed;

            try
            {
                using (var wb = new XLWorkbook(filePath))
                {
                    var ws = wb.Worksheet("Reports");

                    unitsProcessed = Int32.Parse(ws.Cell("K6").Value.ToString());
                    passUnits = Int32.Parse(ws.Cell("K7").Value.ToString());
                    failUnits = Int32.Parse(ws.Cell("K8").Value.ToString());

                    wb.Dispose();

                }
            }
            catch (System.IO.IOException)
            {
                //This is an easy way to fix the problem in case that the file it's open by another instance. I'll fix it... someday.
                (passUnits, failUnits, unitsProcessed) = ReadDocument();
            }

            return (passUnits, failUnits, unitsProcessed);
        }


        private static double calculateFPY(double passUnits, double unitsProcessed)
        {
            return (passUnits * 100) / unitsProcessed;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            fileModified();
        }

    }
}
