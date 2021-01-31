using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP_Targil1.Patterns.Decorator
{
    public class MatchSuggestionDecorator : IMatchSuggestion
    {
        private IMatchSuggestion m_IMatchSuggestion;

        public MatchSuggestionDecorator(IMatchSuggestion i_Interface)
        {
            m_IMatchSuggestion = i_Interface;
        }

        public void CheckPersonMatch(string i_Gender, int i_FromAge, int i_ToAge, string i_Hometown)
        {
            m_IMatchSuggestion.CheckPersonMatch(i_Gender, i_FromAge, i_ToAge, i_Hometown);
        }
    }
}
