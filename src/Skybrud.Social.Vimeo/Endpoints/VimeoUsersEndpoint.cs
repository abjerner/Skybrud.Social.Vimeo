using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Options.Users;
using Skybrud.Social.Vimeo.Responses.Channels;
using Skybrud.Social.Vimeo.Responses.Users;
using Skybrud.Social.Vimeo.Responses.Videos;

namespace Skybrud.Social.Vimeo.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Users</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/users</cref>
    /// </see>
    public class VimeoUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Vimeo service.
        /// </summary>
        public VimeoHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public VimeoUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal VimeoUsersEndpoint(VimeoHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="VimeoUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public VimeoUserResponse GetUser(long userId) {
            return new VimeoUserResponse(Raw.GetUser(userId));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="VimeoUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public VimeoUserResponse GetUser(string username) {
            return new VimeoUserResponse(Raw.GetUser(username));
        }

        /// <summary>
        /// Returns a list of videos the user with the specified <paramref name="userId"/> has uploaded.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#get_videos</cref>
        /// </see>
        public VimeoVideoListResponse GetVideos(long userId) {
            return new VimeoVideoListResponse(Raw.GetVideos(userId));
        }

        /// <summary>
        /// Returns a list of videos the user with the specified <paramref name="userId"/> has uploaded.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#get_videos</cref>
        /// </see>
        public VimeoVideoListResponse GetVideos(long userId, int page, int perPage) {
            return new VimeoVideoListResponse(Raw.GetVideos(userId, page, perPage));
        }

        /// <summary>
        /// Returns a list of videos the user with the specified <paramref name="username"/> has uploaded.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#get_videos</cref>
        /// </see>
        public VimeoVideoListResponse GetVideos(string username) {
            return new VimeoVideoListResponse(Raw.GetVideos(username));
        }

        /// <summary>
        /// Returns a list of videos the user with the specified <paramref name="username"/> has uploaded.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#get_videos</cref>
        /// </see>
        public VimeoVideoListResponse GetVideos(string username, int page, int perPage) {
            return new VimeoVideoListResponse(Raw.GetVideos(username, page, perPage));
        }

        /// <summary>
        /// Returns a list of videos the user matching the specified <paramref name="options"/> has uploaded.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/reference/videos#get_videos</cref>
        /// </see>
        public VimeoVideoListResponse GetVideos(VimeoGetUserVideosOptions options) {
            return new VimeoVideoListResponse(Raw.GetVideos(options));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <returns>An instance of <see cref="VimeoChannelListResponse"/> representing the response.</returns>
        public VimeoChannelListResponse GetChannels(long userId) {
            return new VimeoChannelListResponse(Raw.GetChannels(userId));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="VimeoChannelListResponse"/> representing the response.</returns>
        public VimeoChannelListResponse GetChannels(long userId, int page, int perPage) {
            return new VimeoChannelListResponse(Raw.GetChannels(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <returns>An instance of <see cref="VimeoChannelListResponse"/> representing the response.</returns>
        public VimeoChannelListResponse GetChannels(string username) {
            return new VimeoChannelListResponse(Raw.GetChannels(username));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="VimeoChannelListResponse"/> representing the response.</returns>
        public VimeoChannelListResponse GetChannels(string username, int page, int perPage) {
            return new VimeoChannelListResponse(Raw.GetChannels(username, page, perPage));
        }

        /// <summary>
        /// Gets a list of user channels matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for request to the API.</param>
        /// <returns>An instance of <see cref="VimeoChannelListResponse"/> representing the response.</returns>
        public VimeoChannelListResponse GetChannels(VimeoGetUserChannelsOptions options) {
            return new VimeoChannelListResponse(Raw.GetChannels(options));
        }

        #endregion

    }

}