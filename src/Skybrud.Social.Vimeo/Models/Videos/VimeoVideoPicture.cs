using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos {


    /// <summary>
    /// Class describing a picture of a Vimeo video.
    /// </summary>
    public class VimeoVideoPicture : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the link (URL) of the picture.
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Gets the width of the picture.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the picture.
        /// </summary>
        public int Height { get; }

        #endregion

        #region Constructors

        private VimeoVideoPicture(JObject obj) : base(obj) {
            Link = obj.GetString("link")!;
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
        [return: NotNullIfNotNull("obj")]
        public static VimeoVideoPicture? Parse(JObject? obj) {
            return obj == null ? null : new VimeoVideoPicture(obj);
        }

        #endregion

    }

}