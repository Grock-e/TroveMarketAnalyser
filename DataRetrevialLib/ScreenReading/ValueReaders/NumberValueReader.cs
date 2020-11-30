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

            Point initialPoint = new Point(0, 0);

            char[] output = new char[4];
            for (int i = 0; i < 4; i++)
            {
                output[i] = FindValueAtPosition(initialPoint, binaryBitmapOfNumbers);

                if (output[i] == '1' || output[i] == '5')
                {
                    initialPoint.X += 17;
                }
                else if (output[i] == '2' || output[i] == '6' || output[i] == '9')
                {
                    initialPoint.X += 19;
                }
                else
                {
                    initialPoint.X += 18;
                }
            }

            return output;
        }

        
        // returns the score for the probability that the bitmap number is compareNumber
        protected override double ComparePixelSet(int compareNumber, Point initialPoint, Bitmap bitmapOfNumbers)
        {
            double score = 0;

            foreach(Point p in ReferenceNumbersList[compareNumber])
            {
                if(bitmapOfNumbers.GetPixel(initialPoint.X + p.X, initialPoint.Y + p.Y).R > 200)
                {
                    score++;
                }
            }
            return score / ReferenceNumbersList[compareNumber].Count;       
        }
    }
}
