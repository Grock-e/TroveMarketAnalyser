﻿using System;
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
        protected List<Point>[] ReferenceNumbersList { get; set; }

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

        // returns the predicted char for specified position on the textBitmap
        protected char FindValueAtPosition(Point initialPoint, Bitmap textBitmap)
        {
            char output = 'n';
             
            double[] valueScores = new double[10];
            for (int i = 0; i < 10; i++)
            {
                valueScores[i] = ComparePixelSet(i, initialPoint, textBitmap);
            }

            if (valueScores.Max() == 0)
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

        // Gets the binary textBitmap from the screenBitmap
        protected Bitmap GetBinaryBitmapOfText(Point startingPoint, Bitmap screenBitmap)
        {
            BitmapFormatter bitmapFormatter = new BitmapFormatter();
            return bitmapFormatter.BinarizeImage(bitmapFormatter.ConvertToGrayScale(screenBitmap, startingPoint, 80, 23), 200);
        }

        // abstract methods to be overwriten by Number and Price value reader
        public abstract char[] FindValues(Point initialPoint, Bitmap screenBitmap);

        // abstract methods to be overwriten by Number and Price value reader
        protected abstract double ComparePixelSet(int compareNumber, Point initialPoint, Bitmap screenBitmap);

    }
}
