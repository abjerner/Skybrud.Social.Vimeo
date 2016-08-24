﻿using System;
using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.Vimeo.Exceptions {

    /// <summary>
    /// Class representing an exception based on an error from one of the Vimeo API.
    /// </summary>
    public class VimeoException : Exception {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="SocialHttpResponse"/>.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the HTTP status code returned by the Vimeo API.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public string Error { get; private set; }

        /// <summary>
        /// Gets the error description.
        /// </summary>
        public string ErrorDescription { get; private set; }

        #endregion

        #region Constructors

        public VimeoException(SocialHttpResponse response, string error, string errorDescription) : base("Invalid response received from the Vimeo API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
            StatusCode = response.StatusCode;
            Error = error;
            ErrorDescription = errorDescription;
        }

        #endregion

    }

}