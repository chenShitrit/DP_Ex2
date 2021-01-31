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
            i_FBUserBuilder.InitGroups();
            i_FBUserBuilder.InitSchools();
            i_FBUserBuilder.InitJobs();
            i_FBUserBuilder.InitCity();
            i_FBUserBuilder.InitFriends();
            i_FBUserBuilder.InitAge();
            i_FBUserBuilder.InitCountOfAlbums();
        }

        public FacebookUser GetFacebookUser(IUserBuilder i_FBUserBuilder)
        {
            return i_FBUserBuilder.GetFacebookUser();
        }
    }
}
