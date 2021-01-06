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
        void InitAge();

        void InitGroups();

        void InitFriends();

        void InitSchools();

        void InitJobs();

        void InitCity();

        FacebookUser GetFacebookUser();
    }
}
