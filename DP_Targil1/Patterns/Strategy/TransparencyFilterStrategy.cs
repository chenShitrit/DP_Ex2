using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace DP_Targil1.Patterns.Strategy
{
    public class TransparencyFilterStrategy : IColorMatrixStrategy
    {
        public ColorMatrix CreateColorMatrix()
        {
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                    {
                        new float[] { 1, 0, 0, 0, 0 },
                        new float[] { 0, 1, 0, 0, 0 },
                        new float[] { 0, 0, 1, 0, 0 },
                        new float[] { 0, 0, 0, 0.3f, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

            return colorMatrix;
        }
    }
}
