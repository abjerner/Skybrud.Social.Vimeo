using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Tags {

    /// <summary>
    /// Class representing the meta data of a Vimeo tag.
    /// </summary>
    public class VimeoTagMetaData : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets information about the connections of the channel.
        /// </summary>
        public VimeoTagConnections Connections { get; }

        #endregion

        #region Constructors

        private VimeoTagMetaData(JObject json) : base(json) {
            Connections = json.GetObject("connections", VimeoTagConnections.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoTagMetaData"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoTagMetaData"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoTagMetaData? Parse(JObject? json) {
            return json == null ? null : new VimeoTagMetaData(json);
        }

        #endregion

    }

}