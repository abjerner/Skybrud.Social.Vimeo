using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Channels {

    /// <summary>
    /// Class with privacy information about a Vimeo channel.
    /// </summary>
    public class VimeoChannelPrivacy : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the privacy status of the channel.
        /// </summary>
        public VimeoChannelPrivacyStatus View { get; }

        #endregion

        #region Constructors

        private VimeoChannelPrivacy(JObject json) : base(json) {
            View = json.GetEnum<VimeoChannelPrivacyStatus>("view");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoChannelPrivacy"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannelPrivacy"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoChannelPrivacy? Parse(JObject? json) {
            return json == null ? null : new VimeoChannelPrivacy(json);
        }

        #endregion

    }

}