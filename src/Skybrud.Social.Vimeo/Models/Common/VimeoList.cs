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
        /// Initializes a new list based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> representing the list.</param>
        protected VimeoList(JObject obj) : base(obj) {
            Total = obj.GetInt32("total");
            Page = obj.GetInt32("page");
            PerPage = obj.GetInt32("per_page");
            Paging = obj.GetObject("paging", VimeoPaging.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoList"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoList"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static VimeoList? Parse(JObject? obj) {
            return obj == null ? null : new VimeoList(obj);
        }

        #endregion

    }

}