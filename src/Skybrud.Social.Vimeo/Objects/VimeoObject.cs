using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Vimeo.Objects {
    
    /// <summary>
    /// Class representing a basic object from the Vimeo API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the internal <see cref="JObject"/> the object was created from.
        /// </summary>
        [JsonIgnore]
        public JObject JObject { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoObject"/>.</returns>
        protected VimeoObject(JObject obj) {
            JObject = obj;
        }

        #endregion

    }

}