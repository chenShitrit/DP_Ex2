using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP_Targil1
{
    public class UserData
    {
        public User User { get; set; }

        public int MatchPercentage { get; set; }

        public int Age { get; set; }

        public City City { get; set; }

        public FacebookObjectCollection<Group> GroupsCollection { get; set; }

        public FacebookObjectCollection<Education> SchoolsCollection { get; set; }

        public FacebookObjectCollection<WorkExperience> JobsCollection { get; set; }

        public FacebookObjectCollection<User> FriendsCollection { get; set; }

        public UserData(User i_User)
        {
            User = i_User;
            Age = convertBirthdayToAge(i_User);
            initGroups();
            initSchools();
            initJobs();
            initCity();
            initFriends();
        }

        private int convertBirthdayToAge(User i_User)
        {
            int currYear = DateTime.Now.Year;
            int birthYear = int.Parse(i_User.Birthday.Substring(6, 4));
            return currYear - birthYear;
        }

        private void initGroups()
        {
            try
            {
                GroupsCollection = User.Groups;
            }
            catch (Exception)
            {
                GroupsCollection = null;
            }
        }

        private void initFriends()
        {
            FriendsCollection = User.Friends;
        }

        private void initSchools()
        {
            SchoolsCollection = new FacebookObjectCollection<Education>();

            if (User.Educations != null)
            {
                foreach (Education school in User.Educations)
                {
                    SchoolsCollection.Add(school);
                }
            }
        }

        private void initJobs()
        {
            JobsCollection = new FacebookObjectCollection<WorkExperience>();

            if (User.WorkExperiences != null)
            {
                foreach (WorkExperience job in User.WorkExperiences)
                {
                    JobsCollection.Add(job);
                }
            }
        }

        private void initCity()
        {
            City = User.Hometown;
        }

        public override string ToString()
        {
            string matchInfo = string.Format("{0}: {1}%", User.Name, MatchPercentage);
            return matchInfo;
        }
    }
}
