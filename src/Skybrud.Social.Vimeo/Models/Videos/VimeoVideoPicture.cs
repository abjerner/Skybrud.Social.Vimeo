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

        private VimeoVideoPicture(JObject json) : base(json) {
            Link = json.GetString("link")!;
            Width = json.GetInt32("width");
            Height = json.GetInt32("height");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoVideoPicture"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoPicture"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoVideoPicture? Parse(JObject? json) {
            return json == null ? null : new VimeoVideoPicture(json);
        }

        #endregion

    }

}