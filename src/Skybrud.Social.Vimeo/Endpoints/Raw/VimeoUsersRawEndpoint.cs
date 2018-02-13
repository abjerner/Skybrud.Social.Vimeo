using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.OAuth;
using Skybrud.Social.Vimeo.Options.Users;

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
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public SocialHttpResponse GetInfo(long userId) {
            return Client.DoHttpGetRequest("https://api.vimeo.com/users/" + userId);
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string username) {
            return Client.DoHttpGetRequest("https://api.vimeo.com/users/" + username);
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetChannels(long userId) {
            return Client.DoHttpGetRequest("https://api.vimeo.com/users/" + userId + "/channels");
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetChannels(long userId, int page, int perPage) {
            return GetChannels(new VimeoGetUserChannelsOptions(userId, page, perPage));
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetChannels(string username) {
            return Client.DoHttpGetRequest("https://api.vimeo.com/users/" + username + "/channels");
        }

        /// <summary>
        /// Gets a list of channels of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetChannels(string username, int page, int perPage) {
            return GetChannels(new VimeoGetUserChannelsOptions(username, page, perPage));
        }

        /// <summary>
        /// Gets a list of user channels matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for call to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetChannels(VimeoGetUserChannelsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            if (!options.HasUserId && !options.HasUsername) throw new PropertyNotSetException("UserId");
            return Client.DoHttpGetRequest("https://api.vimeo.com/users/" + (options.HasUserId ? options.UserId + "" : options.Username) + "/channels", options);
        }

        #endregion

    }

}