using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.OAuth;
using Skybrud.Social.Vimeo.Options.Channels;

namespace Skybrud.Social.Vimeo.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Channels</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/channels</cref>
    /// </see>
    public class VimeoChannelsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public IVimeoOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal VimeoChannelsRawEndpoint(IVimeoOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the channel with the specified <paramref name="channelId"/>.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetInfo(long channelId) {
            return Client.Get($"/channels/{channelId}");
        }

        /// <summary>
        /// Gets a list of videos of the channel with the specified <paramref name="channelId"/>.
        /// </summary>
        /// <param name="channelId">The ID of the cannel.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/channels#/{channel_id}/videos</cref>
        /// </see>
        public IHttpResponse GetVideos(long channelId) {
            return GetVideos(new VimeoGetChannelVideosOptions(channelId));
        }

        /// <summary>
        /// Gets a list of videos of the channel with the specified <paramref name="channelId"/>.
        /// </summary>
        /// <param name="channelId">The ID of the cannel.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/channels#/{channel_id}/videos</cref>
        /// </see>
        public IHttpResponse GetVideos(long channelId, int page, int perPage) {
            return GetVideos(new VimeoGetChannelVideosOptions(channelId, page, perPage));
        }

        /// <summary>
        /// Gets a list of videos of the channel matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/channels#/{channel_id}/videos</cref>
        /// </see>
        public IHttpResponse GetVideos(VimeoGetChannelVideosOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}