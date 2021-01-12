using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataRetrevialLib
{
    public class NumberValueReader : ValueReader
    {
        private List<Point>[] ReferenceNumbersList { get; set; }

        public NumberValueReader(List<Point>[] referenceNumbersList)
        {
            ReferenceNumbersList = referenceNumbersList;
        }

        /// <summary>
        /// predicts the values of the four number characters on the screen
        /// </summary>
        /// <param name="initialScreenPoint">the upper left point on the screenBitmap from which a binary bitmap will be captured</param>
        /// <param name="screenBitmap">a bitmap of the screen</param>
        /// <returns>a char[] of the four Number character predicted to be contained in the bitmap</returns>
        public override char[] FindValues(Point initialScreenPoint, Bitmap screenBitmap)
        {
            Bitmap binaryBitmapOfNumbers = GetBinaryBitmapOfText(initialScreenPoint, screenBitmap);

            int initialX = 0;

            char[] output = new char[4];
            for (int i = 0; i < 4; i++)
            {
                output[i] = FindValueAtPosition(ReferenceNumbersList, CreateCharacterBitmap(binaryBitmapOfNumbers, initialX, 18, 24, out int whiteCount), whiteCount);
                initialX += 18;
            }

            return output;
        }

        // Gets the binary textBitmap from the screenBitmap
        protected override Bitmap GetBinaryBitmapOfText(Point startingPoint, Bitmap screenBitmap)
        {
            BitmapFormatter bitmapFormatter = new BitmapFormatter();
            return bitmapFormatter.BinarizeImage(bitmapFormatter.ConvertToGrayScale(screenBitmap, startingPoint, 72, 24), 128);
        }

    }
}

