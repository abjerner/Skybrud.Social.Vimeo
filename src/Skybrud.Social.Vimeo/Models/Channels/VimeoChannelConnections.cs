using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Channels {

    /// <summary>
    /// Class representing the connections of a Vimeo channel.
    /// </summary>
    public class VimeoChannelConnections : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets information about the users of the channel.
        /// </summary>
        public VimeoConnectionsItem Users { get; }

        /// <summary>
        /// Gets information about the videos of the channel.
        /// </summary>
        public VimeoConnectionsItem Videos { get; }

        #endregion

        #region Constructors

        private VimeoChannelConnections(JObject obj) : base(obj) {
            Users = obj.GetObject("users", VimeoConnectionsItem.Parse);
            Videos = obj.GetObject("videos", VimeoConnectionsItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoChannelConnections"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannelConnections"/>.</returns>
        public static VimeoChannelConnections Parse(JObject obj) {
            return obj == null ? null : new VimeoChannelConnections(obj);
        }

        #endregion

    }

}