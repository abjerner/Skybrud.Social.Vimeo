using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.OAuth;
using Skybrud.Social.Vimeo.Options.Users;

namespace Skybrud.Social.Vimeo.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>users</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/users</cref>
    /// </see>
    public class VimeoUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public IVimeoOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal VimeoUsersRawEndpoint(IVimeoOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public IHttpResponse GetInfo(long userId) {
            return Client.Get($"/users/{userId}");
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public IHttpResponse GetInfo(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return Client.DoHttpGetRequest($"/users/{username}");
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels(long userId) {
            return GetChannels(new VimeoGetUserChannelsOptions(userId));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels(long userId, int page, int perPage) {
            return GetChannels(new VimeoGetUserChannelsOptions(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetChannels(new VimeoGetUserChannelsOptions(username));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels(string username, int page, int perPage) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetChannels(new VimeoGetUserChannelsOptions(username, page, perPage));
        }

        /// <summary>
        /// Gets a list of user channels matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetChannels(VimeoGetUserChannelsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (!options.HasUserId && !options.HasUsername) throw new PropertyNotSetException(nameof(options.UserId));
            return Client.GetResponse(options);
        }

        #endregion

    }

}