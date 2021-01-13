using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace DataRetrevialLib
{
    // TODO comment this class
    public class MarketSearchController
    {
        private MarketSearcher MS { get; set; } = new MarketSearcher();
        private NumberValueReader NVR { get; set; }
        private PriceValueReader PVR { get; set; }

        public MarketSearchController()
        {
            ReferenceListLoader referenceListLoader = new ReferenceListLoader();
            ReferenceBitmapLoader referenceBitmapLoader = new ReferenceBitmapLoader();

            NVR = new NumberValueReader(referenceListLoader.LoadReferenceNumberPoints(
                referenceBitmapLoader.LoadNumberReferenceBitmap()));

            PVR = new PriceValueReader(referenceListLoader.LoadReferenceNumberPoints(
                referenceBitmapLoader.LoadPriceReferenceBitmap()));
        }

        public delegate void StoreCollectedItemData(string item, List<string> itemPriceList, List<string> itemNumberList);

        public void ReadMarketPlace(StoreCollectedItemData storeCollectedItemData)
        {
            SearchItemsLoader searchItemsLoader = new SearchItemsLoader();

            KeyInputCode[][] keyInputCodes = searchItemsLoader.LoadSearchItems();
            string[] searchItems = searchItemsLoader.LoadItemsFromFile();

            for (int i = 0; i < keyInputCodes.Length; i++)
            {
                MS.ClearItem();
                MS.EnterItem(keyInputCodes[i]);
                MS.SearchItem();
                Thread.Sleep(1300);
                ReadAllItemPages(searchItems[i], storeCollectedItemData);
            }
        }

        private string[] ReadPageTexts(Bitmap screenBitmap, Point initialPoint, ValueReader valueReader)
        {
            string[] output = new string[6];

            Point p = initialPoint;
            int count = 0;
            for(int i = 0; i < 2; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    string priceText = CharToString(valueReader.FindValues(p, screenBitmap));
                    output[count] = priceText;

                    count++;
                    p = new Point(p.X + 425, initialPoint.Y);
                }
                p = new Point(initialPoint.X, p.Y + 542);
            }

            return output;
        }

        private string CharToString(char[] chars)
        {
            StringBuilder sB = new StringBuilder();
            foreach (char c in chars)
            {
                sB.Append(c);
            }

            return sB.ToString();
        }

        private bool IsNextPageValid(Bitmap screenBitmap)
        {
            if (ColorTranslator.ToHtml(screenBitmap.GetPixel(2190, 1294)) == "#35CA6D")
            {
                return true;
            }
            return false;
        }

        private void ReadAllItemPages(string item, StoreCollectedItemData storeCollectedItemData)
        {
            ScreenBitmapCreator screenBitmapCreator = new ScreenBitmapCreator();
            List<string> allItemNumbers = new List<string>();
            List<string> allItemPrices = new List<string>();

            int cnt = 0;
            bool isNextPage;
            do
            {
                Thread.Sleep(80);
                Bitmap screenBitmap = screenBitmapCreator.CreateScreenBitmap();

                string[] pageNumbers = ReadPageTexts(screenBitmap, new Point(994, 515), NVR);
                string[] pagePrices = ReadPageTexts(screenBitmap, new Point(1089, 599), PVR);

                for (int i = 0; i < 6; i++)
                {
                    allItemNumbers.Add(pageNumbers[i]);
                    allItemPrices.Add(pagePrices[i]);
                }

                isNextPage = IsNextPageValid(screenBitmap);
                cnt++;


                MS.GoToNextPage();
            } while (isNextPage);

            storeCollectedItemData(item, allItemPrices, allItemNumbers);
        }
    }
}
