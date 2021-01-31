using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP_Targil1.Patterns.Builder
{
    public class FacebookUserBuilder : IUserBuilder
    {
        public FacebookUser FacebookUser { get; }

        public FacebookUserBuilder(User i_User)
        {
            FacebookUser = new FacebookUser(i_User);
        }

        public void InitAge()
        {
            int currYear = DateTime.Now.Year;
            int birthYear = int.Parse(FacebookUser.User.Birthday.Substring(6, 4));
            FacebookUser.Age = currYear - birthYear;
        }

        public void InitCountOfAlbums()
        {
            FacebookUser.CountOfAlbums = FacebookUser.User.Albums.Count;
        }

        public void InitCity()
        {
            FacebookUser.City = FacebookUser.User.Hometown;
        }

        public void InitGroups()
        {
            try
            {
                FacebookUser.GroupsCollection = FacebookUser.User.Groups;
            }
            catch (Exception)
            {
                FacebookUser.GroupsCollection = null;
            }
        }

        public void InitFriends()
        {
            FacebookUser.FriendsCollection = FacebookUser.User.Friends;
        }

        public void InitSchools()
        {
            FacebookUser.SchoolsCollection = new FacebookObjectCollection<Education>();

            if (FacebookUser.User.Educations != null)
            {
                foreach (Education school in FacebookUser.User.Educations)
                {
                    FacebookUser.SchoolsCollection.Add(school);
                }
            }
        }

        public void InitJobs()
        {
            FacebookUser.JobsCollection = new FacebookObjectCollection<WorkExperience>();

            if (FacebookUser.User.WorkExperiences != null)
            {
                foreach (WorkExperience job in FacebookUser.User.WorkExperiences)
                {
                    FacebookUser.JobsCollection.Add(job);
                }
            }
        }

        public FacebookUser GetFacebookUser()
        {
            return FacebookUser;
        }
    }
}
