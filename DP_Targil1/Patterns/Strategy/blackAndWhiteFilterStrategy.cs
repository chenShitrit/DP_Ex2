using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace DP_Targil1.Patterns.Strategy
{
    public class blackAndWhiteFilterStrategy : IColorMatrixStrategy
    {
        public ColorMatrix CreateColorMatrix()
        {
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                    {
                        new float[] { .3f, .3f, .3f, 0, 0 },
                        new float[] { .59f, .59f, .59f, 0, 0 },
                        new float[] { .11f, .11f, .11f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

            return colorMatrix;
        }
    }
}
