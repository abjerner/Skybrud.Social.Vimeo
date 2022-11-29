using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.OAuth;

namespace Skybrud.Social.Vimeo.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the me endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/me</cref>
    /// </see>
    public class VimeoMeRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public VimeoOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal VimeoMeRawEndpoint(VimeoOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/me#GET/me</cref>
        /// </see>
        public IHttpResponse GetUser() {
            return Client.Get("/me");
        }

        #endregion

    }

}