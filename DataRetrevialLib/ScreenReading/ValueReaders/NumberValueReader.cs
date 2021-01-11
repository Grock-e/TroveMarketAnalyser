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
        //private int[,] MovementAmounts { get; set; } = new int[10, 10] {{19, 20, 19, 19, 18, 20, 19, 19, 19, 19 }, //0
        //                                                               {18, 19, 18, 18, 17, 19, 18, 18, 18, 18 }, //1
        //                                                               {19, 20, 19, 19, 18, 20, 19, 19, 19, 19 }, //2
        //                                                               {19, 20, 19, 19, 18, 20, 19, 19, 19, 19 }, //3
        //                                                               {20, 21, 20, 20, 19, 21, 20, 20, 20, 20 }, //4
        //                                                               {18, 19, 18, 18, 17, 19, 18, 18, 18, 18 }, //5
        //                                                               {19, 20, 19, 19, 18, 20, 19, 19, 19, 19 }, //6
        //                                                               {19, 20, 19, 19, 18, 20, 19, 19, 19, 19 }, //7
        //                                                               {19, 20, 19, 19, 18, 20, 19, 19, 19, 19 }, //8
        //                                                               {19, 20, 19, 19, 18, 20, 19, 19, 19, 19 }};//9



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
        //TODO rome this method partially and replace with 2d array method
        public override char[] FindValues(Point initialScreenPoint, Bitmap screenBitmap)
        {
            Bitmap binaryBitmapOfNumbers = GetBinaryBitmapOfText(initialScreenPoint, screenBitmap);

            Point initialPoint = new Point(0, 0);

            char[] output = new char[4];
            for (int i = 0; i < 4; i++)
            {
                output[i] = FindValueAtPosition(initialPoint, binaryBitmapOfNumbers);
                initialPoint.X += 18;
            }

            return output;
        }

        // returns the score for the probability that the bitmap number is compareNumber
        protected override double ComparePixelSet(int compareNumber, int whiteNumber, Bitmap UCBitmap)
        {
            double match = 0;
            double difference = whiteNumber;

            foreach(Point p in ReferenceNumbersList[compareNumber])
            {
                if(UCBitmap.GetPixel(p.X, p.Y).R == 255)
                {
                    match++;
                    difference--;
                }
            }

            double score = match / ReferenceNumbersList[compareNumber].Count  - difference / whiteNumber;

            if(score >= 0)
            {
                return score;
            }
            else
            {
                return 0.0;
            }
        }
    }
}

