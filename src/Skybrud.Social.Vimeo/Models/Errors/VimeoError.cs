using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Errors {

    /// <summary>
    /// Class representing an error returned by the Vimeo API.
    /// </summary>
    public class VimeoError {

        #region Properties

        /// <summary>
        /// Gets the user oriented error message.
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Gets the URL to a page with information about the error - or <see langword="null"/> if no URL is available.
        /// </summary>
        public string? Link { get; }

        /// <summary>
        /// Gets the developer oriented error message - or <see langword="null"/> if not available.
        /// </summary>
        public string? DeveloperMessage { get; }

        /// <summary>
        /// Gets the error code - or <see langword="null"/> if not available.
        /// </summary>
        public int? ErrorCode { get; }

        #endregion

        #region Constructors

        private VimeoError(JObject json) {
            Error = json.GetString("error")!;
            Link = json.GetString("link");
            DeveloperMessage = json.GetString("developer_message");
            ErrorCode = json.TryGetInt32("error_code", out int errorCode) ? errorCode : null;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoError"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoError"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoError? Parse(JObject? json) {
            return json == null ? null : new VimeoError(json);
        }

        #endregion

    }

}