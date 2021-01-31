using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Targil1.Patterns.Decorator
{
    public interface IMatchSuggestion
    {
        void CheckPersonMatch(string i_Gender, int i_FromAge, int i_ToAge, string i_Hometown);
    }
}
