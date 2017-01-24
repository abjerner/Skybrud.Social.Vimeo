using System;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Vimeo.Enums;

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
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        public VimeoGetChannelVideosOptions(long channelId, int page, int perPage) {
            ChannelId = channelId;
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Members methods

        public override IHttpQueryString GetQueryString() {
            IHttpQueryString query = base.GetQueryString();
            if (!String.IsNullOrWhiteSpace(Query)) query.Add("query", query);
            if (Sort != VimeoVideoSortField.Default) {
                query.Add("sort", StringUtils.ToUnderscore(Sort));
                query.Add("direction", Direction == VimeoSortDirection.Ascending ? "asc" : "desc");
            }
            return query;
        }

        #endregion

    }

}