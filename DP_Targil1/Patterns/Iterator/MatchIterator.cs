using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using DP_Targil1.Patterns.Builder;

namespace DP_Targil1.Patterns.Iterator
{
    class MatchIterator
    {

        public delegate FacebookUser BuilderDelegate(User i_User, FacebookUserComposer i_Composer);

        private SortedList<string, FacebookUser> m_MatchPersons = new SortedList<string, FacebookUser>();

        public MatchIterator(SortedList<string, FacebookUser> i_MatchPersons)
        {
            m_MatchPersons = i_MatchPersons;
        }


        public void InitMatches(FacebookObjectCollection<User> i_Users, FacebookUser i_CurrUser)
        {
            FacebookUserComposer facebookUserComposer = new FacebookUserComposer();
            using (IEnumerator<FacebookUser> iterator = GetEnumerator(friendBuilder, facebookUserComposer, i_Users))
            {
                while (iterator.MoveNext())
                {
                    if (iterator.Current.User.Id != i_CurrUser.User.Id)
                    {
                        if (!m_MatchPersons.ContainsKey(iterator.Current.User.Id))
                        {
                            m_MatchPersons.Add(iterator.Current.User.Id, iterator.Current);
                        }

                    }
                }
            }
        }


        public IEnumerator<FacebookUser> GetEnumerator(BuilderDelegate func, FacebookUserComposer i_Composer, FacebookObjectCollection<User> i_Users)
        {
            foreach (User match in i_Users)
            {
                FacebookUser friendFacebookUser = func.Invoke(match, i_Composer);
                yield return friendFacebookUser;
            }
        }

        private FacebookUser friendBuilder(User i_User, FacebookUserComposer i_FBUserComposer)
        {
            IUserBuilder userBuilder = new FacebookUserBuilder(i_User);
            i_FBUserComposer.Construct(userBuilder);
            return i_FBUserComposer.GetFacebookUser(userBuilder);
        }
    }
}



