using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Tags {

    /// <summary>
    /// Class describing a Vimeo tag.
    /// </summary>
    public class VimeoTag : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the URI of the Vimeo tag.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets the name of the Vimeo tag.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the URL name of the Vimeo tag.
        /// </summary>
        public string Tag { get; }

        /// <summary>
        /// Gets the canonical name of the Vimeo tag.
        /// </summary>
        public string Canonical { get; }

        /// <summary>
        /// Gets the meta data of the tag.
        /// </summary>
        public VimeoTagMetaData MetaData { get; }

        /// <summary>
        /// Gets the resource key of the tag.
        /// </summary>
        public string ResourceKey { get; }

        #endregion

        #region Constructors

        private VimeoTag(JObject json) : base(json) {
            Uri = json.GetString("uri")!;
            Name = json.GetString("name")!;
            Tag = json.GetString("tag")!;
            Canonical = json.GetString("canonical")!;
            MetaData = json.GetObject("metadata", VimeoTagMetaData.Parse)!;
            ResourceKey = json.GetString("resource_key")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoTag"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoTag"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoTag? Parse(JObject? json) {
            return json == null ? null : new VimeoTag(json);
        }

        #endregion

    }

}