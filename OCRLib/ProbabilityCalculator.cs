using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRLib
{
    public class ProbabilityCalculator
    {
        public double CalculateVariance(double[] densities, double mean)
        {
            double varience = 0;
            for(int i = 0; i < densities.Length; i++)
            {
                varience += (i - mean) * (i - mean) * densities[i] / densities.Length;
            }

            return varience;
        }

        public double CalculateDifferenceProbability(double realValue, double variableValue, int upperLimmit)
        {
            return 1 - Math.Abs(realValue - variableValue) / upperLimmit;
        }
    }
}
