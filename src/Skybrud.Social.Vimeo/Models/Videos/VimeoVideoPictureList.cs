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

        private VimeoVideoPictureList(JObject obj) : base(obj) {
            Sizes = obj.GetArrayItems("sizes", VimeoVideoPicture.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideoPictureList"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoPictureList"/>.</returns>
        public static VimeoVideoPictureList? Parse(JObject? obj) {
            return obj == null ? null : new VimeoVideoPictureList(obj);
        }

        #endregion

    }

}