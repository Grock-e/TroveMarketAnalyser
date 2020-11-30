using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace OCRLib
{
    public class ImageInterpreter
    {
        public double CalculateWeight(Bitmap pixelGroup)
        {
            double weight = 0;

            for(int i = 0; i < pixelGroup.Width; i++)
            {
                for(int j = 0; j < pixelGroup.Height; j++)
                {
                    if(pixelGroup.GetPixel(i, j) == Color.White)
                    {
                        weight++;
                    }
                }
            }

            return weight;
        }

        public double[] CalculateHorisontalDensities(Bitmap pixelGroup)
        {
            double[] densities = new double[pixelGroup.Width];
            for (int i = 0; i < pixelGroup.Width; i++)
            {
                double columnDensity = 0;
                for (int j = 0; j < pixelGroup.Height; j++)
                {
                    if (pixelGroup.GetPixel(i, j) == Color.White)
                    {
                        columnDensity++;
                    }
                }

                densities[i] = columnDensity;
            }

            return densities;
        }

        public double[] CaculateVerticleDensities(Bitmap pixelGroup)
        {
            double[] densities = new double[pixelGroup.Height];
            for(int j = 0; j < pixelGroup.Height; j++)
            {
                double rowDensity = 0;
                for(int i = 0; i < pixelGroup.Height; i++)
                {
                    if (pixelGroup.GetPixel(i, j) == Color.White)
                    {
                        rowDensity++;
                    }
                }

                densities[j] = rowDensity;
            }
            return densities;
        }

        public double FindTotalDensity(double[] densities)
        {
            double totalDensity = 0;
            for (int i = 0; i < densities.Length; i++)
            {
                totalDensity += densities[i] * i;
            }
            return totalDensity;
        }

    }
}        
