using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
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
        public string Description  { get; }

        /// <summary>
        /// Gets whether the video has a description. If true, the description can be read from the
        /// <see cref="Description"/> property.
        /// </summary>
        public bool HasDescription => string.IsNullOrWhiteSpace(Description) == false;

        /// <summary>
        /// Gets the link (URL for the video page) of the Vimeo video.
        /// </summary>
        public string Link  { get; }

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

        /// <summary>
        /// Gets a reference to the pictures of the video.
        /// </summary>
        public VimeoVideoPictures Pictures { get; }

        /// <summary>
        /// Gets an array with the tags of the video.
        /// </summary>
        public VimeoTag[] Tags { get; }

        /// <summary>
        /// Gets whether the video has any tags.
        /// </summary>
        public bool HasTags => Tags.Length > 0;

        /// <summary>
        /// Gets a reference to statistics about the video.
        /// </summary>
        public VimeoVideoStats Stats { get; }

        /// <summary>
        /// Gets the meta data of the video.
        /// </summary>
        public VimeoVideoMetaData MetaData { get; }

        /// <summary>
        /// Gets a reference to the user who uploaded the video.
        /// </summary>
        public VimeoUser User { get; }

        /// <summary>
        /// Gets the resource key of the video.
        /// </summary>
        public string ResourceKey  { get; }

        #endregion

        #region Constructors

        private VimeoVideo(JObject obj) : base(obj) {
            Uri = obj.GetString("uri");
            Id = long.Parse(Uri.Split('/').Last());
            Name = obj.GetString("name");
            Description = obj.GetString("description");
            Link = obj.GetString("link");
            Duration = obj.GetDouble("duration", TimeSpan.FromSeconds);
            Width = obj.GetInt32("width");
            Language = obj.GetString("language");
            Height = obj.GetInt32("height");
            Embed = obj.GetObject("embed", VimeoVideoEmbed.Parse);
            CreatedTime = obj.GetString("created_time", EssentialsTime.Parse);
            ModifiedTime = obj.GetString("modified_time", EssentialsTime.Parse);
            ReleaseTime = obj.GetString("release_time", EssentialsTime.Parse);
            // "content_rating"
            // "license"
            // "privacy"
            Pictures = obj.GetObject("pictures", VimeoVideoPictures.Parse);
            Tags = obj.GetArrayItems("tags", VimeoTag.Parse);
            Stats = obj.GetObject("stats", VimeoVideoStats.Parse);
            MetaData = obj.GetObject("metadata", VimeoVideoMetaData.Parse);
            User = obj.GetObject("user", VimeoUser.Parse);
            // "app"
            // "status"
            ResourceKey = obj.GetString("resource_key");
            // "embed_presets"
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideo"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideo"/>.</returns>
        public static VimeoVideo Parse(JObject obj) {
            return obj == null ? null : new VimeoVideo(obj);
        }

        #endregion

    }

}