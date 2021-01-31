using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper.ObjectModel;
using DP_Targil1.Patterns.Builder;
using DP_Targil1.Patterns.Decorator;
using DP_Targil1.Patterns.Iterator;
using FacebookWrapper;

namespace DP_Targil1
{
    public class MatchSuggestion : IMatchSuggestion
    {
        private const int k_NoMatchPercentage = 0;
        private const int k_Params = 5;
        private FacebookUser m_CurrentUser;

        public List<FacebookUser> TopMatchedUsers { get; set; }

        public SortedList<string, FacebookUser> MatchPersons { get; set; }

        private MatchIterator m_MatchIterator;

        public MatchSuggestion(User i_LoggedInUser)
        {
            FacebookUserComposer facebookUserComposer = new FacebookUserComposer();
            IUserBuilder userBuilder = new FacebookUserBuilder(i_LoggedInUser);
            facebookUserComposer.Construct(userBuilder);
            MatchPersons = new SortedList<string, FacebookUser>();
            TopMatchedUsers = new List<FacebookUser>();
            m_CurrentUser = facebookUserComposer.GetFacebookUser(userBuilder);
            m_MatchIterator = new MatchIterator(MatchPersons);    
            InitMatchPersons();
        }

        public void InitMatchPersons()
        {
            foreach (User myFriend in m_CurrentUser.FriendsCollection)
            {
                m_MatchIterator.InitMatches(myFriend.Friends, m_CurrentUser);
            }
        }

        public bool IsMatching(FacebookUser i_User, string i_Gender, int i_FromAge, int i_ToAge, string i_Hometown)
        {
            bool isMatching = false;
            if (i_User.User.Gender == null && i_Gender != null)
            {
                isMatching = false;
            }
            else if (i_User.City == null && i_Hometown != null)
            {
                isMatching = false;
            }
            else
            {
                isMatching = (string.IsNullOrEmpty(i_Gender) || i_User.User.Gender.ToString() == i_Gender)
                && (string.IsNullOrEmpty(i_Hometown) || i_User.City.ToString() == i_Hometown)
                && (((i_User.Age >= i_FromAge) && (i_User.Age <= i_ToAge)) || (i_FromAge == 0 && i_ToAge == 0));
            }

            return isMatching;
        }

        public void CheckPersonMatch(string i_Gender, int i_FromAge, int i_ToAge, string i_Hometown)
        {
            foreach (KeyValuePair<string, FacebookUser> matchPerson in MatchPersons)
            {
                if (IsSingle(matchPerson))
                {
                    if (IsMatching(matchPerson.Value, i_Gender, i_FromAge, i_ToAge, i_Hometown))
                    {
                        CheckMatchingPercentage(matchPerson);
                        {
                            TopMatchedUsers.Add(matchPerson.Value);
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

        private void sortMatchingList()
        {
            TopMatchedUsers.Sort(comparisonByPercent);
        }

        private int comparisonByPercent(FacebookUser i_UserData1, FacebookUser i_UserData2)
        {
            return i_UserData2.MatchPercentage.CompareTo(i_UserData1.MatchPercentage);
        }

        public void CheckMatchingPercentage(KeyValuePair<string, FacebookUser> i_User)
        {
            new Thread(checkCityMatch).Start();
            new Thread(checkSchoolMatch).Start();
            new Thread(checkGroupsMatch).Start();
            new Thread(checkJobsMatch).Start();
         }

        private void checkSchoolMatch()
        {
            foreach (KeyValuePair<string, FacebookUser> matchPerson in MatchPersons)
            {
                if (matchPerson.Value.SchoolsCollection.Count != 0 && m_CurrentUser.SchoolsCollection.Count != 0)
                {
                    if (matchPerson.Value.SchoolsCollection.Last().Id == m_CurrentUser.SchoolsCollection.Last().Id)
                    {
                        matchPerson.Value.MatchPercentage += 100 / k_Params;
                    }
                }
            }
        }

        private void checkCityMatch()
        {
            foreach (KeyValuePair<string, FacebookUser> matchPerson in MatchPersons)
            {
                if (matchPerson.Value.City != null && m_CurrentUser.City != null)
                {
                    if (matchPerson.Value.City.Id == m_CurrentUser.City.Id)
                    {
                        matchPerson.Value.MatchPercentage += 100 / k_Params;
                    }
                }
            }
        }

        private void checkJobsMatch()
        {
            foreach (KeyValuePair<string, FacebookUser> matchPerson in MatchPersons)
            {
                if (matchPerson.Value.JobsCollection.Count != 0 && m_CurrentUser.JobsCollection.Count != 0)
                {
                    if (matchPerson.Value.JobsCollection.Last().Id == m_CurrentUser.JobsCollection.Last().Id)
                    {
                        matchPerson.Value.MatchPercentage += 100 / k_Params;
                    }
                }
            }
        }

        private void checkGroupsMatch()
        {
            foreach (KeyValuePair<string, FacebookUser> matchPerson in MatchPersons)
            {
                if (matchPerson.Value.GroupsCollection != null && m_CurrentUser.GroupsCollection != null)
                {
                    foreach (Group myGroup in m_CurrentUser.GroupsCollection)
                    {
                        foreach (Group friendGroup in matchPerson.Value.GroupsCollection)
                        {
                            if (myGroup.Id == friendGroup.Id)
                            {
                                matchPerson.Value.MatchPercentage += 100 / k_Params;
                            }
                        }
                    }
                }
            }
        }

        public bool IsSingle(KeyValuePair<string, FacebookUser> i_User)
        {
            return i_User.Value.User.RelationshipStatus == User.eRelationshipStatus.Single || i_User.Value.User.RelationshipStatus == User.eRelationshipStatus.None;
        }
    }
}
