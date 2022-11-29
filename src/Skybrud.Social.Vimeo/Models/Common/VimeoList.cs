using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Common {

    /// <summary>
    /// Class representing a generic list returned by the Vimeo API.
    /// </summary>
    public class VimeoList : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the total amount of items in the list.
        /// </summary>
        public int Total { get; }

        /// <summary>
        /// Gets the current page.
        /// </summary>
        public int Page { get; }

        /// <summary>
        /// Gets the maximum amount of items per page.
        /// </summary>
        public int PerPage { get; }

        /// <summary>
        /// Gets pagination URLs about the list.
        /// </summary>
        public VimeoPaging Paging { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new list based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The <see cref="JObject"/> representing the list.</param>
        protected VimeoList(JObject json) : base(json) {
            Total = json.GetInt32("total");
            Page = json.GetInt32("page");
            PerPage = json.GetInt32("per_page");
            Paging = json.GetObject("paging", VimeoPaging.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoList"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoList? Parse(JObject? json) {
            return json == null ? null : new VimeoList(json);
        }

        #endregion

    }

}