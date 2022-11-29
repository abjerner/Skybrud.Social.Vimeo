using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Channels {

    /// <summary>
    /// Class representing a list of channels as returned by the Vimeo API.
    /// </summary>
    public class VimeoChannelList : VimeoList {

        #region Properties

        /// <summary>
        /// Gets the channels of the list.
        /// </summary>
        public IReadOnlyList<VimeoChannel> Data { get; }

        #endregion

        #region Constructors

        private VimeoChannelList(JObject json) : base(json) {
            Data = json.GetArrayItems("data", VimeoChannel.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoChannelList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannelList"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public new static VimeoChannelList? Parse(JObject? json) {
            return json == null ? null : new VimeoChannelList(json);
        }

        #endregion

    }

}