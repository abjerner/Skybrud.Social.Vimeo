using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.OAuth;
using Skybrud.Social.Vimeo.Options.Users;

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
        ///     <cref>https://developer.vimeo.com/api/reference/users#get_user</cref>
        /// </see>
        public IHttpResponse GetUser() {
            return Client.Get("/me");
        }

        /// <summary>
        /// Returns a list of video the authenticated user has uploaded.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#get_videos</cref>
        /// </see>
        public IHttpResponse GetVideos() {
            return Client.GetResponse(new VimeoGetUserVideosOptions("me"));
        }

        /// <summary>
        /// Returns a list of video the authenticated user has uploaded.
        /// </summary>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#get_videos</cref>
        /// </see>
        public IHttpResponse GetVideos(int page, int perPage) {
            return Client.GetResponse(new VimeoGetUserVideosOptions("me", page, perPage));
        }

        #endregion

    }

}