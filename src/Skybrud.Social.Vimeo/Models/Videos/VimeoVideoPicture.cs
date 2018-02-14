using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos {

    
    /// <summary>
    /// Class describing a picture of a Vimeo video.
    /// </summary>
    public class VimeoVideoPicture : VimeoObject {

        #region Properties

        public string Link { get; }

        public int Width { get; }

        public int Height { get; }

        #endregion

        #region Constructors

        private VimeoVideoPicture(JObject obj) : base(obj) {
            Link = obj.GetString("link");
            Width = obj.GetInt32("width");
            Height = obj.GetInt32("height");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideoPicture"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoPicture"/>.</returns>
        public static VimeoVideoPicture Parse(JObject obj) {
            return obj == null ? null : new VimeoVideoPicture(obj);
        }

        #endregion

    }

}