using System;
using Skybrud.Social.Interfaces.Http;

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
        public bool HasUserId {
            get { return UserId > 0; }
        }
        
        /// <summary>
        /// Gets or sets the username of the parent user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets whether a username has been specified.
        /// </summary>
        public bool HasUsername {
            get { return !String.IsNullOrWhiteSpace(Username); }
        }

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

        public override IHttpQueryString GetQueryString() {
            IHttpQueryString query = base.GetQueryString();
            return query;
        }

        #endregion

    }

}