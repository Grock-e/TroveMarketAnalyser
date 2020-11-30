using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorageLib
{
    public class StorageManager
    {
        private int FreeColumn { get; set; }

        public StorageManager(ExcelModel excelModel)
        {
            FindOpenColumn(excelModel);
        }

        private void FindOpenColumn(ExcelModel excelModel)
        {
            int count = 0;
            bool valid = false;
            while(valid == false)
            {
                if(excelModel.ReadCell(0, count) == "")
                {
                    valid = true;
                }
                else
                {
                    count += 2;
                }
            }

            FreeColumn = count;
        }

        public void StoreData(ExcelModel excelModel, List<string> prices, List<string> itemNumbers)
        {
            int dayNumber = 1;
            if (FreeColumn > 0)
            {
                 dayNumber = int.Parse(excelModel.ReadCell(0, FreeColumn - 2)) + 1;
            }

            

            excelModel.WriteToCell(0, FreeColumn, dayNumber.ToString());

            for(int i = 0; i < prices.Count; i++)
            {
                excelModel.WriteToCell(i+1, FreeColumn, prices[i]);
            }

            for(int i = 0; i < itemNumbers.Count; i++)
            {
                excelModel.WriteToCell(i + 1, FreeColumn+1, itemNumbers[i]);
            }

            excelModel.Save();
        }

    }
}
