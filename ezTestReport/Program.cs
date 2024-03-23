/* made by leo

Autor: Leonardo Avalos
Date: 18/03/2024
Position: Test Maintenance Technician

*/


using ClosedXML;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.IO;
using System.IO.Packaging;


namespace EzTestReport
{
    public class Program
    {
        public static void Report(string filePath, string imagePath, string stationName, string serialNumber, string partNumber, string passCount,
            string testStatus, string failMode, out string fileOutputPath, out int result, out string errorMessage)
        {

            DateTime thisDay = DateTime.Today;

            filePath = filePath + @"\Log_" + thisDay.ToString("d").Replace('/', '-') + ".xlsx";

            if (File.Exists(filePath))
            {
                Console.WriteLine("File already exists!");
                try
                {
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, thisDay.ToString("G"), failMode);
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
                    AddToRow(filePath, serialNumber, partNumber, passCount, testStatus, thisDay.ToString("G"), failMode);
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

            //HeaderData

            ws.AddPicture(imagePath).MoveTo(ws.Cell("A1")).Scale(0.5);

            var headerTitle = ws.Cell("C1");
            headerTitle.SetValue(stationName + " SMY BE Test Report").Style.Font.SetBold();
            headerTitle.Style.Font.SetFontSize(36);

            var myColumns = ws.Columns("B:G");

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

            var filterRange = ws.Range("B4", "G4");
            filterRange.SetAutoFilter();

            ws.Column("L").Width = 20;
            ws.Cell("L6").Style.Fill.BackgroundColor = XLColor.Amber;
            ws.Cell("L6").SetValue("Units Processed: ").Style.Font.SetBold();
            ws.Cell("L6").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("M6").SetValue(1);
            ws.Cell("M6").Style.Fill.BackgroundColor = XLColor.AmberSaeEce;

            ws.Cell("L7").SetValue("Pass").Style.Font.SetBold();
            ws.Cell("L7").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("L7").Style.Fill.BackgroundColor = XLColor.Green;
            //ws.Cell("M7").Style.Fill.BackgroundColor = XLColor.AppleGreen;
            ws.Cell("M7").SetValue(0);

            ws.Cell("L8").SetValue("Fail").Style.Font.SetBold();
            ws.Cell("L8").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
            ws.Cell("L8").Style.Fill.BackgroundColor = XLColor.Red;
            //ws.Cell("M8").Style.Fill.BackgroundColor = XLColor.RED;
            ws.Cell("M8").SetValue(0);


            ws.Cell("L13").SetValue("YIELD").Style.Font.SetBold();
            ws.Cell("L13").SetValue("YIELD").Style.Font.SetFontSize(20);
            ws.Cell("M13").SetValue("0%").Style.Font.SetBold();
            ws.Cell("M13").SetValue("0%").Style.Font.SetFontSize(20);

            //var columns = ws.LastRowUsed().RowNumber();
            //Console.WriteLine(columns);

            wb.SaveAs(filePath);

            Console.WriteLine("File created!");
        }
        public static void AddToRow(string filePath, string serialNumber, string partNumber, string passCount, string testStatus, string testDate, string testFailure)
        {
            using (var wb = new XLWorkbook(filePath))
            {
                int cellValue = 0;
                var ws = wb.Worksheet("Reports");

                var referenceColumn = ws.Column("B");

                //int lastRow = ws.LastRowUsed().RowNumber();
                int lastRow = referenceColumn.LastCellUsed().Address.RowNumber;
                Console.WriteLine(lastRow);

                lastRow = lastRow++;

                ws.Cell(lastRow, 2).SetValue(serialNumber);
                ws.Cell(lastRow, 3).SetValue(partNumber);
                ws.Cell(lastRow, 4).SetValue(passCount);
                ws.Cell(lastRow, 5).SetValue(testStatus);
                ws.Cell(lastRow, 6).SetValue(testDate);
                ws.Cell(lastRow, 7).SetValue(testFailure);

                ws.Cell("M6").SetValue(lastRow - 4);

                if (testStatus == "P")
                {
                    cellValue = Int32.Parse(ws.Cell("M7").Value.ToString());
                    ws.Cell("M7").SetValue(cellValue + 1);
                }
                else if (testStatus == "F")
                {
                    cellValue = Int32.Parse(ws.Cell("M7").Value.ToString());
                    ws.Cell("M7").SetValue(cellValue + 1);
                }



                wb.SaveAs(filePath);

                Console.WriteLine("Data appended!");

            }
        }
    }
}

/*goin' hard*/