using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataRetrevialLib;
using DataStorageLib;
using MarketAnalyserLibrary;

namespace ConsoleAppController
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To begin press enter.");
            Console.ReadLine();
            Thread.Sleep(5000);
            Stopwatch s = new Stopwatch();
            s.Start();


            MarketSearchController marketSearchController = new MarketSearchController();
            marketSearchController.ReadMarketPlace(StoreCollectedData);


            s.Stop();
            Console.WriteLine(s.ElapsedMilliseconds);
            Console.WriteLine("Finished. ");
            Console.ReadLine();
        }

        private static void StoreCollectedData(string item, List<string> itemPrices, List<string> itemNumbers)
        {
            ExcelModel excelModel = GetExcelModel(item);

            StorageManager storageManager = new StorageManager(excelModel);
            storageManager.StoreData(excelModel, itemPrices, itemNumbers);

            excelModel.Close();
        }
        
        private static ExcelModel GetExcelModel(string fileName)
        {
            ExcelFileLoader excelFileLoader = new ExcelFileLoader();
            try
            {
                return excelFileLoader.LoadExcelFile(fileName);
            }
            catch
            {
                return excelFileLoader.CreateNewExcelFile(fileName);
            }
        }

        //private static void GetPoint()
        //{
        //    Console.ReadLine();
        //    Thread.Sleep(5000);

        //    MouseController mc = new MouseController();

        //    Point p = mc.GetCursorPosition();
        //    Console.WriteLine($"({p.X}, {p.Y})");
        //}
    }
}
