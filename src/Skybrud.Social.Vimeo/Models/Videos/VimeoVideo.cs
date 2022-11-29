using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Vimeo.Models.Tags;
using Skybrud.Social.Vimeo.Models.Users;

namespace Skybrud.Social.Vimeo.Models.Videos {
    
    /// <summary>
    /// Class describing a Vimeo video.
    /// </summary>
    public class VimeoVideo : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the video. The ID isn't directly specified by the Vimeo API, but is derived from the <see cref="Uri"/> property.
        /// </summary>
        public long Id  { get; }

        /// <summary>
        /// Gets the URI of the Vimeo video.
        /// </summary>
        public string Uri  { get; }

        /// <summary>
        /// Gets the name of the Vimeo video.
        /// </summary>
        public string Name  { get; }

        /// <summary>
        /// Gets the description of the Vimeo video.
        /// </summary>
        public string? Description  { get; }

        /// <summary>
        /// Gets whether the video has a description. If true, the description can be read from the
        /// <see cref="Description"/> property.
        /// </summary>
        [MemberNotNullWhen(true, "Description")]
        public bool HasDescription => string.IsNullOrWhiteSpace(Description) == false;

        // TODO: Add support for property "type": (enum: video)

        /// <summary>
        /// Gets the link (URL for the video page) of the Vimeo video.
        /// </summary>
        public string Link  { get; }

        // TODO: Add support for property "player_embed_url": (string)

        /// <summary>
        /// Gets the duration of the video.
        /// </summary>
        public TimeSpan Duration  { get; }

        /// <summary>
        /// Gets the width of the video.
        /// </summary>
        public int Width  { get; }

        /// <summary>
        /// Gets the language of the video.
        /// </summary>
        public string Language  { get; }

        /// <summary>
        /// Gets the height of the video.
        /// </summary>
        public int Height  { get; }

        /// <summary>
        /// Gets embedding details for the video.
        /// </summary>
        public VimeoVideoEmbed Embed { get; }

        /// <summary>
        /// Gets the timestamp for when the video was created.
        /// </summary>
        public EssentialsTime CreatedTime  { get; }

        /// <summary>
        /// Gets the timestamp for when the video was last modified.
        /// </summary>
        public EssentialsTime ModifiedTime  { get; }

        /// <summary>
        /// Gets the timestamp for when the video was released.
        /// </summary>
        public EssentialsTime ReleaseTime  { get; }

        // TODO: Add support for property "content_rating": (array)
        // TODO: Add support for property "content_rating_class": (string/enum: "safe")
        // TODO: Add support for property "rating_mod_locked": (bool)
        // TODO: Add support for property "license": (????)
        // TODO: Add support for property "privacy": (object)

        /// <summary>
        /// Gets a reference to the pictures of the video.
        /// </summary>
        public VimeoVideoPictureList Pictures { get; }

        /// <summary>
        /// Gets an array with the tags of the video.
        /// </summary>
        public IReadOnlyList<VimeoTag> Tags { get; }

        /// <summary>
        /// Gets whether the video has any tags.
        /// </summary>
        public bool HasTags => Tags.Count > 0;

        /// <summary>
        /// Gets a reference to statistics about the video.
        /// </summary>
        public VimeoVideoStats Stats { get; }

        // TODO: Add support for property "categories": (array)

        // TODO: Add support for property "uploader": (object)

        /// <summary>
        /// Gets the meta data of the video.
        /// </summary>
        public VimeoVideoMetaData MetaData { get; }

        /// <summary>
        /// Gets a reference to the user who uploaded the video.
        /// </summary>
        public VimeoUser User { get; }

        // TODO: Add support for property "play": (object)

        // TODO: Add support for property "app": (object)

        // TODO: Add support for property "status": (string/enum: "available")

        /// <summary>
        /// Gets the resource key of the video.
        /// </summary>
        public string ResourceKey  { get; }

        /// <summary>
        /// Gets a reference to the files for the video.
        /// </summary>
        public IReadOnlyList<VimeoVideoFile> Files { get; }

        // TODO: Add support for property "upload": (????)

        // TODO: Add support for property "transcode": (????)

        // TODO: Add support for property "is_playable": (bool)

        // TODO: Add support for property "has_audio": (bool)

        #endregion

        #region Constructors

        private VimeoVideo(JObject obj) : base(obj) {
            Uri = obj.GetString("uri")!;
            Id = long.Parse(Uri.Split('/').Last());
            Name = obj.GetString("name")!;
            Description = obj.GetString("description");
            Link = obj.GetString("link")!;
            Duration = obj.GetDouble("duration", TimeSpan.FromSeconds);
            Width = obj.GetInt32("width");
            Language = obj.GetString("language")!;
            Height = obj.GetInt32("height");
            Embed = obj.GetObject("embed", VimeoVideoEmbed.Parse)!;
            CreatedTime = obj.GetString("created_time", EssentialsTime.Parse)!;
            ModifiedTime = obj.GetString("modified_time", EssentialsTime.Parse)!;
            ReleaseTime = obj.GetString("release_time", EssentialsTime.Parse)!;
            // "content_rating"
            // "license"
            // "privacy"
            Pictures = obj.GetObject("pictures", VimeoVideoPictureList.Parse)!;
            Tags = obj.GetArrayItems("tags", VimeoTag.Parse)!;
            Stats = obj.GetObject("stats", VimeoVideoStats.Parse)!;
            MetaData = obj.GetObject("metadata", VimeoVideoMetaData.Parse)!;
            User = obj.GetObject("user", VimeoUser.Parse)!;
            // "app"
            // "status"
            ResourceKey = obj.GetString("resource_key")!;
            // "embed_presets"
            Files = obj.GetArrayItems("files", VimeoVideoFile.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideo"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideo"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static VimeoVideo? Parse(JObject? obj) {
            return obj == null ? null : new VimeoVideo(obj);
        }

        #endregion

    }

}