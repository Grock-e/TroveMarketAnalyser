using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace DataStorageLib
{
    public class ExcelModel
    {
        private string FilePath { get; set; }
        private _Application Excel { get; set; } = new _Excel.Application();

        private Workbook WorkBook { get; set; }
        private Worksheet WorkSheet { get; set; }

        public ExcelModel()
        {

        }

        public ExcelModel(string filePath)
        {
            FilePath = filePath;
            WorkBook = Excel.Workbooks.Open(FilePath);
            WorkSheet = WorkBook.Worksheets[1];

        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (WorkSheet.Cells[i, j].Value2 != null)
            {
                dynamic cellVar = WorkSheet.Cells[i, j].Value2;
                return cellVar.ToString();
            }
            else
            {
                return "";
            }

        }

        public void WriteToCell(int i, int j, string input)
        {
            i++;
            j++;

            WorkSheet.Cells[i, j].Value2 = input;
        }

        public void Save()
        {
            WorkBook.Save();
        }

        public void Close()
        {
            WorkBook.Close();
        }

        public void CreateNewFile()
        {
            WorkBook = Excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            WorkSheet = WorkBook.Worksheets[1];
        }

        //public void CreateNewSheet()
        //{
        //    WorkBook.Worksheets.Add(After: WorkSheet);
        //}

        public void SaveAs(string path)
        {
            WorkBook.SaveAs(path);
        }
    }
}