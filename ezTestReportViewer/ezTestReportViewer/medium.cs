using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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

        private static Button b1;
        private static Button b2;
        private static Button b3;
        private static Button b4;
        private static Button b5;
        private static Button b6;
        private static Button b7;
        private static Button b8;
        private static Button b9;
        private static Button b10;
        private static Button b11;
        private static Button b12;
        private static Button b13;
        private static Button b14;
        private static Button b15;
        private static Button b16;
        private static Button b17;
        private static Button b18;
        private static Chart dChart;

        private static ToolTip tip;

        private static ListBox historyList;
        private static ListBox failsList;

        private static string filePath;

        private static List<Button> buttons = new List<Button>();

        public medium(string path, string appVersion)
        {
            InitializeComponent();

            pLabel = passLabel;
            fLabel = failLabel;
            yLabel = fpyLabel;

            buttons.Add(b1 = s1);
            buttons.Add(b2 = s2);
            buttons.Add(b3 = s3);
            buttons.Add(b4 = s4);
            buttons.Add(b5 = s5);
            buttons.Add(b6 = s6);
            buttons.Add(b7 = s7);
            buttons.Add(b8 = s8);
            buttons.Add(b9 = s9);
            buttons.Add(b10 = s10);
            buttons.Add(b11 = s11);
            buttons.Add(b12 = s12);
            buttons.Add(b13 = s13);
            buttons.Add(b14 = s14);
            buttons.Add(b15 = s15);
            buttons.Add(b16 = s16);
            buttons.Add(b17 = s17);
            buttons.Add(b18 = s18);
           
            dChart = chartFPY;

            tip = toolTip1;

            watcher = fileSystemWatcher1;

            filePath = path;

            version.Text = appVersion;

            historyList = listBox1;
            failsList = listBox2;

            int index;

            var (passUnits, failUnits, unitsProcessed, LastTests, historyData, failsData, hintsValues) = ReadDocument();
            double fpyPercent = calculateFPY(historyData, failsData);
            double failPercent = (double)100 - fpyPercent;

            dChart.Series["s1"].Points.AddXY("PASS", fpyPercent.ToString("N2"));
            dChart.Series["s1"].Points.AddXY("FAIL", failPercent.ToString("N2"));

            pLabel.Text = "Pass Units = " + passUnits.ToString();
            fLabel.Text = "Fail Units = " + failUnits.ToString();
            yLabel.Text = fpyPercent.ToString("N2") + "%";

            LastTests.Reverse();
            hintsValues.Reverse();

            foreach(Button button in buttons)
            {
                index = buttons.IndexOf(button);
                if (LastTests[index].ToString() == "P")
                {
                    button.BackColor = Color.Green;
                }
                else if (LastTests[index].ToString() == "F")
                {
                    button.BackColor = Color.Red;
                }

                tip.SetToolTip(button, hintsValues[index]);
            }

            //History & Fails ListBox Tab
            historyData.ToList().ForEach(item => historyList.Items.Add(item));
            failsData.ToList().ForEach (item => failsList.Items.Add(item));


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
                int index;
                var (passUnits, failUnits, unitsProcessed, lastTests, historyData, failsData, hintsValues) = ReadDocument();
                double fpyPercent = calculateFPY(historyData, failsData);

                double failPercent = (double)100 - fpyPercent;

                pLabel.Text = "Pass Units = " + passUnits.ToString();
                fLabel.Text = "Fail Units = " + failUnits.ToString();
                yLabel.Text = fpyPercent.ToString("N2") + "%";

                dChart.Series["s1"].Points.Clear();
                dChart.Series["s1"].Points.AddXY("PASS", fpyPercent.ToString("N2"));
                dChart.Series["s1"].Points.AddXY("FAIL", failPercent.ToString("N2"));

                lastTests.Reverse();
                hintsValues.Reverse();

                foreach (Button button in buttons)
                {
                    index = buttons.IndexOf(button);
                    if (lastTests[index].ToString() == "P")
                    {
                        button.BackColor = Color.Green;
                    }
                    else if (lastTests[index].ToString() == "F")
                    {
                        button.BackColor = Color.Red;
                    }
                    tip.SetToolTip(button, hintsValues[index]);
                }

                //History & Fails ListBox Tab
                historyList.Items.Clear();
                failsList.Items.Clear();
                historyData.ToList().ForEach(item => historyList.Items.Add(item));
                failsData.ToList().ForEach(item => failsList.Items.Add(item));

                lastModification = newModification;
            }
            
        }

        private static (int, int, int, List<string>, List<string>, List<string>, List<string>) ReadDocument()
        {
            int passUnits, failUnits, unitsProcessed;
            int nButtons = 18;
            List<string> buttonValues = new List<string>();
            List<string> hints = new List<string>();
            List<string> historyRows = new List<string>();
            List<string> failsRows = new List<string>();

            try
            {
                using (var wb = new XLWorkbook(filePath))
                {
                    var ws = wb.Worksheet("Reports");

                    //IXLRange cellsRange = null;
                    IXLRange historyRange = null;
                    IXLRange failsRange = null;

                    try
                    {
                        unitsProcessed = Int32.Parse(ws.Cell("L6").Value.ToString());
                        passUnits = Int32.Parse(ws.Cell("L7").Value.ToString());
                        failUnits = Int32.Parse(ws.Cell("L8").Value.ToString());
                    }
                    catch (System.FormatException)
                    {
                        MessageBox.Show("Bad structure in excel file","Error in Excel file");
                        throw;
                    }

                    int lastRowUsedHistory = ws.Range("B:J").LastRowUsed().RowNumber();
                    int startRow = Math.Max(5,lastRowUsedHistory-99);
                    historyRange = ws.Range(startRow, 2, lastRowUsedHistory, 10);
                    //Observe
                    failsRange = ws.Range(5, 2, lastRowUsedHistory, 10);

                    foreach (var row in historyRange.Rows())
                    {
                        string concatenatedRow = string.Join(" , ", row.Cells().Select(cell => cell.Value.ToString()));
                        historyRows.Add(concatenatedRow);
                        
                    }

                    foreach (var row in failsRange.Rows())
                    {
                        if (row.Cell(4).GetString() == "F")
                        {
                            string concatenatedRow = string.Join(" , ", row.Cells().Select(cell => cell.Value.ToString()));
                            failsRows.Add(concatenatedRow);
                        }
                    }

                    failsRows.Reverse();
                    historyRows.Reverse();

                    if (historyRows.Count >= nButtons)
                    {
                        for (int row = 0; row < nButtons; row++)
                        {
                            hints.Add(historyRows[row]);
                            string[] rowData = historyRows[row].Split(',');
                            buttonValues.Add(rowData[3].Replace(" ",""));
                        }
                    } else
                    {
                        int rowsOffset = nButtons - historyRows.Count;

                        for (int  i = 0; i < rowsOffset; i++)
                        {
                            buttonValues.Add("N");
                            hints.Add("Empty");
                        }
                        for (int row = 0; row < nButtons; row++)
                        {
                            hints.Add(historyRows[row]);
                            string[] rowData = historyRows[row].Split(',');
                            buttonValues.Add(rowData[3].Replace(" ", ""));
                        }
                    }

                    wb.Dispose();

                }
            }
            catch (System.IO.IOException)
            {
                //This is an easy way to fix the problem in case that the file it's open by another instance. I'll fix it... someday.
                (passUnits, failUnits, unitsProcessed, buttonValues, historyRows, failsRows, hints) = ReadDocument();
            }

            return (passUnits, failUnits, unitsProcessed, buttonValues, historyRows, failsRows, hints);
        }


        private static double calculateFPY(List<string> allList, List<string> failList)
        {
            int totalUnitsProcessed = allList.Count();
            int totalUnitsPassed = allList.Count(element => !failList.Contains(element));

            double totalFPY = (totalUnitsPassed * 100) / totalUnitsProcessed;

            return totalFPY;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            fileModified();
        }

        private void copyAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string textToCopy = "";
            foreach (string item in historyList.Items)
            {
                textToCopy += item + Environment.NewLine;
            }
            Clipboard.SetText(textToCopy);
        }

        private void copyAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string textToCopy = "";
            foreach (string item in failsList.Items)
            {
                textToCopy += item + Environment.NewLine;
            }
            Clipboard.SetText(textToCopy);
        }

        private void medium_Load(object sender, EventArgs e)
        {

        }

        private void s5_Click(object sender, EventArgs e)
        {

        }

        private void s6_Click(object sender, EventArgs e)
        {

        }

        private void s7_Click(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {

        }
    }
}
