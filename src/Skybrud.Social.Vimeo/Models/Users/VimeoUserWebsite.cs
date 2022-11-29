using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Users {

    /// <summary>
    /// Class describing a website of a Vimeo user.
    /// </summary>
    public class VimeoUserWebsite : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the name of the website.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the link (URL) of the website.
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Gets the description of the website. Use the <see cref="HasDescription"/> property to check whether a
        /// description has been specified.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Gets whether the website has a description. If true, the description can be read from the
        /// <see cref="Description"/> property.
        /// </summary>
        [MemberNotNullWhen(true, "Description")]
        public bool HasDescription => string.IsNullOrWhiteSpace(Description) == false;

        #endregion

        #region Constructors

        private VimeoUserWebsite(JObject json) : base(json) {
            Name = json.GetString("name")!;
            Link = json.GetString("link")!;
            Description = json.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoUserWebsite"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoUserWebsite"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoUserWebsite? Parse(JObject? json) {
            return json == null ? null : new VimeoUserWebsite(json);
        }

        #endregion

    }

}