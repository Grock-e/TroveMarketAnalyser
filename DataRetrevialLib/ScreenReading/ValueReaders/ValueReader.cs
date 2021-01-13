using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Threading;

namespace DataRetrevialLib
{
    public abstract class ValueReader
    {

        // case statement to find the specified character from the predicted number
        protected char GetCharFromNum(int number)
        {
            switch (number)
            {
                case 0:
                    return '0';
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                default:
                    return '9';
            }
        }

        protected Bitmap CreateCharacterBitmap(Bitmap originalBitmap, int startingX, int newWidth, int newHeight, out int whiteCount)
        {
            Bitmap UCBitmap = new Bitmap(18, 24);
            whiteCount = 0;
            for (int i = 0; i < newWidth; i++)
            {
                for (int j = 0; j < newHeight; j++)
                {
                    Color pixelColor = originalBitmap.GetPixel(startingX + i, j);
                    UCBitmap.SetPixel(i, j, pixelColor);

                    if (pixelColor.R == 255)
                    {
                        whiteCount++;
                    }
                }
            }

            return UCBitmap;
        }

        // returns the score for the probability that the bitmap number is compareNumber
        protected double ComparePixelSet(List<Point>[] referenceList, int compareNumber, int whiteNumber, Bitmap UCBitmap)
        {
            double match = 0;
            double difference = whiteNumber;

            foreach (Point p in referenceList[compareNumber])
            {
                if (UCBitmap.GetPixel(p.X, p.Y).R == 255)
                {
                    match++;
                    difference--;
                }
            }

            double score = match / referenceList[compareNumber].Count - difference / whiteNumber;

            if (score >= 0)
            {
                return score;
            }
            else
            {
                return 0.0;
            }
        }

        // returns the predicted char for specified position on the textBitmap
        protected char FindValueAtPosition(List<Point>[] referenceList, Bitmap UCBitmap, int whiteCount)
        {
            char output = ' ';

            //Bitmap UCBitmap = CreateCharacterBitmap(textBitmap, initialPoint, 18, 24, out int whiteCount);

            double[] valueScores = new double[10];
            for (int i = 0; i < 10; i++)
            {
                valueScores[i] = ComparePixelSet(referenceList, i, whiteCount, UCBitmap);
            }

            if (valueScores.Max() < 0.5)
            {
                return output;
            }

            for (int i = 0; i < 10; i++)
            {
                if (valueScores[i] == valueScores.Max())
                {
                    output = GetCharFromNum(i);
                    break;
                }
            }

            return output;
        }

        // abstract methods to be overwriten by the Number and Price value readers
        public abstract char[] FindValues(Point initialPoint, Bitmap screenBitmap);

        protected abstract Bitmap GetBinaryBitmapOfText(Point initialPoint, Bitmap screenBitmap);
    }
}
