using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Models.Videos {

    /// <summary>
    /// Class representing a list of videos as returned by the Vimeo API.
    /// </summary>
    public class VimeoVideoList : VimeoList {

        #region Properties

        /// <summary>
        /// Gets the videos of the list.
        /// </summary>
        public IReadOnlyList<VimeoVideo> Data { get; }

        #endregion

        #region Constructors

        private VimeoVideoList(JObject json) : base(json) {
            Data = json.GetArrayItems("data", VimeoVideo.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoVideoList"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoList"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public new static VimeoVideoList? Parse(JObject? json) {
            return json == null ? null : new VimeoVideoList(json);
        }

        #endregion

    }

}