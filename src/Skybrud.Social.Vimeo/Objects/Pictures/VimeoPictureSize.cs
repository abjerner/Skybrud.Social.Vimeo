using System;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions;

namespace Skybrud.Social.Vimeo.Objects.Pictures {
    
    /// <summary>
    /// Class representing a size (thumbnail) of a <see cref="VimeoPicture"/>.
    /// </summary>
    public class VimeoPictureSize : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the width of the size.
        /// </summary>
        public int Width { get; private set; }
        
        /// <summary>
        /// Gets the height of the size.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the URL of the size.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// Gets the URL of the size with a play button.
        /// </summary>
        public string LinkWithPlayButton { get; private set; }

        /// <summary>
        /// Gets whether the <see cref="LinkWithPlayButton"/> property has a value.
        /// </summary>
        public bool HasLinkWithPlayButton {
            get { return !String.IsNullOrWhiteSpace(LinkWithPlayButton); }
        }

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
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoPictureSize"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoPicture"/>.</returns>
        public static VimeoPictureSize Parse(JObject obj) {
            return obj == null ? null : new VimeoPictureSize(obj);
        }

        #endregion

    }

}