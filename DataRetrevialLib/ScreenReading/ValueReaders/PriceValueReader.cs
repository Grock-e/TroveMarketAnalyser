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

        public override char[] FindValues(Point initialScreenPoint, Bitmap screenBitmap)
        {
            //GetBinaryBitmapOfText(initialScreenPoint, screenBitmap).Save(@"C:\Users\Ewen Sharpe\OneDrive\Desktop\binarycheck.png");

            Bitmap binaryBitmapOfPrices = GetBinaryBitmapOfText(initialScreenPoint, screenBitmap);
            
            int[] xPositions = new int[8] { 71, 81, 89, 103, 112, 121, 135, 143 };

            char final = ' ';
            int count = -1;

            for (int i = 7; i >= 0; i--)
            {
                //CreateCharacterBitmap(binaryBitmapOfPrices, xPositions[i], 18, 24, out _).Save($@"C:\Users\Ewen Sharpe\OneDrive\Desktop\check{8-i}.png");

                final = FindValueAtPosition(ReferencePricesList, CreateCharacterBitmap(binaryBitmapOfPrices, xPositions[i], 18, 24, out int whiteCount), whiteCount);
                if (final != ' ')
                {
                    count = i;
                    break;
                } 
            }

            if(count == -1)
            {
                return new char[1] {' '};
            }


            char[] output = new char[count + 1];
            output[count] = final;
            int initialX = xPositions[count] - 18;
            int threeCount = 1;
            for(int i = count - 1; i >= 0; i--)
            {
                if (initialX < 0)
                {
                    initialX = 0;
                }

                //CreateCharacterBitmap(binaryBitmapOfPrices, initialX, 18, 24, out _).Save($@"C:\Users\Ewen Sharpe\OneDrive\Desktop\numcheck{count - i}.png");

                output[i] = FindValueAtPosition(ReferencePricesList, CreateCharacterBitmap(binaryBitmapOfPrices, initialX, 18, 24, out int whiteCount), whiteCount);
                threeCount++;

                if (threeCount % 3 == 0)
                {
                    initialX -= 9;
                }
                initialX -= 18;

                
            }

            return output;
        }



        // Gets the binary textBitmap from the screenBitmap
        protected override Bitmap GetBinaryBitmapOfText(Point startingPoint, Bitmap screenBitmap)
        {
            BitmapFormatter bitmapFormatter = new BitmapFormatter();
            return bitmapFormatter.BinarizeImage(bitmapFormatter.ConvertToGrayScale(screenBitmap, startingPoint, 162, 24), 200);
        }

        
    }
}
