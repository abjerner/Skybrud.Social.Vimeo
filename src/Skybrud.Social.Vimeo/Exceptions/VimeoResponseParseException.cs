using System;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.Vimeo.Exceptions {

    /// <summary>
    /// Exception class representing a response parse error.
    /// </summary>
    public class VimeoResponseParseException : VimeoException {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying <see cref="IHttpResponse"/> that resulted in the error.
        /// </summary>
        public IHttpResponse Response { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that resulted in the error.</param>
        public VimeoResponseParseException(IHttpResponse response) : this(response, null) {
            Response = response;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that resulted in the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <see langword="null"/> reference if no inner exception is specified.</param>
        public VimeoResponseParseException(IHttpResponse response, Exception? innerException) : base("Failed parsing HTTP response from the Vimeo API.", innerException!) {
            Response = response;
        }

        #endregion

    }

}