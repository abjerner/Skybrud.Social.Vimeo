using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Users {
    
    /// <summary>
    /// Class describing a website of a Vimeo user.
    /// </summary>
    public class VimeoUserWebsite : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the name of the website.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the link (URL) of the website.
        /// </summary>
        public string Link { get; private set; }

        /// <summary>
        /// Gets the description of the website. Use the <see cref="HasDescription"/> property to check whether a
        /// description has been specified.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets whether the website has a description. If true, the description can be read from the
        /// <see cref="Description"/> property.
        /// </summary>
        public bool HasDescription {
            get { return !String.IsNullOrWhiteSpace(Description); }
        }

        #endregion

        #region Constructors

        private VimeoUserWebsite(JObject obj) : base(obj) {
            Name = obj.GetString("name");
            Link = obj.GetString("link");
            Description = obj.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoUserWebsite"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoUserWebsite"/>.</returns>
        public static VimeoUserWebsite Parse(JObject obj) {
            return obj == null ? null : new VimeoUserWebsite(obj);
        }

        #endregion

    }

}