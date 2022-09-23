using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Pictures {
    
    /// <summary>
    /// Class representing a Vimeo picture (eg. of a channel or user).
    /// </summary>
    public class VimeoPicture : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the picture.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the URI of the picture.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets whether the picture is currently active.
        /// </summary>
        public bool IsActive { get; }

        /// <summary>
        /// Gets the type of the picture.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the sizes/thumbnails of the picture.
        /// </summary>
        public IReadOnlyList<VimeoPictureSize> Sizes { get; }

        /// <summary>
        /// Gets the resource key of the channel.
        /// </summary>
        public string ResourceKey { get; }

        #endregion

        #region Constructors

        private VimeoPicture(JObject obj) : base(obj) {
            Uri = obj.GetString("uri");
            Id = long.Parse(Uri.Split('/').Last());
            IsActive = obj.GetBoolean("active");
            Type = obj.GetString("type");
            Sizes = obj.GetArrayItems("sizes", VimeoPictureSize.Parse);
            ResourceKey = obj.GetString("resource_key");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoPicture"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoPicture"/>.</returns>
        public static VimeoPicture Parse(JObject obj) {
            return obj == null ? null : new VimeoPicture(obj);
        }

        #endregion

    }

}