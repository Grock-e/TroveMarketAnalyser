using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OCRLib
{
    public class GroupDefinitionModelCreator
    {
        public GroupDefinitionModel CreateGroupDefinitionModel(Bitmap pixelGroupBitmap)
        {
            ImageInterpreter imageInterpreter = new ImageInterpreter();
            ProbabilityCalculator probabilityCalculator = new ProbabilityCalculator();

            double[] horizontalDensities = imageInterpreter.CalculateHorisontalDensities(pixelGroupBitmap);
            double[] verticleDensities = imageInterpreter.CaculateVerticleDensities(pixelGroupBitmap);

            return new GroupDefinitionModel
            {
                Weight = imageInterpreter.CalculateWeight(pixelGroupBitmap),
                HorizontalDensity = imageInterpreter.FindTotalDensity(horizontalDensities),
                VerticleDensity = imageInterpreter.FindTotalDensity(verticleDensities),
                HorizontalVariance = probabilityCalculator.CalculateVariance(horizontalDensities, imageInterpreter.FindTotalDensity(horizontalDensities)),
                VerticleVariance = probabilityCalculator.CalculateVariance(verticleDensities, imageInterpreter.FindTotalDensity(verticleDensities))
            };
        }
    }
}
