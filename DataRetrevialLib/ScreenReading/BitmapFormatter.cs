using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace DataRetrevialLib
{
    public class BitmapFormatter
    {
        /// <summary>
        /// Converts a colured bitmap to a grayscale bitmap
        /// </summary>
        /// <param name="originalBitmap">the source bitmap to be copied from</param>
        /// <param name="startingPoint">the upper left most point that will be copied</param>
        /// <param name="width">the horizontal distance right from the starting point for which pixels will be copied</param>
        /// <param name="height">the verticle distance down from the starting point for which pixels will be copied</param>
        /// <returns>Copy of the originalBitmap containing no color information</returns>
        public Bitmap ConvertToGrayScale(Bitmap originalBitmap, Point startingPoint, int width, int height)
        {
            Bitmap newBitmap = new Bitmap(width, height);

            Graphics g = Graphics.FromImage(newBitmap);

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                {
                    new float[] {0.3f, 0.3f, 0.3f, 0, 0 },
                    new float[] {0.59f, 0.59f, 0.59f, 0, 0 },
                    new float[] {0.11f, 0.11f, 0.11f, 0, 0 },
                    new float[] {0, 0, 0, 1, 0 },
                    new float[] {0, 0, 0, 0, 1 }
                });

            ImageAttributes attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(originalBitmap, new Rectangle(0, 0, width, height),
                startingPoint.X, startingPoint.Y, width, height, GraphicsUnit.Pixel, attributes);

            g.Dispose();

            return newBitmap;
        }

        /// <summary>
        /// seperates pixels into two groups based on whether their grayscale value is <= threashholdValue or not
        /// </summary>
        /// <param name="originalBitmap">the bitmap to be binarized</param>
        /// <param name="threashholdValue">the grayscale value that splits the pixels</param>
        /// <returns>Copy of the originalBitmap containing only black and white pixels</returns>
        public Bitmap BinarizeImage(Bitmap originalBitmap, int threashholdValue)
        {
            Bitmap binarized = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            for (int i = 0; i < originalBitmap.Width; i++)
            {
                for (int j = 0; j < originalBitmap.Height; j++)
                {
                    if(originalBitmap.GetPixel(i, j).R <= threashholdValue)
                    {
                        binarized.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        binarized.SetPixel(i, j, Color.White);
                    }
                    
                }
            }

            return binarized;
        }
    }
}
