using System;

namespace Skybrud.Social.Vimeo.Exceptions {

    /// <summary>
    /// Exception class representing a parse error.
    /// </summary>
    /// <see cref="VimeoJsonParseException"/>
    /// <see cref="VimeoResponseParseException"/>
    public class VimeoParseException : VimeoException {

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        public VimeoParseException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new exception with the specified <paramref name="message"/>.
        /// </summary>
        /// <param name="message">The message of the exception.</param>
        /// <param name="innerException">The inner exception.</param>
        public VimeoParseException(string message, Exception innerException) : base(message, innerException) { }

    }
}