/* made by leo

Title: EzTestReport
Autor: Leonardo Avalos
Date: 18/03/2024
Position: Test Maintenance Technician

*/


using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Packaging;



namespace EzTestReport
{
    public class Program
    {
        public static void Report(string filePath, string imagePath, string stationName, string serialNumber, string partNumber, string passCount,
            string testStatus, string failMode, string testResult, string testLimits, out string fileOutputPath, out int result, out string errorMessage)
        {

            DateTime thisDay = DateTime.Today;

            filePath = filePath + @"\TestReport_" + thisDay.ToString("d").Replace('/', '-') + ".xlsx";

            if (File.Exists(filePath))
            {
                Console.WriteLine("File already exists!");
                try
                {
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, thisDay.ToString("G"), failMode, testResult, testLimits);
                }
                catch (System.IO.IOException)
                {

                    errorMessage = "File busy!";
                    result = 0;
                    throw;
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("Creating file!");
                    CreateSpreadsheet(filePath,imagePath, stationName);
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, thisDay.ToString("G"), failMode, testResult, testLimits);
                }
                catch (Exception)
                {
                    errorMessage = "Error during file creation!";
                    result = 0;
                    throw;
                }

            }
            result = 1;
            errorMessage = "null";
            fileOutputPath = filePath;

        }
        public static void CreateSpreadsheet(string filePath, string imagePath, string stationName)
        {
            var wb = new XLWorkbook();

            var ws = wb.Worksheets.Add("Reports");

            string version = "ezTestReport v1.0.0";

            //HeaderData

            ws.AddPicture(imagePath).MoveTo(ws.Cell("A1")).Scale(0.6);

            var headerTitle = ws.Cell("C1");
            headerTitle.SetValue(stationName + " AM & AN BE Test Report").Style.Font.SetBold();
            headerTitle.Style.Font.SetFontSize(36);

            ws.Cell("L1").SetValue("YIELD 0%").Style.Font.SetBold();
            ws.Cell("L1").Style.Font.SetFontSize(20);

            var versionTitle = ws.Cell("C2");
            versionTitle.SetValue(version).Style.Font.SetFontSize(10);
            versionTitle.Style.Font.SetItalic();

            var myColumns = ws.Columns("B:I");

            myColumns.Width = 20;

            var headerRow = ws.Row(4);
            headerRow.Style.Fill.BackgroundColor = XLColor.Gray;
            headerRow.Style.Font.SetFontColor(XLColor.White);

            ws.Cell("B4").SetValue("SerialNumber");
            ws.Cell("C4").SetValue("PartNumber");
            ws.Cell("D4").SetValue("PassCount");
            ws.Cell("E4").SetValue("TestStatus");
            ws.Cell("F4").SetValue("Date");
            ws.Cell("G4").SetValue("Failure");
            ws.Cell("H4").SetValue("Result");
            ws.Cell("I4").SetValue("Limits");

            var filterRange = ws.Range("B4", "G4");
            filterRange.SetAutoFilter();

            //Statitics

            ws.Column("J").Width = 20;
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

            ws.Column("M").Width = 20;
            ws.Cell("M6").SetValue("Daily Failures").Style.Font.SetBold();
            ws.Cell("M6").Style.Fill.BackgroundColor = XLColor.Amber;
            ws.Cell("M7").SetValue("Partnumber").Style.Font.SetBold();
            ws.Cell("N7").SetValue("Failure").Style.Font.SetBold();
            ws.Cell("O7").SetValue("Appereances").Style.Font.SetBold();

            wb.SaveAs(filePath);

            Console.WriteLine("File created!");
        }
        public static void AddToRow(string filePath, string serialNumber, string partNumber,
            string passCount, string testStatus, string testDate, string failMode, string testResult, string testLimits)
        {
            using (var wb = new XLWorkbook(filePath))
            {
                int cellValue = 0;
                var ws = wb.Worksheet("Reports");

                var referenceColumn = ws.Column("B");

                //int lastRow = ws.LastRowUsed().RowNumber();
                int lastRow = referenceColumn.LastCellUsed().Address.RowNumber;
                //Console.WriteLine(lastRow);
                int dailyFailureRow = ws.Column("M").LastCellUsed().Address.RowNumber;


                lastRow = lastRow + 1;
                dailyFailureRow = dailyFailureRow + 1;

                ws.Cell(lastRow, 2).SetValue(serialNumber);
                ws.Cell(lastRow, 3).SetValue(partNumber);
                ws.Cell(lastRow, 4).SetValue(passCount);
                ws.Cell(lastRow, 5).SetValue(testStatus);
                ws.Cell(lastRow, 6).SetValue(testDate);
                ws.Cell(lastRow, 7).SetValue(failMode);
                ws.Cell(lastRow, 8).SetValue(testResult);
                ws.Cell(lastRow, 9).SetValue(testLimits);

                ws.Cell("K6").SetValue(lastRow - 4);

                if (testStatus == "P")
                {
                    cellValue = Int32.Parse(ws.Cell("K7").Value.ToString());
                    ws.Cell("K7").SetValue(cellValue + 1);
                }
                else if (testStatus == "F")
                {
                    cellValue = Int32.Parse(ws.Cell("K7").Value.ToString());
                    ws.Cell("K7").SetValue(cellValue + 1);

                    //if (ws.Cell("M8").IsEmpty() == false)
                    //{
                    //    var failRange = ws.Range("M8:");

                    //    if ()
                    //    {

                        //}

                    //}
                }



                wb.SaveAs(filePath);

                Console.WriteLine("Data appended!");

            }
        }
    }
}

/*goin' hard*/