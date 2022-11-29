using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.Vimeo.Exceptions;

namespace Skybrud.Social.Vimeo.Models.Pictures {

    /// <summary>
    /// Class representing a Vimeo picture (eg. of a channel or user).
    /// </summary>
    public class VimeoPicture : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the picture.
        /// </summary>
        public long? Id { get; }

        /// <summary>
        /// Gets the URI of the picture. If this object describes the default picture in a given context, the value of
        /// this property may be <see langword="null"/>.
        /// </summary>
        public string? Uri { get; }

        /// <summary>
        /// Gets whether the <see cref="Uri"/> property has a value.
        /// </summary>
        [MemberNotNullWhen(true, "Id", "Uri")]
        public bool HasUri => Uri is not null;

        /// <summary>
        /// Gets whether the picture is currently active.
        /// </summary>
        public bool IsActive { get; }

        /// <summary>
        /// Gets the type of the picture.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the sizes/thumbnails of the picture.
        /// </summary>
        public IReadOnlyList<VimeoPictureSize> Sizes { get; }

        /// <summary>
        /// Gets the resource key of the channel.
        /// </summary>
        public string ResourceKey { get; }

        #endregion

        #region Constructors

        private VimeoPicture(JObject json) : base(json) {
            try {
                Uri = json.GetString("uri");
                Id = Uri?.Split('/').Last().ToInt64();
                IsActive = json.GetBoolean("active");
                Type = json.GetString("type")!;
                Sizes = json.GetArrayItems("sizes", VimeoPictureSize.Parse)!;
                ResourceKey = json.GetString("resource_key")!;
            } catch (Exception ex) {
                throw new VimeoJsonParseException(json, ex);
            }
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoPicture"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoPicture"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoPicture? Parse(JObject? json) {
            return json == null ? null : new VimeoPicture(json);
        }

        #endregion

    }

}