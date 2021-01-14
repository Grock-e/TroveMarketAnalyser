using System;
using System.Collections.Generic;
using System.Threading;
using DataRetrevialLib;
using DataStorageLib;

namespace ConsoleAppController
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To begin press enter.");
            Console.ReadLine();
            Thread.Sleep(5000);

            MarketSearchController marketSearchController = new MarketSearchController();
            marketSearchController.ReadMarketPlace(StoreCollectedData);
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
    }
}
