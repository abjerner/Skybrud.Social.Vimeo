using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;

namespace Skybrud.Social.Vimeo.Objects {
    
    /// <summary>
    /// Class representing a basic object from the Vimeo API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class VimeoObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        protected VimeoObject(JObject obj) : base(obj) { }

        #endregion

    }

}