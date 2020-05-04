﻿using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Vimeo.Options {
    
    /// <summary>
    /// Class with basic options for a paginated request to the Vimeo API.
    /// </summary>
    public abstract class VimeoPaginationOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the page to show.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of items per page.
        /// </summary>
        public int PerPage { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        protected VimeoPaginationOptions() { }

        /// <summary>
        /// Initializes a new instance with specified options.
        /// </summary>
        /// <param name="page">The page to show.</param>
        /// <param name="perPage">The maximum amount of items per page.</param>
        protected VimeoPaginationOptions(int page, int perPage) {
            Page = page;
            PerPage = perPage;
        }

        #endregion

        #region Members methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        public virtual IHttpQueryString GetQueryString() {
            
            HttpQueryString query = new HttpQueryString();
            
            if (Page > 0) query.Add("page", Page);
            if (PerPage > 0) query.Add("per_page", PerPage);
            
            return query;

        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpRequest"/> representing the request.
        /// </summary>
        public abstract IHttpRequest GetRequest();

        #endregion

    }

}