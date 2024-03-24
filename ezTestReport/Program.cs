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

namespace EzTestReport
{
    public class Program
    {
        public void Report(string filePath, string imagePath, string stationName, string serialNumber, string partNumber, string passCount,
            string testStatus, string failMode, string testResult, string testLimits, out string fileOutputPath, out int result, out string errorMessage)
        {

            DateTime thisDay = DateTime.Now;

            filePath = filePath + @"\TestReport_" + thisDay.ToString("d").Replace('/', '-') + ".xlsx";

            try
            {
                if (File.Exists(filePath))
                {
                    Console.WriteLine("File already exists!");
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, thisDay.ToString("T"), failMode, testResult, testLimits);
                }
                else
                {
                    Console.WriteLine("Creating file!");
                    CreateSpreadsheet(filePath, imagePath, stationName);
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, thisDay.ToString("T"), failMode, testResult, testLimits);
                }
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
            var yieldData = ws.Cell("J1");
            var versionTitle = ws.Cell("C2");

            //Range vars
            var headerColumns = ws.Columns("B:I");
            var statiticsColumns = ws.Columns("J:L");
            var filterRange = ws.Range("B4", "G4");
            var headerRow = ws.Row(4);
            var statiticsHeader = ws.Range("J10:L10");

            //Vars
            string version = "ezTestReport v1.0.0";

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
            ws.Cell("F4").SetValue("Hour");
            ws.Cell("G4").SetValue("Failure");
            ws.Cell("H4").SetValue("Result");
            ws.Cell("I4").SetValue("Limits");

            filterRange.SetAutoFilter();

            //Statitics Style

            statiticsColumns.Width = 20;
            statiticsHeader.Merge();

            ws.Cell("J6").SetValue("Units Processed: ").Style.Font.SetBold();
            ws.Cell("J6").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("K6").SetValue(1);

            ws.Cell("J7").SetValue("Pass").Style.Font.SetBold();
            ws.Cell("J7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("J7").Style.Fill.BackgroundColor = XLColor.Green;
            ws.Cell("K7").SetValue(0);

            ws.Cell("J8").SetValue("Fail").Style.Font.SetBold();
            ws.Cell("J8").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("J8").Style.Fill.BackgroundColor = XLColor.Red;
            ws.Cell("K8").SetValue(0);

            ws.Cell("J10").SetValue("Daily Failures").Style.Font.SetBold();
            ws.Cell("J10").Style.Fill.BackgroundColor = XLColor.Amber;
            ws.Cell("J11").SetValue("Partnumber").Style.Font.SetBold();
            ws.Cell("K11").SetValue("Failure").Style.Font.SetBold();
            ws.Cell("L11").SetValue("Appereances").Style.Font.SetBold();

            wb.SaveAs(filePath);

            Console.WriteLine("File created!");

            wb.Dispose();
        }
        private static void AddToRow(string filePath, string serialNumber, string partNumber,
            string passCount, string testStatus, string testDate, string failMode, string testResult, string testLimits)
        {
            using (var wb = new XLWorkbook(filePath))
            {
                //Vars
                int passUnits = 0;
                int failUnits = 0;
                int processedUnits = 0;
                int yieldPercent = 0;

                var ws = wb.Worksheet("Reports");

                var referenceColumn = ws.Column("B");

                int lastRow = referenceColumn.LastCellUsed().Address.RowNumber;
                

                lastRow = lastRow + 1;

                //Update Table
                ws.Cell(lastRow, 2).SetValue(serialNumber);
                ws.Cell(lastRow, 3).SetValue(partNumber);
                ws.Cell(lastRow, 4).SetValue(passCount);
                ws.Cell(lastRow, 5).SetValue(testStatus);
                ws.Cell(lastRow, 6).SetValue(testDate);
                ws.Cell(lastRow, 7).SetValue(failMode);
                ws.Cell(lastRow, 8).SetValue(testResult);
                ws.Cell(lastRow, 9).SetValue(testLimits);


                processedUnits = lastRow - 4;

                ws.Cell("K6").SetValue(processedUnits);

                //Update Statitics
                if (testStatus == "P")
                {
                    passUnits = Int32.Parse(ws.Cell("K7").Value.ToString());
                    passUnits = passUnits + 1;
                    ws.Cell("K7").SetValue(passUnits);
                }
                else if (testStatus == "F")
                {
                    failUnits = Int32.Parse(ws.Cell("K8").Value.ToString());
                    failUnits = failUnits + 1;
                    ws.Cell("K8").SetValue(failUnits);

                    if (ws.Cell("J12").IsEmpty())
                    {
                        ws.Cell(12, 10).SetValue(partNumber);
                        ws.Cell(12, 11).SetValue(failMode);
                        ws.Cell(12, 12).SetValue(1);
                    }
                    else
                    {
                        List<string> failModes = new List<string>();

                        var failModeColumn = ws.Range("K12", "K32");


                        int firstRowFailMode = failModeColumn.FirstCell().Address.RowNumber;
                        int lastRowFailMode = failModeColumn.LastCellUsed().Address.RowNumber;

                        for (int row = firstRowFailMode; row <= lastRowFailMode; row++)
                        {
                            string cell = "K" + row; 
                            failModes.Add(ws.Cell(cell).Value.ToString());
                        }

                        if (failModes.Contains(failMode))
                        {
                            ws.Cell(lastRowFailMode,12).SetValue(Int32.Parse(ws.Cell(lastRowFailMode,12).Value.ToString()) + 1);
                        } else
                        {
                            ws.Cell(lastRowFailMode + 1, 10).SetValue(partNumber);
                            ws.Cell(lastRowFailMode + 1, 11).SetValue(failMode);
                            ws.Cell(lastRowFailMode + 1, 12).SetValue(1);
                        }
                    }
                }

                //Update Yield
                yieldPercent = (passUnits * 100) / processedUnits;

                ws.Cell("J1").SetValue("YIELD " + yieldPercent + "%");

                wb.SaveAs(filePath);
                wb.Dispose();

                Console.WriteLine("Data appended!");

            }
        }
    }
}

/*goin' hard*/