using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Channels {

    public class VimeoMetaDataConnectionsItem : VimeoObject {

        #region Properties

        public string Uri { get; }

        public string[] Options { get; }

        public int Total { get; }

        #endregion

        #region Constructors

        private VimeoMetaDataConnectionsItem(JObject obj) : base(obj) {
            Uri = obj.GetString("uri");
            Options = obj.GetStringArray("options");
            Total = obj.GetInt32("total");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoMetaDataConnectionsItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoMetaDataConnectionsItem"/>.</returns>
        public static VimeoMetaDataConnectionsItem Parse(JObject obj) {
            return obj == null ? null : new VimeoMetaDataConnectionsItem(obj);
        }

        #endregion

    }

}