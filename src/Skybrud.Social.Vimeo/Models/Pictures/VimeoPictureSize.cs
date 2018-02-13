using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Pictures {
    
    /// <summary>
    /// Class representing a size (thumbnail) of a <see cref="VimeoPicture"/>.
    /// </summary>
    public class VimeoPictureSize : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the width of the size.
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// Gets the height of the size.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the URL of the size.
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Gets the URL of the size with a play button.
        /// </summary>
        public string LinkWithPlayButton { get; }

        /// <summary>
        /// Gets whether the <see cref="LinkWithPlayButton"/> property has a value.
        /// </summary>
        public bool HasLinkWithPlayButton => !String.IsNullOrWhiteSpace(LinkWithPlayButton);

        #endregion

        #region Constructors

        private VimeoPictureSize(JObject obj) : base(obj) {
            Width = obj.GetInt32("width");
            Height = obj.GetInt32("height");
            Link = obj.GetString("link");
            LinkWithPlayButton = obj.GetString("link_with_play_button");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoPictureSize"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoPicture"/>.</returns>
        public static VimeoPictureSize Parse(JObject obj) {
            return obj == null ? null : new VimeoPictureSize(obj);
        }

        #endregion

    }

}