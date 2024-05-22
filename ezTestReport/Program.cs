/* made by leo

Title: EzTestReport
Autor: leonardo.avalos.montes@continental-corporation.com
Position: Test Maintenance Technician
Location: Continental Periferico - Guadalajara
Date: 18/03/2024

*/

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace EzTestReport
{
    public class Report
    {
        public void Handle(string filePath, string fileName, string imagePath, string stationName, string serialNumber, string partNumber, string passCount,
            string testStatus, string testStart, string testEnd, string failMode, string testResult, string testLimits, out string fileOutputPath, out int result, out string errorMessage)
        {

            DateTime thisDay = DateTime.Now;

            filePath = filePath + @"\"+ fileName +"_" + thisDay.ToString("d").Replace('/', '-') + ".xlsx";

            try
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File already exists!");
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, testStart, testEnd,  failMode, testResult, testLimits);
                }
                else
                {
                    Console.WriteLine("Creating file!");
                    CreateSpreadsheet(filePath, imagePath, stationName);
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, testStart, testEnd, failMode, testResult, testLimits);
                }
                result = 1;
                errorMessage = "None";
                fileOutputPath = filePath;
            }
            catch (IOException)
            {
                result = 0;
                errorMessage = "The DLL cannot access the file " + filePath + " because this is being used by another process ";
                fileOutputPath = filePath;
                Console.WriteLine(errorMessage);
            }
            
            result = 1;
            errorMessage = "null";
            fileOutputPath = filePath;

        }
        private static void CreateSpreadsheet(string filePath, string imagePath, string stationName)
        {
            //Workbook vars
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Reports");

            //Cell vars
            var headerTitle = ws.Cell("C1");
            var yieldData = ws.Cell("K1");
            var versionTitle = ws.Cell("C2");

            //Range vars
            var headerColumns = ws.Columns("B:J");
            var statiticsColumns = ws.Columns("K:M");
            var filterRange = ws.Range("B4", "H4");
            var headerRow = ws.Row(4);
            var statiticsHeader = ws.Range("K10:M10");

            //Vars
            string version = "ezTestReport v1.1.1";

            //Header Style

            ws.AddPicture(imagePath).MoveTo(ws.Cell("A1")).Scale(0.6);
 
            headerTitle.SetValue(stationName + " AM & AN BE Test Report").Style.Font.SetBold();
            headerTitle.Style.Font.SetFontSize(36);

            yieldData.SetValue("YIELD 0%").Style.Font.SetBold();
            yieldData.Style.Font.SetFontSize(20);

            versionTitle.SetValue(version).Style.Font.SetFontSize(10);
            versionTitle.Style.Font.SetItalic();

            headerColumns.Width = 20;

            headerRow.Style.Fill.BackgroundColor = XLColor.Gray;
            headerRow.Style.Font.SetFontColor(XLColor.White);

            ws.Cell("B4").SetValue("SerialNumber");
            ws.Cell("C4").SetValue("PartNumber");
            ws.Cell("D4").SetValue("PassCount");
            ws.Cell("E4").SetValue("TestStatus");
            ws.Cell("F4").SetValue("TestStart");
            ws.Cell("G4").SetValue("TestEnd");
            ws.Cell("H4").SetValue("Failure");
            ws.Cell("I4").SetValue("Result");
            ws.Cell("J4").SetValue("Limits");

            filterRange.SetAutoFilter();

            //Statitics Style

            statiticsColumns.Width = 20;
            statiticsHeader.Merge();

            ws.Cell("K6").SetValue("Units Processed: ").Style.Font.SetBold();
            ws.Cell("K6").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("L6").SetValue(1);

            ws.Cell("K7").SetValue("Pass").Style.Font.SetBold();
            ws.Cell("K7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("K7").Style.Fill.BackgroundColor = XLColor.Green;
            ws.Cell("L7").SetValue(0);

            ws.Cell("K8").SetValue("Fail").Style.Font.SetBold();
            ws.Cell("K8").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("K8").Style.Fill.BackgroundColor = XLColor.Red;
            ws.Cell("L8").SetValue(0);

            ws.Cell("K10").SetValue("Daily Failures").Style.Font.SetBold();
            ws.Cell("K10").Style.Fill.BackgroundColor = XLColor.Amber;
            ws.Cell("K11").SetValue("Partnumber").Style.Font.SetBold();
            ws.Cell("L11").SetValue("Failure").Style.Font.SetBold();
            ws.Cell("M11").SetValue("Count").Style.Font.SetBold();

            wb.SaveAs(filePath);

            Console.WriteLine("File created!");

            wb.Dispose();
        }
        private static void AddToRow(string filePath, string serialNumber, string partNumber,
            string passCount, string testStatus, string testStart, string testEnd, string failMode, string testResult, string testLimits)
        {
            using (var wb = new XLWorkbook(filePath))
            {
                //Vars
                var ws = wb.Worksheet("Reports");
                var referenceColumn = ws.Column("B");

                int passUnits = 0;
                int failUnits = 0;
                int processedUnits = 0;
                int yieldPercent = 0;
                int indexStatitics = 3;
                int lastRow = referenceColumn.LastCellUsed().Address.RowNumber;
                int statiticsRow = 0;

                string cell = "";

                lastRow = lastRow + 1;

                //Update Table
                ws.Cell(lastRow, 2).SetValue(serialNumber);
                ws.Cell(lastRow, 3).SetValue(partNumber);
                ws.Cell(lastRow, 4).SetValue(passCount);
                ws.Cell(lastRow, 5).SetValue(testStatus);
                ws.Cell(lastRow, 6).SetValue(testStart);
                ws.Cell(lastRow, 7).SetValue(testEnd);
                ws.Cell(lastRow, 8).SetValue(failMode);
                ws.Cell(lastRow, 9).SetValue(testResult);
                ws.Cell(lastRow, 10).SetValue(testLimits);


                processedUnits = lastRow - 4;

                ws.Cell("L6").SetValue(processedUnits);

                //Update Statistics - If a test status = fail (F) the program goin' update the statitics section.
                if (testStatus == "P")
                {
                    passUnits = Int32.Parse(ws.Cell("L7").Value.ToString());
                    passUnits = passUnits + 1;
                    ws.Cell("L7").SetValue(passUnits);

                }

                else if (testStatus == "F") //Here. The program evaluate three things: part number, fail mode and count in the report.
                {
                    failUnits = Int32.Parse(ws.Cell("L8").Value.ToString());
                    failUnits = failUnits + 1;
                    ws.Cell("L8").SetValue(failUnits);

                    if (ws.Cell("K12").IsEmpty())
                    {
                        ws.Cell(12, 11).SetValue(partNumber);
                        ws.Cell(12, 12).SetValue(failMode);
                        ws.Cell(12, 13).SetValue(1);
                    }
                    else
                    {
                        List<string> statiticsFailMode = new List<string>(); //The function of this list is save a fragment of statistics rows
                                                                             //to search and stablish a difference between part numbers.
                        var failModeColumn = ws.Range("L12", "L32");

                        int firstRowFailMode = failModeColumn.FirstCell().Address.RowNumber;
                        int lastRowFailMode = failModeColumn.LastCellUsed().Address.RowNumber;

                        for (int row = firstRowFailMode; row <= lastRowFailMode; row++)
                        {
                            cell = ws.Cell("K" + row).Value.ToString() + "," + ws.Cell("L" + row).Value.ToString();
                            statiticsFailMode.Add(cell);
                        }

                        if (statiticsFailMode.Contains(partNumber + "," + failMode)) //If a fail mode for an specific part number already exists. It goin' update the count
                        {
                            indexStatitics = statiticsFailMode.IndexOf(partNumber + "," + failMode);
                            statiticsRow = indexStatitics + 12; //*12* is to offset the beggining of the table 
                            ws.Cell(statiticsRow,13).SetValue(Int32.Parse(ws.Cell(lastRowFailMode,13).Value.ToString()) + 1);
                        } else
                        {
                            ws.Cell(lastRowFailMode + 1, 11).SetValue(partNumber);
                            ws.Cell(lastRowFailMode + 1, 12).SetValue(failMode);
                            ws.Cell(lastRowFailMode + 1, 13).SetValue(1);
                        }
                    }
                }

                //Update Yield
                yieldPercent = (passUnits * 100) / processedUnits;

                ws.Cell("K1").SetValue("YIELD " + yieldPercent + "%");

                wb.SaveAs(filePath);
                wb.Dispose();

                Console.WriteLine("Data appended!");

            }
        }
        public void Viewer(string viewerPath, string reportPath, out string errorMessage, out int result)
        {
            if (File.Exists(viewerPath))
            {
                if (File.Exists(reportPath))
                {
                    string args = reportPath;
                    string processName = "ezTestReportViewer";

                    string workingPath = Path.GetDirectoryName(viewerPath);

                    Process[] processes = Process.GetProcessesByName(processName);

                    if (processes.Length > 0)
                    {
                        Console.WriteLine("Process already running");
                        result = 0;
                    }
                    else
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo(viewerPath);
                        startInfo.Arguments = args;
                        startInfo.WorkingDirectory = workingPath;
                        Process process = Process.Start(startInfo);
                        process.WaitForExit();
                        result = 1;
                    }
                    errorMessage = "";
                }
                else
                {
                    errorMessage = "Report file cannot be located in " + reportPath;
                    result = 2;
                }
            }
            else
            {
                errorMessage = "ezTestReportViewer.exe cannot be located in " + viewerPath;
                result = 2;
            }
        }
    }
}

/*          *
           *
          *
         ****
           *
          *
         *          */