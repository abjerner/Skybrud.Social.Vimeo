using System;
using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;

namespace Skybrud.Social.Vimeo.Exceptions {

    /// <summary>
    /// Class representing an exception based on an error from one of the Vimeo API.
    /// </summary>
    public class VimeoHttpException : VimeoException, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/>.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the HTTP status code returned by the Vimeo API.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public string? Error { get; }

        /// <summary>
        /// Gets the error description.
        /// </summary>
        public string? ErrorDescription { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that contained or triggered the error.</param>
        /// <param name="error">The error code.</param>
        /// <param name="errorDescription">The description about the error.</param>
        public VimeoHttpException(IHttpResponse response, string? error, string? errorDescription) : base($"Invalid response received from the Vimeo API (status: {(int) response.StatusCode})") {
            Response = response;
            StatusCode = response.StatusCode;
            Error = error;
            ErrorDescription = errorDescription;
        }

        #endregion

    }

}