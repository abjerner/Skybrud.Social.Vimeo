using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions;

namespace Skybrud.Social.Vimeo.Objects.Users {
    
    /// <summary>
    /// Class describing a Vimeo user.
    /// </summary>
    public class VimeoUser : VimeoObject {

        #region Properties

        public long Id { get; private set; }

        public string Uri { get; private set; }

        public string Name { get; private set; }

        public string Link { get; private set; }

        public string Location { get; private set; }

        public bool HasLocation {
            get { return !String.IsNullOrWhiteSpace(Location); }
        }

        public string Bio { get; private set; }

        public bool HasBio {
            get { return !String.IsNullOrWhiteSpace(Bio); }
        }

        #endregion

        #region Constructors

        private VimeoUser(JObject obj) : base(obj) {
            Uri = obj.GetString("uri");
            Id = Int64.Parse(Uri.Split('/').Last());
            Name = obj.GetString("name");
            Link = obj.GetString("link");
            Location = obj.GetString("location");
            Bio = obj.GetString("bio");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoUser"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoUser"/>.</returns>
        public static VimeoUser Parse(JObject obj) {
            return obj == null ? null : new VimeoUser(obj);
        }

        #endregion

    }

}