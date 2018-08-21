using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelToSQL
{
    class ExcelReader
    {

        // Determines whether or not to print values to console for testing
        private const bool DEBUG_MODE = false;

        // Private Excel object fields
        private Excel.Application xlApp = null;
        private Excel.Workbook xlWorkbook = null;

        // Constructor
        public ExcelReader(string filePath)
        {

            // Throws a FileNotFoundException if the file doesn't exist
            if (!System.IO.File.Exists(filePath))
            {
                throw new System.IO.FileNotFoundException(
                    "No Excel file exists at the given path!", filePath);
            }

            // Opens the workbook at the given path
            xlApp = new Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(filePath, 0, true);

        }

        // Destructor
        ~ExcelReader()
        {
            if(xlWorkbook != null && xlApp != null)
            {
                // Close the Workbook and Excel app
                xlWorkbook.Close(false, null, null);
                xlApp.Quit();

                // Release Excel COM objects
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                xlWorkbook = null;
                xlApp = null;
            }
        }

        // Returns a 2D string array containing used cell data of the given worksheet
        public string[,] getCellText(int worksheetNum = 1)
        {

            // Throws an Exception if the given Worksheet number doesn't exist
            int numWorksheets = xlWorkbook.Sheets.Count;
            if(worksheetNum < 1 || worksheetNum > numWorksheets)
            {
                throw new Exception("No Worksheet exists at the given index!");
            }

            // Gets the used cell range from the Worksheet
            Excel.Worksheet xlSheet = xlWorkbook.Sheets[worksheetNum];
            Excel.Range xlRange = xlSheet.UsedRange;

            int usedColumn = xlRange.Columns.Count;
            int usedRow = xlRange.Rows.Count;

            // Debug output
            if (DEBUG_MODE)
            {
                Console.WriteLine("Used Column: " + usedColumn);
                Console.WriteLine("Used Row: " + usedRow);
            }

            int maxColumn = 0;
            int maxRow = 0;

            // Determines the actual maximum indexes used in the range
            for (int i = 1; i <= usedColumn; ++i)
            {
                for (int j = 1; j <= usedRow; j++)
                {
                    if (xlRange.Cells[j, i].Text != "")
                    {
                        if (i > maxColumn) maxColumn = i;
                        if (j > maxRow) maxRow = j;
                    }
                }
            }

            // Debug output
            if (DEBUG_MODE)
            {
                Console.WriteLine("Max Coumn: " + maxColumn);
                Console.WriteLine("Max Row: " + maxRow);
            }

            // Sheet COM object cleanup
            Marshal.ReleaseComObject(xlSheet);
            xlSheet = null;

            // Create 2D string array to be returned
            string[,] cellData = new string[maxRow, maxColumn];

            // Fill the array with cell data
            for(int i = 1; i <= maxColumn; ++i)
            {
                for(int j = 1; j <= maxRow; ++j)
                {
                    cellData[j - 1, i - 1] = xlRange.Cells[j, i].Text;
                    if(DEBUG_MODE) Console.WriteLine(cellData[j - 1, i - 1]);
                }
            }

            return cellData;

        }

    }
}
