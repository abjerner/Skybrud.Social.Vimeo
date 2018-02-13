using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Channels {
    
    public class VimeoChannelsCollection : VimeoCollection {

        #region Properties
        
        public VimeoChannel[] Data { get; private set; }

        #endregion

        #region Constructors

        private VimeoChannelsCollection(JObject obj) : base(obj) {
            Data = obj.GetArrayItems("data", VimeoChannel.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoChannelsCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoChannelsCollection"/>.</returns>
        public new static VimeoChannelsCollection Parse(JObject obj) {
            return obj == null ? null : new VimeoChannelsCollection(obj);
        }

        #endregion
    
    }

}