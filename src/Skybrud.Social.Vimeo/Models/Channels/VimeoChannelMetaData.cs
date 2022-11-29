using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Channels {

    /// <summary>
    /// Class representing the meta data of a Vimeo channel.
    /// </summary>
    public class VimeoChannelMetaData : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets information about the connections of the channel.
        /// </summary>
        public VimeoChannelConnections Connections { get; }

        #endregion

        #region Constructors

        private VimeoChannelMetaData(JObject json) : base(json) {
            Connections = json.GetObject("connections", VimeoChannelConnections.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoChannelMetaData"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannelMetaData"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoChannelMetaData? Parse(JObject? json) {
            return json == null ? null : new VimeoChannelMetaData(json);
        }

        #endregion

    }

}