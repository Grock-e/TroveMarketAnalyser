using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRLib
{
    public class OCRManager
    {
        public double FindEquivilanceProbability(GroupDefinitionModel knownGDM, GroupDefinitionModel unknownGDM)
        {
            ProbabilityCalculator pC = new ProbabilityCalculator();
            int weightLimmit = unknownGDM.GroupHeight * unknownGDM.GroupWidth;

            return 
                (
                pC.CalculateDifferenceProbability(knownGDM.HorizontalVariance, unknownGDM.HorizontalVariance, unknownGDM.GroupWidth*(unknownGDM.GroupWidth - 1)*(unknownGDM.GroupWidth - 1)) + // fix the varience probabilities
                pC.CalculateDifferenceProbability(knownGDM.VerticleVariance, unknownGDM.VerticleVariance, unknownGDM.GroupHeight * (unknownGDM.GroupHeight - 1) * (unknownGDM.GroupHeight - 1)) + 
                pC.CalculateDifferenceProbability(knownGDM.HorizontalDensity, unknownGDM.HorizontalDensity, unknownGDM.GroupWidth) + 
                pC.CalculateDifferenceProbability(knownGDM.VerticleDensity, unknownGDM.VerticleDensity, unknownGDM.GroupHeight) + 
                pC.CalculateDifferenceProbability(knownGDM.Weight, unknownGDM.Weight, weightLimmit)
                ) / 5;  
        } 
           
        public double FindMostLikelyNumber(double[] numberProbabilities)
        {
            double max = numberProbabilities.Max();
            for(int i = 0; i < numberProbabilities.Length; i++)
            {
                if(numberProbabilities[i] == max)
                {
                    return i;
                }
            }

            return 0;
        }

    }
}
