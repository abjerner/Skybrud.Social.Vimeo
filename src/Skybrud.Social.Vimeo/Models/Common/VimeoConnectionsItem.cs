using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Common {

    /// <summary>
    /// Class representing the connection between two Vimeo resources.
    /// </summary>
    public class VimeoConnectionsItem : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the API URI for the resource.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets the possible HTTP options for the resource.
        /// </summary>
        public IReadOnlyList<string> Options { get; }

        /// <summary>
        /// Gets the total count.
        /// </summary>
        public int Total { get; }

        #endregion

        #region Constructors

        private VimeoConnectionsItem(JObject obj) : base(obj) {
            Uri = obj.GetString("uri")!;
            Options = obj.GetStringArray("options");
            Total = obj.GetInt32("total");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoConnectionsItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoConnectionsItem"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static VimeoConnectionsItem? Parse(JObject? obj) {
            return obj == null ? null : new VimeoConnectionsItem(obj);
        }

        #endregion

    }

}