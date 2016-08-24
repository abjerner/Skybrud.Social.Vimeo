using System;
using System.Collections.Specialized;
using Skybrud.Social.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Interfaces;
using Skybrud.Social.Vimeo.Responses.Authentication;
using Skybrud.Social.Vimeo.Scopes;

namespace Skybrud.Social.Vimeo.OAuth2 {
    
    public class VimeoOAuthClient : SocialHttpClient, IVimeoOAuthClient {

        #region Properties

        public string ClientId { get; set; }
        
        public string ClientSecret { get; set; }
        
        public string RedirectUri { get; set; }

        public string AccessToken { get; set; }

        public VimeoMeRawEndpoint Me { get; private set; }

        public VimeoUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        public VimeoOAuthClient() {
            Me = new VimeoMeRawEndpoint(this);
            Users = new VimeoUsersRawEndpoint(this);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Vimeo's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <see cref="ClientId"/>, <see cref="RedirectUri"/>,
        /// <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, string scope = null) {

            // Validate the input
            if (String.IsNullOrWhiteSpace(state)) throw new ArgumentNullException("state");
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");

            // Construct the query string
            NameValueCollection query = new NameValueCollection();
            query.Add("response_type", "code");
            query.Add("client_id", ClientId);
            query.Add("redirect_uri", RedirectUri);
            query.Add("scope", scope + "");
            query.Add("state", state);

            // Construct the full URL
            return ("https://api.vimeo.com/oauth/authorize?" + SocialUtils.Misc.NameValueCollectionToQueryString(query, true));

        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Vimeo's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <see cref="ClientId"/>, <see cref="RedirectUri"/>,
        /// <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, VimeoScopeCollection scope) {
            if (scope == null) throw new ArgumentNullException("scope");
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Vimeo OAuth dialog.</param>
        /// <returns>Returns an instance of <see cref="VimeoTokenResponse"/> representing the response.</returns>
        public VimeoTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Some validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException("ClientId");
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException("ClientSecret");
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException("RedirectUri");
            if (String.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException("authCode");

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"grant_type", "authorization_code"},
                {"code", authCode },
                {"redirect_uri", RedirectUri}
            };

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = SocialHttpMethod.Post,
                Url = "https://api.vimeo.com/oauth/access_token",
                PostData = new SocialHttpPostData(data),
                Authorization = "basic " + SocialUtils.Security.Base64Encode(ClientId + ":" + ClientSecret)
            };

            // Make the call to the API
            SocialHttpResponse response = request.GetResponse();

            // Parse the response
            return VimeoTokenResponse.ParseResponse(response);

        }

        protected override void PrepareHttpRequest(SocialHttpRequest request) {

            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                request.Authorization = "Bearer " + AccessToken;
            }

        }

        #endregion

    }

}