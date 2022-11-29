using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos {

    /// <summary>
    /// Class representing the meta data of a Vimeo video.
    /// </summary>
    public class VimeoVideoMetaData : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets information about the connections of the video.
        /// </summary>
        public VimeoVideoConnections Connections { get; }

        #endregion

        #region Constructors

        private VimeoVideoMetaData(JObject obj) : base(obj) {
            Connections = obj.GetObject("connections", VimeoVideoConnections.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideoMetaData"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoMetaData"/>.</returns>
        public static VimeoVideoMetaData Parse(JObject obj) {
            return obj == null ? null : new VimeoVideoMetaData(obj);
        }

        #endregion

    }

}