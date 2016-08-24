using Skybrud.Social.OAuth;
using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Interfaces;

namespace Skybrud.Social.Vimeo.OAuth1a {
    
    public class VimeoOAuthClient : SocialOAuthClient, IVimeoOAuthClient {

        #region Properties

        public VimeoMeRawEndpoint Me { get; private set; }

        public VimeoUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        public VimeoOAuthClient() {
            Me = new VimeoMeRawEndpoint(this);
            Users = new VimeoUsersRawEndpoint(this);
        }

        #endregion

    }

}