using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Videos {
    
    /// <summary>
    /// Class representing a collection of videos as returned by the Vimeo API.
    /// </summary>
    public class VimeoVideosCollection : VimeoCollection {

        #region Properties
        
        /// <summary>
        /// Gets the videos of the collection.
        /// </summary>
        public VimeoVideo[] Data { get; }

        #endregion

        #region Constructors

        private VimeoVideosCollection(JObject obj) : base(obj) {
            Data = obj.GetArrayItems("data", VimeoVideo.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideosCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideosCollection"/>.</returns>
        public new static VimeoVideosCollection Parse(JObject obj) {
            return obj == null ? null : new VimeoVideosCollection(obj);
        }

        #endregion
    
    }

}