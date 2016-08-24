using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Interfaces;

namespace Skybrud.Social.Vimeo.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the users endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/users</cref>
    /// </see>
    public class VimeoUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public IVimeoOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal VimeoUsersRawEndpoint(IVimeoOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public SocialHttpResponse GetInfo(long userId) {
            return Client.DoHttpGetRequest("https://api.vimeo.com/users/" + userId);
        }

        /// <summary>
        /// Gets information about the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string username) {
            return Client.DoHttpGetRequest("https://api.vimeo.com/users/" + username);
        }

        #endregion

    }

}