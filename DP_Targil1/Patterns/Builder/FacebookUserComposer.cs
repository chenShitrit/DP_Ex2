using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DP_Targil1.Patterns.Builder
{
    public class FacebookUserComposer
    {
        public void Construct(IUserBuilder i_FBUserBuilder)
        {
            i_FBUserBuilder.initGroups();
            i_FBUserBuilder.initSchools();
            i_FBUserBuilder.initJobs();
            i_FBUserBuilder.initCity();
            i_FBUserBuilder.initFriends();
            //new Thread(i_FBUserBuilder.initGroups).Start();
            //new Thread(i_FBUserBuilder.initSchools).Start();
            //new Thread(i_FBUserBuilder.initJobs).Start();
            //new Thread(i_FBUserBuilder.initCity).Start();
            //new Thread(i_FBUserBuilder.initFriends).Start();
        }

        public FacebookUser GetFacebookUser(IUserBuilder i_FBUserBuilder)
        {
            return i_FBUserBuilder.GetFacebookUser();
        }
    }
}
