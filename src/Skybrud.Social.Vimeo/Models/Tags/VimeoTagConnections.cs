using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Tags {

    /// <summary>
    /// Class representing the connections of a Vimeo tags.
    /// </summary>
    public class VimeoTagConnections : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets information about the videos with this tag.
        /// </summary>
        public VimeoConnectionsItem Videos { get; }

        #endregion

        #region Constructors

        private VimeoTagConnections(JObject json) : base(json) {
            Videos = json.GetObject("videos", VimeoConnectionsItem.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoTagConnections"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoTagConnections"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoTagConnections? Parse(JObject? json) {
            return json == null ? null : new VimeoTagConnections(json);
        }

        #endregion

    }

}