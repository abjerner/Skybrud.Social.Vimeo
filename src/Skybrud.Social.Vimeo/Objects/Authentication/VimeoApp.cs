using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions;

namespace Skybrud.Social.Vimeo.Objects.Authentication {
    
    /// <summary>
    /// Class describing a Vimeo app.
    /// </summary>
    public class VimeoApp : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the name of the app.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the URI of the app.
        /// </summary>
        public string Uri { get; private set; }

        #endregion

        #region Constructors

        private VimeoApp(JObject obj) : base(obj) {
            Name = obj.GetString("name");
            Uri = obj.GetString("uri");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoApp"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoApp"/>.</returns>
        public static VimeoApp Parse(JObject obj) {
            return obj == null ? null : new VimeoApp(obj);
        }

        #endregion

    }

}