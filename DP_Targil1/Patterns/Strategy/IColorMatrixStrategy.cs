using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace DP_Targil1.Patterns.Strategy
{
    public interface IColorMatrixStrategy
    {
        ColorMatrix CreateColorMatrix();
    }
}
