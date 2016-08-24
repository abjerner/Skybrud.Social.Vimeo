using System;
using Skybrud.Social.Vimeo.Endpoints;
using Skybrud.Social.Vimeo.Interfaces;

namespace Skybrud.Social.Vimeo {
    
    public class VimeoService {

        #region Properties

        public IVimeoOAuthClient Client { get; private set; }

        public VimeoMeEndpoint Me { get; private set; }

        public VimeoUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        protected VimeoService(IVimeoOAuthClient client) {
            
            if (client == null) throw new ArgumentNullException("client");
            Client = client;

            Me = new VimeoMeEndpoint(this);
            Users = new VimeoUsersEndpoint(this);
        
        }

        #endregion

        #region Static methods

        public static VimeoService CreateFromOAuthClient(IVimeoOAuthClient client) {
            if (client == null) throw new ArgumentNullException("client");
            return new VimeoService(client);
        }

        #endregion

    }

}