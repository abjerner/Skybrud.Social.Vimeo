using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.Vimeo.Models {

    /// <summary>
    /// Class representing a basic object from the Vimeo API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class VimeoObject : JsonObjectBase {

        #region Constructor

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoObject"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        protected VimeoObject(JObject json) : base(json) { }

        #endregion

    }

}