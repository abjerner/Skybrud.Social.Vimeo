using Skybrud.Essentials.Http;

namespace Skybrud.Social.Vimeo.Options.Users {
    
    /// <summary>
    /// Class representing the options for getting a list of user channels.
    /// </summary>
    public class VimeoGetUserChannelsOptions : VimeoPaginationOptions {
        
        #region Properties

        /// <summary>
        /// Gets or sets the ID of the parent user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets whether a user ID has been specified.
        /// </summary>
        public bool HasUserId => UserId > 0;

        /// <summary>
        /// Gets or sets the username of the parent user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets whether a username has been specified.
        /// </summary>
        public bool HasUsername => !string.IsNullOrWhiteSpace(Username);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public VimeoGetUserChannelsOptions() { }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        public VimeoGetUserChannelsOptions(long userId) : this() {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        public VimeoGetUserChannelsOptions(string username) : this() {
            Username = username;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="userId">The ID of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        public VimeoGetUserChannelsOptions(long userId, int page, int perPage) : this() {
            UserId = userId;
            Page = page;
            PerPage = perPage;
        }

        /// <summary>
        /// Initializes a new instance with the specified options.
        /// </summary>
        /// <param name="username">The username of the parent user.</param>
        /// <param name="page">The page to be returned.</param>
        /// <param name="perPage">The maximum amount of pages to be returned per page.</param>
        public VimeoGetUserChannelsOptions(string username, int page, int perPage) : this() {
            Username = username;
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Members methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpRequest"/> representing the request.
        /// </summary>
        public override IHttpRequest GetRequest() {

            // Get channels of the authenticated user?
            if (Username == "me" || HasUserId == false && HasUsername == false)  {
                return new HttpRequest(HttpMethod.Get, "/me/channels", GetQueryString());
            }

            // Get the channels of the user matching either "Username" or "UserId"
            return new HttpRequest(HttpMethod.Get, $"/users/{Username ?? UserId.ToString()}/channels", GetQueryString());

        }

        #endregion

    }

}