using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Videos {

    /// <summary>
    /// Class representing the connections of a Vimeo video.
    /// </summary>
    public class VimeoVideoConnections : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets information about the comments of the video.
        /// </summary>
        public VimeoConnectionsItem Comments { get; }

        /// <summary>
        /// Gets information about the credits of the video.
        /// </summary>
        public VimeoConnectionsItem Credits { get; }

        /// <summary>
        /// Gets information about the likes of the video.
        /// </summary>
        public VimeoConnectionsItem Likes { get; }

        /// <summary>
        /// Gets information about the pictures of the video.
        /// </summary>
        public VimeoConnectionsItem Pictures { get; }

        /// <summary>
        /// Gets information about the text tracks of the video.
        /// </summary>
        public VimeoConnectionsItem TextTracks { get; }

        /// <summary>
        /// Gets information about the related videos of the video.
        /// </summary>
        public VimeoConnectionsItem Related { get; }

        #endregion

        #region Constructors

        private VimeoVideoConnections(JObject obj) : base(obj) {
            Comments = obj.GetObject("comments", VimeoConnectionsItem.Parse);
            Credits = obj.GetObject("credits", VimeoConnectionsItem.Parse);
            Likes = obj.GetObject("likes", VimeoConnectionsItem.Parse);
            Pictures = obj.GetObject("pictures", VimeoConnectionsItem.Parse);
            TextTracks = obj.GetObject("texttracks", VimeoConnectionsItem.Parse);
            Related = obj.GetObject("related", VimeoConnectionsItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideoConnections"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoConnections"/>.</returns>
        public static VimeoVideoConnections Parse(JObject obj) {
            return obj == null ? null : new VimeoVideoConnections(obj);
        }

        #endregion

    }

}