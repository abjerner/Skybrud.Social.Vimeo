﻿using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

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
        public bool HasLinkWithPlayButton => !string.IsNullOrWhiteSpace(LinkWithPlayButton);

        #endregion

        #region Constructors

        private VimeoPictureSize(JObject json) : base(json) {
            Width = json.GetInt32("width");
            Height = json.GetInt32("height");
            Link = json.GetString("link")!;
            LinkWithPlayButton = json.GetString("link_with_play_button")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoPictureSize"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoPicture"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoPictureSize? Parse(JObject? json) {
            return json == null ? null : new VimeoPictureSize(json);
        }

        #endregion

    }

}