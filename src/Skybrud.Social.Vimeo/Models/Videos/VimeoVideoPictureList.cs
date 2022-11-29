using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos {

    /// <summary>
    /// Class describing the pictures of a Vimeo video.
    /// </summary>
    public class VimeoVideoPictureList : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the size variations of the picture.
        /// </summary>
        public IReadOnlyList<VimeoVideoPicture> Sizes { get; }

        #endregion

        #region Constructors

        private VimeoVideoPictureList(JObject json) : base(json) {
            Sizes = json.GetArrayItems("sizes", VimeoVideoPicture.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoVideoPictureList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoPictureList"/>.</returns>
        public static VimeoVideoPictureList? Parse(JObject? json) {
            return json == null ? null : new VimeoVideoPictureList(json);
        }

        #endregion

    }

}