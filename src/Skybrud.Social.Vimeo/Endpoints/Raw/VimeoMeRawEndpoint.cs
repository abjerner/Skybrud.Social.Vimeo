using Skybrud.Social.Http;
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
        public IVimeoOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal VimeoMeRawEndpoint(IVimeoOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/me#GET/me</cref>
        /// </see>
        public SocialHttpResponse GetInfo() {
            return Client.DoHttpGetRequest("https://api.vimeo.com/me");
        }

        #endregion

    }

}