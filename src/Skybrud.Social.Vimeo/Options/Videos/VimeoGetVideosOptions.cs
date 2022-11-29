using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Vimeo.Options.Sorting;

namespace Skybrud.Social.Vimeo.Options.Videos {

    /// <summary>
    /// Class representing the options for getting a list of videos of a channel.
    /// </summary>
    public class VimeoGetVideosOptions : VimeoListOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// Gets whether a user ID has been specified.
        /// </summary>
        public bool HasUserId => UserId > 0;

        /// <summary>
        /// Gets or sets the username of the user. Use <c>me</c> to get videos of the authenticated user.
        /// instead.
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// Gets whether a username has been specified.
        /// </summary>
        public bool HasUsername => string.IsNullOrWhiteSpace(Username) == false;

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
        public VimeoGetVideosOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public VimeoGetVideosOptions(long userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        public VimeoGetVideosOptions(long userId, int page, int perPage) {
            UserId = userId;
            Page = page;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public VimeoGetVideosOptions(string username) {
            Username = username;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        public VimeoGetVideosOptions(string username, int page, int perPage) {
            Username = username;
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
            if (Sort != null) query.Add("sort", StringUtils.ToUnderscore(Sort));
            if (Direction != null) query.Add("direction", Direction == VimeoSortDirection.Descending ? "desc" : "asc");
            return query;
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpRequest"/> representing the request.
        /// </summary>
        public override IHttpRequest GetRequest() {

            // Get videos of the authenticated user?
            if (Username == "me" || HasUserId == false && HasUsername == false)  {
                return new HttpRequest(HttpMethod.Get, "/me/videos", GetQueryString());
            }

            // Get the videos of the user matching either "Username" or "UserId"
            return new HttpRequest(HttpMethod.Get, $"/users/{Username ?? UserId.ToString()}/videos", GetQueryString());

        }

        #endregion

    }

}