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
        public string Uri  { get; }

        /// <summary>
        /// Gets the name of the Vimeo tag.
        /// </summary>
        public string Name  { get; }

        /// <summary>
        /// Gets the URL name of the Vimeo tag.
        /// </summary>
        public string Tag  { get; }

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
        public string ResourceKey  { get; }

        #endregion

        #region Constructors

        private VimeoTag(JObject obj) : base(obj) {
            Uri = obj.GetString("uri")!;
            Name = obj.GetString("name")!;
            Tag = obj.GetString("tag")!;
            Canonical = obj.GetString("canonical")!;
            MetaData = obj.GetObject("metadata", VimeoTagMetaData.Parse)!;
            ResourceKey = obj.GetString("resource_key")!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoTag"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoTag"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static VimeoTag? Parse(JObject? obj) {
            return obj == null ? null : new VimeoTag(obj);
        }

        #endregion

    }

}