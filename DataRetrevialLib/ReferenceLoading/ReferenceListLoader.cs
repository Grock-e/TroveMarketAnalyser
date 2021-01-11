using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRetrevialLib
{
    public class ReferenceListLoader
    {
        /// <summary>
        /// loads the key points which define a charater for the text into an array of points for each character
        /// </summary>
        /// <param name="referenceBitmap">the bitmap from which the keyPoints will be loaded</param>
        /// <returns>List<Point>[] of all key points for each integer 0 to 9</returns>
        public List<Point>[] LoadReferenceNumberPoints(Bitmap referenceBitmap)
        {
            List<Point>[] output = new List<Point>[10];
            for(int i = 0; i < 10; i++)
            {
                output[i] = LoadKeyPoints(i, 18, referenceBitmap);
            }

            return output;
        }

        // laods the points of white pixels from a referenceBitmap and returns a list of the Ponts
        private List<Point> LoadKeyPoints(int desiredNumber, int textWidth, Bitmap referenceBitmap)
        {
            List<Point> output = new List<Point>();

            for (int x = 0; x < textWidth; x++)
            {
                for(int y = 0; y < referenceBitmap.Height; y++)
                {
                    if (referenceBitmap.GetPixel(x + desiredNumber*textWidth, y).R == 255)
                    {
                        output.Add(new Point(x, y));
                    }
                }
            }
            return output;
        }

    }
}
