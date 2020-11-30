using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRLib
{
    public class GroupDefinitionModel
    {
        public double Weight { get; set; }

        public double HorizontalDensity { get; set; }

        public double VerticleDensity { get; set; }

        public double HorizontalVariance { get; set; }

        public double VerticleVariance { get; set; }
        public int GroupHeight { get; set; }
        public int GroupWidth { get; set; }

    }
}
