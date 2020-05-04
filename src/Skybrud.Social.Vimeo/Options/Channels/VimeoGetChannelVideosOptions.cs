using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Vimeo.Options.Sorting;
using Skybrud.Social.Vimeo.Options.Videos;

namespace Skybrud.Social.Vimeo.Options.Channels {

    /// <summary>
    /// Class representing the options for getting a list of videos of a channel.
    /// </summary>
    public class VimeoGetChannelVideosOptions : VimeoPaginationOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the channel.
        /// </summary>
        public long ChannelId { get; set; }

        /// <summary>
        /// Gets or sets a text based query the videos should match.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Gets or sets the field to be sorted by.
        /// </summary>
        public VimeoVideoSortField Sort { get; set; }

        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        public VimeoSortDirection Direction { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public VimeoGetChannelVideosOptions() {
            Direction = VimeoSortDirection.Descending;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        public VimeoGetChannelVideosOptions(long channelId) {
            ChannelId = channelId;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="channelId">The ID of the channel.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        public VimeoGetChannelVideosOptions(long channelId, int page, int perPage) {
            ChannelId = channelId;
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Members methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public override IHttpQueryString GetQueryString() {
            IHttpQueryString query = base.GetQueryString();
            if (!string.IsNullOrWhiteSpace(Query)) query.Add("query", query);
            if (Sort != VimeoVideoSortField.Default) {
                query.Add("sort", StringUtils.ToUnderscore(Sort));
                query.Add("direction", Direction == VimeoSortDirection.Ascending ? "asc" : "desc");
            }
            return query;
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpRequest"/> representing the request.
        /// </summary>
        public override IHttpRequest GetRequest() {
            if (ChannelId == 0) throw new PropertyNotSetException(nameof(ChannelId));
            return new HttpRequest(HttpMethod.Get, $"/channels/{ChannelId}/videos", GetQueryString());
        }

        #endregion

    }

}