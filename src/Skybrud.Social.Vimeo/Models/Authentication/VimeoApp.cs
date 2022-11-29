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

        private VimeoApp(JObject obj) : base(obj) {
            Name = obj.GetString("name")!;
            Uri = obj.GetString("uri")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoApp"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoApp"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static VimeoApp? Parse(JObject? obj) {
            return obj == null ? null : new VimeoApp(obj);
        }

        #endregion

    }

}