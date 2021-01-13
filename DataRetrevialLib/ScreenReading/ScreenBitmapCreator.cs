using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

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
            try
            {
                // Creates an empty bitmap of the screen
                Bitmap screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                // Creates a new graphics object that can capture the screen 
                Graphics screenGraphics = Graphics.FromImage(screenBitmap as Image);
                // screenshot the screen 
                screenGraphics.CopyFromScreen(0, 0, 0, 0, screenBitmap.Size);

                return screenBitmap;
            }
            catch(ArgumentException)
            {
                Thread.Sleep(100);
                // Creates an empty bitmap of the screen
                Bitmap screenBitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                // Creates a new graphics object that can capture the screen 
                Graphics screenGraphics = Graphics.FromImage(screenBitmap as Image);
                // screenshot the screen 
                screenGraphics.CopyFromScreen(0, 0, 0, 0, screenBitmap.Size);

                return screenBitmap;
            }
            catch
            {
                Console.WriteLine("Failed to take valid screenshot");
                Console.ReadLine();
                throw new Exception("Failed to take valid screenshot.");
            }
            
        }
    }
}
