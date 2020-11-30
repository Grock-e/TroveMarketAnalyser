using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataStorageLib
{
    public class ExcelFileLoader
    {
        //public string[] LoadFilesList()
        //{
        //    return Directory.GetFiles(@"\StorageFiles");
        //}

        public string FindFilename(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public ExcelModel LoadExcelFile(string fileName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return new ExcelModel($@"{currentDirectory}\StorageFiles\{fileName}.xlsx");
        }

        public ExcelModel CreateNewExcelFile(string fileName)
        {
            ExcelModel output = new ExcelModel();
            output.CreateNewFile();
            //output.CreateNewSheet();

            string currentDirectory = Directory.GetCurrentDirectory();
            output.SaveAs($@"{currentDirectory}\StorageFiles\{fileName}.xlsx");

            return output;
        }

    }
}
