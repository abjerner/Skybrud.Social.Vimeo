using System;
using Skybrud.Social.Vimeo.Endpoints;
using Skybrud.Social.Vimeo.OAuth;

namespace Skybrud.Social.Vimeo {

    /// <summary>
    /// Class working as an entry point to the Vimeo API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/start</cref>
    /// </see>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints</cref>
    /// </see>
    public class VimeoHttpService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the Vimeo API.
        /// </summary>
        public VimeoOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the <strong>Channels</strong> endpoint.
        /// </summary>
        public VimeoChannelsEndpoint Channels { get; }

        /// <summary>
        /// Gets a reference to the <strong>Me</strong> endpoint.
        /// </summary>
        public VimeoMeEndpoint Me { get; }

        /// <summary>
        /// Gets a reference to the <strong>Users</strong> endpoint.
        /// </summary>
        public VimeoUsersEndpoint Users { get; }

        /// <summary>
        /// Gets a reference to the <strong>Videos</strong> endpoint.
        /// </summary>
        public VimeoVideosEndpoint Videos { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new service instance based on the specified <see cref="VimeoOAuthClient"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="VimeoOAuthClient"/>.</param>
        protected VimeoHttpService(VimeoOAuthClient client) {

            Client = client ?? throw new ArgumentNullException(nameof(client));

            Channels = new VimeoChannelsEndpoint(this);
            Me = new VimeoMeEndpoint(this);
            Users = new VimeoUsersEndpoint(this);
            Videos = new VimeoVideosEndpoint(this);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified access token. Internally a new OAuth 2.0 client will be
        /// initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>An instance of <see cref="VimeoHttpService" />.</returns>
        public static VimeoHttpService CreateFromAccessToken(string accessToken) {
            if (string.IsNullOrWhiteSpace(accessToken)) throw new ArgumentNullException(nameof(accessToken));
            return new VimeoHttpService(new VimeoOAuthClient(accessToken));
        }

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        /// <returns>An instance of <see cref="VimeoHttpService" />.</returns>
        public static VimeoHttpService CreateFromOAuthClient(VimeoOAuthClient client) {
            if (client == null) throw new ArgumentNullException(nameof(client));
            return new VimeoHttpService(client);
        }

        #endregion

    }

}