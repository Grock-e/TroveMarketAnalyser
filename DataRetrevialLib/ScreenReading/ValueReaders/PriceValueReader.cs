using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetrevialLib
{
    public class PriceValueReader : ValueReader
    {

        public List<Point>[] ReferencePricesList { get; set; }

        public PriceValueReader(List<Point>[] referencePricesList)
        {
            ReferencePricesList = referencePricesList;
        }


        // TODO create a working version of this method for PriceValueReader. 
        public override char[] FindValues(Point initialScreenPoint, Bitmap screenBitmap)
        {
            throw new NotImplementedException();
            //Bitmap binaryBitmapOfNumbers = GetBinaryBitmapOfText(initialScreenPoint, screenBitmap);

            //int initialX = 0;

            //char[] output = new char[4];
            //for (int i = 0; i < 4; i++)
            //{
            //    output[i] = FindValueAtPosition(ReferencePricesList, CreateCharacterBitmap(binaryBitmapOfNumbers, initialX, 18, 24, out int whiteCount), whiteCount);
            //    initialX += 18;
            //}

            //return output;
        }

        // Gets the binary textBitmap from the screenBitmap
        protected override Bitmap GetBinaryBitmapOfText(Point startingPoint, Bitmap screenBitmap)
        {
            BitmapFormatter bitmapFormatter = new BitmapFormatter();
            return bitmapFormatter.BinarizeImage(bitmapFormatter.ConvertToGrayScale(screenBitmap, startingPoint, 162, 24), 200);
        }

        
    }
}
