using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP_Targil1
{
    public class FacebookUser
    {
        public User User { get; set; }

        public int MatchPercentage { get; set; }

        public int Age { get; set; }

        public int CountOfAlbums { get; set; }

        public City City { get; set; }

        public FacebookObjectCollection<Group> GroupsCollection { get; set; }

        public FacebookObjectCollection<Education> SchoolsCollection { get; set; }

        public FacebookObjectCollection<WorkExperience> JobsCollection { get; set; }

        public FacebookObjectCollection<User> FriendsCollection { get; set; }

        public FacebookUser(User i_User)
        {
            User = i_User;
        }
                        
        public override string ToString()
        {
            string matchInfo = string.Format("{0}: {1}%", User.Name, MatchPercentage);
            return matchInfo;
        }
    }
}
