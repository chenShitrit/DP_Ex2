using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace DP_Targil1.Patterns.Strategy
{
    public class SepiaFilterStrategy : IColorMatrixStrategy
    {
        public ColorMatrix CreateColorMatrix()
        {
            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][]
                    {
                        new float[] { .393f, .349f, .272f, 0, 0 },
                        new float[] { .769f, .686f, .534f, 0, 0 },
                        new float[] { .189f, .168f, .131f, 0, 0 },
                        new float[] { 0, 0, 0, 1, 0 },
                        new float[] { 0, 0, 0, 0, 1 }
                    });

            return colorMatrix;
        }
    }
}
