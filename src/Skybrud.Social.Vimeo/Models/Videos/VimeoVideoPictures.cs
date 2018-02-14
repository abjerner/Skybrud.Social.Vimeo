using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos {
    
    /// <summary>
    /// Class describing the pictures of a Vimeo video.
    /// </summary>
    public class VimeoVideoPictures : VimeoObject {

        #region Properties

        public VimeoVideoPicture[] Sizes  { get; }

        #endregion

        #region Constructors

        private VimeoVideoPictures(JObject obj) : base(obj) {
            Sizes = obj.GetArrayItems("sizes", VimeoVideoPicture.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideoPictures"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoPictures"/>.</returns>
        public static VimeoVideoPictures Parse(JObject obj) {
            return obj == null ? null : new VimeoVideoPictures(obj);
        }

        #endregion

    }

}