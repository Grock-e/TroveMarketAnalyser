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

        public PriceValueReader(List<Point>[] referenceNumbersList)
        {
            ReferenceNumbersList = referenceNumbersList;
        }

        public override char[] FindValues(Point initialPoint, Bitmap screenBitmap)
        {
            throw new NotImplementedException();
        }

        protected override double ComparePixelSet(int compareNumber, Point initialPoint, Bitmap screenBitmap)
        {
            throw new NotImplementedException();
        }
    }
}
