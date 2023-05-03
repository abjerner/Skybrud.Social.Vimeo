using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft;

namespace Skybrud.Social.Vimeo.Models {

    /// <summary>
    /// Class representing a basic object from the Vimeo API derived from an instance of <see cref="JObject"/>.
    /// </summary>
    public class VimeoObject : JsonObjectBase {

        #region Properties

        /// <summary>
        /// Gets the internal <see cref="Newtonsoft.Json.Linq.JObject"/> the object was created from.
        /// </summary>
        [JsonIgnore]
        public new JObject JObject => base.JObject!;

        #endregion

        #region Constructor

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoObject"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        protected VimeoObject(JObject json) : base(json) { }

        #endregion

    }

}