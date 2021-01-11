using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DataRetrevialLib
{
    public class ReferenceBitmapLoader
    {
        public const string PriceTextBitmapFilePath = @"ReferenceLoading\TextReferences\PriceTextReference.bmp";
        public const string NumberTextBitmapFilePath = @"ReferenceLoading\TextReferences\NumberTextReference.png";
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns>the PriceReferenceBitmap</returns>
        public Bitmap LoadPriceReferenceBitmap()
        {
            return (Bitmap)Image.FromFile(PriceTextBitmapFilePath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>the NumberReferenceBitmap</returns>
        public Bitmap LoadNumberReferenceBitmap()
        {
            return (Bitmap)Image.FromFile(NumberTextBitmapFilePath);
        }
    }
}
