using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Objects.Pictures {
    
    /// <summary>
    /// Class representing a Vimeo picture (eg. of a channel or user).
    /// </summary>
    public class VimeoPicture : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the picture.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the URI of the picture.
        /// </summary>
        public string Uri { get; private set; }

        /// <summary>
        /// Gets whether the picture is currently active.
        /// </summary>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Gets the type of the picture.
        /// </summary>
        public string Type { get; private set; }

        /// <summary>
        /// Gets the sizes/thumbnails of the picture.
        /// </summary>
        public VimeoPictureSize[] Sizes { get; private set; }

        /// <summary>
        /// Gets the resource key of the channel.
        /// </summary>
        public string ResourceKey { get; private set; }

        #endregion

        #region Constructors

        private VimeoPicture(JObject obj) : base(obj) {
            Uri = obj.GetString("uri");
            Id = Int64.Parse(Uri.Split('/').Last());
            IsActive = obj.GetBoolean("active");
            Type = obj.GetString("type");
            Sizes = obj.GetArrayItems("sizes", VimeoPictureSize.Parse);
            ResourceKey = obj.GetString("resource_key");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoPicture"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoPicture"/>.</returns>
        public static VimeoPicture Parse(JObject obj) {
            return obj == null ? null : new VimeoPicture(obj);
        }

        #endregion

    }
}