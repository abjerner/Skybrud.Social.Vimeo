using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Options.Videos;
using Skybrud.Social.Vimeo.Responses.Videos;

namespace Skybrud.Social.Vimeo.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Videos</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/videos</cref>
    /// </see>
    public class VimeoVideosEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Vimeo service.
        /// </summary>
        public VimeoHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public VimeoVideosRawEndpoint Raw => Service.Client.Videos;

        #endregion

        #region Constructors

        internal VimeoVideosEndpoint(VimeoHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the video with the specified <paramref name="videoId"/>.
        /// </summary>
        /// <param name="videoId">The ID of the video</param>
        /// <returns>An instance of <see cref="VimeoVideoResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/videos#GET/videos/{video_id}</cref>
        /// </see>
        public VimeoVideoResponse GetVideo(long videoId) {
            return new VimeoVideoResponse(Raw.GetVideo(videoId));
        }

        /// <summary>
        /// Gets a list of videos uploaded by the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        public VimeoVideoListResponse GetVideos() {
            return new VimeoVideoListResponse(Raw.GetVideos());
        }

        /// <summary>
        /// Gets a list of videos uploaded by the user with the specified <paramref name="userId"/>
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        public VimeoVideoListResponse GetVideos(long userId) {
            return new VimeoVideoListResponse(Raw.GetVideos(userId));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of videos to be returned per page.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        public VimeoVideoListResponse GetVideos(long userId, int page, int perPage) {
            return new VimeoVideoListResponse(Raw.GetVideos(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        public VimeoVideoListResponse GetVideos(string username) {
            return new VimeoVideoListResponse(Raw.GetVideos(username));
        }

        /// <summary>
        /// Gets a list of videos of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of videos to be returned per page.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        public VimeoVideoListResponse GetVideos(string username, int page, int perPage) {
            return new VimeoVideoListResponse(Raw.GetVideos(username, page, perPage));
        }

        /// <summary>
        /// Gets a list of videos of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for request to the API.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        public VimeoVideoListResponse GetVideos(VimeoGetVideosOptions options) {
            return new VimeoVideoListResponse(Raw.GetVideos(options));
        }

        /// <summary>
        /// Gets a list of videos of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for request to the API.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#search_videos</cref>
        /// </see>
        public VimeoVideoListResponse SearchVideos(VimeoSearchVideosOptions options) {
            return new VimeoVideoListResponse(Raw.SearchVideos(options));
        }

        #endregion

    }

}