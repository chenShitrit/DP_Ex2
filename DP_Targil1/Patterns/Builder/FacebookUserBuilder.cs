﻿using System;   
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

        public void initGroups()
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

        public void initFriends()
        {
            FacebookUser.FriendsCollection = FacebookUser.User.Friends;
        }

        public void initSchools()
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

        public void initJobs()
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

        public void initCity()
        {
            FacebookUser.City = FacebookUser.User.Hometown;
        }

        public FacebookUser GetFacebookUser()
        {
            return FacebookUser;
        }
    }
}
