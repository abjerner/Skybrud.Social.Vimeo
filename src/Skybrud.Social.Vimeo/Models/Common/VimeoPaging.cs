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

        private VimeoPaging(JObject obj) : base(obj) {
            Next = obj.GetString("next");
            Previous = obj.GetString("previous");
            First = obj.GetString("first");
            Last = obj.GetString("last");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoPaging"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoPaging"/>.</returns>
        public static VimeoPaging Parse(JObject obj) {
            return obj == null ? null : new VimeoPaging(obj);
        }

        #endregion

    }

}