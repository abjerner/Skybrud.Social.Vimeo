using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.Vimeo.Models.Errors;

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
        /// Gets the error object returned by the Vimeo API - or <see langword="null"/> if not available.
        /// </summary>
        public VimeoError? Error { get; }

        /// <summary>
        /// Gets the error message - or <see langword="null"/> if not available.
        /// </summary>
        public string? ErrorMessage { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        public VimeoHttpException(IHttpResponse response) : base($"Invalid response received from the Vimeo API (status: {(int) response.StatusCode})") {
            Response = response;
            StatusCode = response.StatusCode;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that contained or triggered the error.</param>
        /// <param name="error">An instance of <see cref="VimeoError"/> representing the error.</param>
        public VimeoHttpException(IHttpResponse response, VimeoError error) : base($"Invalid response received from the Vimeo API (status: {(int) response.StatusCode})") {
            Response = response;
            StatusCode = response.StatusCode;
            Error = error;
            ErrorMessage = error.Error;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that contained or triggered the error.</param>
        /// <param name="errorMessage">The error message.</param>
        public VimeoHttpException(IHttpResponse response, string? errorMessage) : base($"Invalid response received from the Vimeo API (status: {(int) response.StatusCode})") {
            Response = response;
            StatusCode = response.StatusCode;
            ErrorMessage = errorMessage;
        }

        #endregion

    }

}