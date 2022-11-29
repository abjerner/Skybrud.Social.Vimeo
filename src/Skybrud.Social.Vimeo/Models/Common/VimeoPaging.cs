using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Common {

    /// <summary>
    /// Class with pagination about an instance of <see cref="VimeoList"/>.
    /// </summary>
    public class VimeoPaging : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string Next { get; }

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string Previous { get; }

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string First { get; }

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string Last { get; }

        #endregion

        #region Constructors

        private VimeoPaging(JObject json) : base(json) {
            Next = json.GetString("next")!;
            Previous = json.GetString("previous")!;
            First = json.GetString("first")!;
            Last = json.GetString("last")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoPaging"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoPaging"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoPaging? Parse(JObject? json) {
            return json == null ? null : new VimeoPaging(json);
        }

        #endregion

    }

}