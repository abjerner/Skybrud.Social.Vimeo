using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Authentication {

    /// <summary>
    /// Class describing a Vimeo app.
    /// </summary>
    public class VimeoApp : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the name of the app.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the URI of the app.
        /// </summary>
        public string Uri { get; }

        #endregion

        #region Constructors

        private VimeoApp(JObject json) : base(json) {
            Name = json.GetString("name")!;
            Uri = json.GetString("uri")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoApp"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoApp"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoApp? Parse(JObject? json) {
            return json == null ? null : new VimeoApp(json);
        }

        #endregion

    }

}