using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos {

    /// <summary>
    /// Class with statistics about a Vimeo video.
    /// </summary>
    public class VimeoVideoStats : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the total amount of plays the video has received.
        /// </summary>
        public long Plays { get; }

        #endregion

        #region Constructors

        private VimeoVideoStats(JObject json) : base(json) {
            Plays = json.GetInt64("plays");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoVideoStats"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoStats"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoVideoStats? Parse(JObject? json) {
            return json == null ? null : new VimeoVideoStats(json);
        }

        #endregion

    }

}