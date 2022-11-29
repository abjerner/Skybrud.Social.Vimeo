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

        private VimeoChannelList(JObject obj) : base(obj) {
            Data = obj.GetArrayItems("data", VimeoChannel.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoChannelList"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannelList"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public new static VimeoChannelList? Parse(JObject? obj) {
            return obj == null ? null : new VimeoChannelList(obj);
        }

        #endregion
    
    }

}