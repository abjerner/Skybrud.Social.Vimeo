using System.Collections.Generic;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Vimeo.Options.Sorting;

namespace Skybrud.Social.Vimeo.Options.Videos {

    /// <summary>
    /// Class representing the options for getting a list of videos.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/reference/videos#search_videos</cref>
    /// </see>
    public class VimeoSearchVideosOptions : VimeoListOptions {

        #region Properties

        /// <summary>
        /// Gets or sets a list of video URLs to find. Querying, filtering, and sorting aren't supported when using this property.
        /// </summary>
        public List<string> Links { get; set; } = new();

        /// <summary>
        /// Gets or sets a text based query the videos should match.
        /// </summary>
        public string? Query { get; set; }

        /// <summary>
        /// Gets or sets the field to be sorted by.
        /// </summary>
        public VimeoVideoSortField? Sort { get; set; }

        /// <summary>
        /// Gets or sets the sort direction.
        /// </summary>
        public VimeoSortDirection? Direction { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public VimeoSearchVideosOptions() { }

        #endregion

        #region Members methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public override IHttpQueryString GetQueryString() {
            IHttpQueryString query = base.GetQueryString();
            if (Links is {Count:> 0}) query.Add("links", string.Join(",", Links));
            if (!string.IsNullOrWhiteSpace(Query)) query.Add("query", query);
            if (Sort != null) query.Add("sort", StringUtils.ToUnderscore(Sort));
            if (Direction != null) query.Add("direction", Direction == VimeoSortDirection.Descending ? "desc" : "asc");
            return query;
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpRequest"/> representing the request.
        /// </summary>
        public override IHttpRequest GetRequest() {
            return new HttpRequest(HttpMethod.Get, "/videos", GetQueryString());
        }

        #endregion

    }

}