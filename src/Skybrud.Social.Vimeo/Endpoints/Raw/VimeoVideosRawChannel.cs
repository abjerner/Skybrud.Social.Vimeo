using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
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
        public IVimeoOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal VimeoVideosRawEndpoint(IVimeoOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the video with the specified <paramref name="videoId"/>.
        /// </summary>
        /// <param name="videoId">The ID of the video</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/videos#GET/videos/{video_id}</cref>
        /// </see>
        public SocialHttpResponse GetVideo(long videoId) {
            return Client.DoHttpGetRequest("/videos/" + videoId);
        }
        
        /// <summary>
        /// Gets a list of videos uploaded by the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetVideos() {
            return GetVideos(new VimeoGetVideosOptions("me"));
        }
        
        /// <summary>
        /// Gets a list of videos uploaded by the user with the specified <paramref name="userId"/>
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetVideos(long userId) {
            return GetVideos(new VimeoGetVideosOptions(userId));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of videos to be returned per page.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetVideos(long userId, int page, int perPage) {
            return GetVideos(new VimeoGetVideosOptions(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetVideos(string username) {
            return GetVideos(new VimeoGetVideosOptions(username));
        }

        /// <summary>
        /// Gets a list of videos of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of videos to be returned per page.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetVideos(string username, int page, int perPage) {
            return GetVideos(new VimeoGetVideosOptions(username, page, perPage));
        }

        /// <summary>
        /// Gets a list of videos of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for request to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetVideos(VimeoGetVideosOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (!options.HasUserId && !options.HasUsername) throw new PropertyNotSetException(nameof(options.UserId));
            return Client.DoHttpGetRequest(options.ApiUrl, options);
        }

        #endregion

    }

}