using System;
using System.Drawing;
using System.Windows.Forms;

namespace DataRetrevialLib
{
    public class ScreenBitmapCreator
    {
        /// <summary>
        /// captures the screen on a bitmap
        /// </summary>
        /// <returns>screenshot bitmap</returns>
        public Bitmap CreateScreenBitmap()
        {
            // Creates an empty bitmap of the screen
            Bitmap screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // Creates a new graphics object that can capture the screen 
            Graphics screenGraphics = Graphics.FromImage(screenBitmap);
            // screenshot the screen 
            screenGraphics.CopyFromScreen(0, 0, 0, 0, screenBitmap.Size);
            screenGraphics.Dispose();

            //screenBitmap.Save(@"C:\Users\Ewen Sharpe\OneDrive\Desktop\screenshotCheck.png");

            return screenBitmap;           
        }
    }
}
