using System;
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

        /// <summary>
        /// Initializes a new exception based on the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response that contained or triggered the error.</param>
        /// <param name="error">The error code.</param>
        /// <param name="errorDescription">The description about the error.</param>
        public VimeoException(SocialHttpResponse response, string error, string errorDescription) : base("Invalid response received from the Vimeo API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
            StatusCode = response.StatusCode;
            Error = error;
            ErrorDescription = errorDescription;
        }

        #endregion

    }

}