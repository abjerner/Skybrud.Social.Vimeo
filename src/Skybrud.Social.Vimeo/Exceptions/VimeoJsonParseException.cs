using System;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Vimeo.Exceptions {

    /// <summary>
    /// Exception class representing a JSON parse error.
    /// </summary>
    public class VimeoJsonParseException : VimeoException {

        #region Properties
        
        /// <summary>
        /// Gets the <see cref="JToken"/> that resulted in the error.
        /// </summary>
        public JToken Json { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> token.
        /// </summary>
        /// <param name="json">The JSON token that resulted in the error.</param>
        public VimeoJsonParseException(JToken json) : this(json, null) {
            Json = json;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> token.
        /// </summary>
        /// <param name="json">The JSON token that resulted in the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <see langword="null"/> reference if no inner exception is specified.</param>
        public VimeoJsonParseException(JToken json, Exception? innerException) : base("Failed parsing JSON object.\r\n\r\n" + json, innerException!) {
            Json = json;
        }

        #endregion

    }

}