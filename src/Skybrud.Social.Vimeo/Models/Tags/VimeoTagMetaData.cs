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

        private VimeoTagMetaData(JObject obj) : base(obj) {
            Connections = obj.GetObject("connections", VimeoTagConnections.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoTagMetaData"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoTagMetaData"/>.</returns>
        public static VimeoTagMetaData Parse(JObject obj) {
            return obj == null ? null : new VimeoTagMetaData(obj);
        }

        #endregion

    }

}