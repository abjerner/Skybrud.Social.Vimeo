using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Security;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Responses.Authentication;
using Skybrud.Social.Vimeo.Scopes;

namespace Skybrud.Social.Vimeo.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Vimeo API as well as any OAuth 2.0 communication.
    /// </summary>
    public class VimeoOAuth2Client : SocialHttpClient, IVimeoOAuthClient {

        #region Properties

        #region OAuth

        /// <summary>
        /// Gets or sets the client ID of the app.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of the app.
        /// </summary>
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        #region Endpoints

        /// <summary>
        /// Gets a reference to the raw <strong>Channels</strong> endpoint.
        /// </summary>
        public VimeoChannelsRawEndpoint Channels { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Me</strong> endpoint.
        /// </summary>
        public VimeoMeRawEndpoint Me { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        public VimeoUsersRawEndpoint Users { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Videos</strong> endpoint.
        /// </summary>
        public VimeoVideosRawEndpoint Videos { get; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new OAuth client default properties.
        /// </summary>
        public VimeoOAuth2Client() {
            Channels = new VimeoChannelsRawEndpoint(this);
            Me = new VimeoMeRawEndpoint(this);
            Users = new VimeoUsersRawEndpoint(this);
            Videos = new VimeoVideosRawEndpoint(this);
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="accessToken"/>.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public VimeoOAuth2Client(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes a new OAuth client with the specified <paramref name="clientId"/> and
        /// <paramref name="clientSecret"/>.
        /// </summary>
        /// <param name="clientId">The client ID of the app.</param>
        /// <param name="clientSecret">The client secret of the app.</param>
        public VimeoOAuth2Client(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <paramref name="clientId"/>,
        /// <paramref name="clientSecret"/> and <paramref name="redirectUri"/>.
        /// </summary>
        /// <param name="clientId">The client ID of the app.</param>
        /// <param name="clientSecret">The client secret of the app.</param>
        /// <param name="redirectUri">The redirect URI of the app.</param>
        public VimeoOAuth2Client(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">The state to send to Vimeo's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>An authorization URL based on <see cref="ClientId"/>, <see cref="RedirectUri"/>,
        /// <paramref name="state"/> and <paramref name="scope"/>.</returns>
        public string GetAuthorizationUrl(string state, string scope = null) {

            // Validate the input
            if (String.IsNullOrWhiteSpace(state)) throw new ArgumentNullException(nameof(state));
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));

            // Construct the query string
            IHttpQueryString query = new SocialHttpQueryString();
            query.Add("response_type", "code");
            query.Add("client_id", ClientId);
            query.Add("redirect_uri", RedirectUri);
            query.Add("scope", scope + "");
            query.Add("state", state);

            // Construct the full URL
            return ("https://api.vimeo.com/oauth/authorize?" + query);

        }

        /// <summary>
        /// Generates the authorization URL using the specified <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">The state to send to Vimeo's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>An authorization URL based on <see cref="ClientId"/>, <see cref="RedirectUri"/>,
        /// <paramref name="state"/> and <paramref name="scope"/>.</returns>
        public string GetAuthorizationUrl(string state, VimeoScopeCollection scope) {
            if (scope == null) throw new ArgumentNullException(nameof(scope));
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Vimeo OAuth dialog.</param>
        /// <returns>An instance of <see cref="VimeoTokenResponse"/> representing the response.</returns>
        public VimeoTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Some validation
            if (String.IsNullOrWhiteSpace(ClientId)) throw new PropertyNotSetException(nameof(ClientId));
            if (String.IsNullOrWhiteSpace(ClientSecret)) throw new PropertyNotSetException(nameof(ClientSecret));
            if (String.IsNullOrWhiteSpace(RedirectUri)) throw new PropertyNotSetException(nameof(RedirectUri));
            if (String.IsNullOrWhiteSpace(authCode)) throw new ArgumentNullException(nameof(authCode));

            // Initialize the POST data
            IHttpPostData data = new SocialHttpPostData();
            data.Add("grant_type", "authorization_code");
            data.Add("code", authCode);
            data.Add("redirect_uri", RedirectUri);

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = SocialHttpMethod.Post,
                Url = "https://api.vimeo.com/oauth/access_token",
                PostData = data,
                Authorization = "basic " + SecurityUtils.Base64Encode(ClientId + ":" + ClientSecret)
            };

            // Make the call to the API
            SocialHttpResponse response = request.GetResponse();

            // Parse the response
            return VimeoTokenResponse.ParseResponse(response);

        }

        /// <summary>
        /// Virtual method that can be used for configuring a request.
        /// </summary>
        /// <param name="request">The request.</param>
        protected override void PrepareHttpRequest(SocialHttpRequest request) {

            // Append the scheme and host name if not already present
            if (request.Url.StartsWith("/")) request.Url = "https://api.vimeo.com" + request.Url;

            // Append the access token if specified
            if (!String.IsNullOrWhiteSpace(AccessToken)) request.Authorization = "Bearer " + AccessToken;

        }

        #endregion

    }

}