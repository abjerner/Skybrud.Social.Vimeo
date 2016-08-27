using Skybrud.Social.OAuth;
using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Interfaces;

namespace Skybrud.Social.Vimeo.OAuth1a {

    /// <summary>
    /// Class for handling authentication and communication with the Vimeo API using OAuth 1.0a.
    /// </summary>
    public class VimeoOAuthClient : SocialOAuthClient, IVimeoOAuthClient {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw <strong>Me</strong> endpoint.
        /// </summary>
        public VimeoMeRawEndpoint Me { get; private set; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        public VimeoUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VimeoOAuthClient"/> class.
        /// </summary>
        public VimeoOAuthClient() : this(null, null, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VimeoOAuthClient"/> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        public VimeoOAuthClient(string consumerKey, string consumerSecret) : this(consumerKey, consumerSecret, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VimeoOAuthClient"/> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        public VimeoOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this(consumerKey, consumerSecret, token, tokenSecret, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="VimeoOAuthClient"/> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        /// <param name="callback">The callback URI used for authentication.</param>
        public VimeoOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {
        
            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to the Vimeo API
            RequestTokenUrl = "https://vimeo.com/oauth/request_token";
            AuthorizeUrl = "https://vimeo.com/oauth/authorize";
            AccessTokenUrl = "https://vimeo.com/oauth/access_token";
            
            Me = new VimeoMeRawEndpoint(this);
            Users = new VimeoUsersRawEndpoint(this);
        
        }

        #endregion

    }

}