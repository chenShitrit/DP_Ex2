using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace DP_Targil1.Patterns.Builder
{
    public interface IUserBuilder
    {
        void initAge();

        void initGroups();

        void initFriends();

        void initSchools();

        void initJobs();

        void initCity();

        FacebookUser GetFacebookUser();
    }
}
