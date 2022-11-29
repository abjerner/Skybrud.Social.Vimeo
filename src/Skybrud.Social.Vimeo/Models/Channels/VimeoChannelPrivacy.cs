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

        private VimeoChannelPrivacy(JObject obj) : base(obj) {
            View = obj.GetEnum<VimeoChannelPrivacyStatus>("view");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoChannelPrivacy"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannelPrivacy"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static VimeoChannelPrivacy? Parse(JObject? obj) {
            return obj == null ? null : new VimeoChannelPrivacy(obj);
        }

        #endregion

    }

}