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

        private VimeoConnectionsItem(JObject json) : base(json) {
            Uri = json.GetString("uri")!;
            Options = json.GetStringArray("options");
            Total = json.GetInt32("total");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoConnectionsItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoConnectionsItem"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoConnectionsItem? Parse(JObject? json) {
            return json == null ? null : new VimeoConnectionsItem(json);
        }

        #endregion

    }

}