using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.OAuth;
using Skybrud.Social.Vimeo.Options.Videos;

namespace Skybrud.Social.Vimeo.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Videos</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/videos</cref>
    /// </see>
    public class VimeoVideosRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public VimeoOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal VimeoVideosRawEndpoint(VimeoOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the video with the specified <paramref name="videoId"/>.
        /// </summary>
        /// <param name="videoId">The ID of the video</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/videos#GET/videos/{video_id}</cref>
        /// </see>
        public IHttpResponse GetVideo(long videoId) {
            return Client.Get($"/videos/{videoId}");
        }

        /// <summary>
        /// Gets a list of videos uploaded by the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos() {
            return GetVideos(new VimeoGetVideosOptions("me"));
        }

        /// <summary>
        /// Gets a list of videos uploaded by the user with the specified <paramref name="userId"/>
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(long userId) {
            return GetVideos(new VimeoGetVideosOptions(userId));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of videos to be returned per page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(long userId, int page, int perPage) {
            return GetVideos(new VimeoGetVideosOptions(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(string username) {
            return GetVideos(new VimeoGetVideosOptions(username));
        }

        /// <summary>
        /// Gets a list of videos of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of videos to be returned per page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(string username, int page, int perPage) {
            return GetVideos(new VimeoGetVideosOptions(username, page, perPage));
        }

        /// <summary>
        /// Gets a list of videos of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetVideos(VimeoGetVideosOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}