using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;

namespace DP_Targil1.Patterns.Decorator
{
    public class MatchSuggestionWithAlbums : MatchSuggestionDecorator
    {
        private const int k_NoMatchPercentage = 0;
        private const int k_Params = 5;
        private User m_LoggedInUser;

        public MatchSuggestionWithAlbums(IMatchSuggestion i_Interface, User i_LoggedInUser)
            : base(i_Interface)
        {
            this.m_LoggedInUser = i_LoggedInUser;
        }

        public new void CheckPersonMatch(string i_Gender, int i_FromAge, int i_ToAge, string i_Hometown)
        {
            MatchSuggestion matchSuggestion = new MatchSuggestion(this.m_LoggedInUser);

            foreach (KeyValuePair<string, FacebookUser> matchPerson in matchSuggestion.MatchPersons)
            {
                if (matchSuggestion.IsSingle(matchPerson))
                {
                    if (matchSuggestion.IsMatching(matchPerson.Value, i_Gender, i_FromAge, i_ToAge, i_Hometown) && matchPerson.Value.CountOfAlbums != 0)
                    {
                        matchSuggestion.CheckMatchingPercentage(matchPerson);
                        {
                            this.TopMatchedUsers.Add(matchPerson.Value);
                        }

                        matchPerson.Value.MatchPercentage += 100 / k_Params;
                    }
                    else
                    {
                        matchPerson.Value.MatchPercentage = k_NoMatchPercentage;
                    }
                }
            }
        }
    }
}
