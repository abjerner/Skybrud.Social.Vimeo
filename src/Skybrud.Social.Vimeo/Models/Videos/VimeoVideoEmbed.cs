using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos {

    /// <summary>
    /// Class with embedding details of a Vimeo video.
    /// </summary>
    public class VimeoVideoEmbed : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the HTML for embedding the video.
        /// </summary>
        public string Html { get; }

        #endregion

        #region Constructors

        private VimeoVideoEmbed(JObject json) : base(json) {
            Html = json.GetString("html")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoVideoEmbed"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoEmbed"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoVideoEmbed? Parse(JObject? json) {
            return json == null ? null : new VimeoVideoEmbed(json);
        }

        #endregion

    }

}