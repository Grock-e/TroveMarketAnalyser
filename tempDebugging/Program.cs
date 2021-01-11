using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OCRLib;
using System.Drawing;

namespace tempDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            BitmapFormatter bitmapFormatter = new BitmapFormatter();

            Image test = Image.FromFile(@"C:\Users\Ewen Sharpe\OneDrive\Desktop\Reference.png");

            test = bitmapFormatter.BinarizeImage(bitmapFormatter.ConvertToGrayScale((Bitmap)test, new Point(0, 0), test.Width, test.Height), 128);
            
            test.Save(@"C:\Users\Ewen Sharpe\OneDrive\Desktop\bin.png");

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
