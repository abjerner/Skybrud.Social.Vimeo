using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Channels {
    
    /// <summary>
    /// Class representing a collection of channels as returned by the Vimeo API.
    /// </summary>
    public class VimeoChannelsCollection : VimeoCollection {

        #region Properties
        
        /// <summary>
        /// Gets the channels of the collection.
        /// </summary>
        public VimeoChannel[] Data { get; }

        #endregion

        #region Constructors

        private VimeoChannelsCollection(JObject obj) : base(obj) {
            Data = obj.GetArrayItems("data", VimeoChannel.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoChannelsCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannelsCollection"/>.</returns>
        public new static VimeoChannelsCollection Parse(JObject obj) {
            return obj == null ? null : new VimeoChannelsCollection(obj);
        }

        #endregion
    
    }

}