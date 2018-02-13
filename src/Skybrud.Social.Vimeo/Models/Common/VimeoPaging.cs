using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Common {
    
    /// <summary>
    /// Class with pagination about an instance of <see cref="VimeoCollection"/>.
    /// </summary>
    public class VimeoPaging : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string Next { get; private set; }

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string Previous { get; private set; }

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string First { get; private set; }

        /// <summary>
        /// Gets the URL for the next page.
        /// </summary>
        public string Last { get; private set; }

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
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoPaging"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoPaging"/>.</returns>
        public static VimeoPaging Parse(JObject obj) {
            return obj == null ? null : new VimeoPaging(obj);
        }

        #endregion

    }

}