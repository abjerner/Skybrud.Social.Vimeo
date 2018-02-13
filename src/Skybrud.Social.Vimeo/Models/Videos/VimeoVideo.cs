using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;

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
        public bool HasDescription {
            get { return !String.IsNullOrWhiteSpace(Description); }
        }

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
        /// Gets the timestamp for when the video was created.
        /// </summary>
        public EssentialsDateTime CreatedTime  { get; }

        /// <summary>
        /// Gets the timestamp for when the video was last modified.
        /// </summary>
        public EssentialsDateTime ModifiedTime  { get; }

        /// <summary>
        /// Gets the timestamp for when the video was released.
        /// </summary>
        public EssentialsDateTime ReleaseTime  { get; }

        /// <summary>
        /// Gets the resource key of the video.
        /// </summary>
        public string ResourceKey  { get; }

        #endregion

        #region Constructors

        private VimeoVideo(JObject obj) : base(obj) {
            Uri = obj.GetString("uri");
            Id = Int64.Parse(Uri.Split('/').Last());
            Name = obj.GetString("name");
            Description = obj.GetString("description");
            Link = obj.GetString("link");
            Duration = obj.GetDouble("duration", TimeSpan.FromSeconds);
            Width = obj.GetInt32("width");
            Language = obj.GetString("language");
            Height = obj.GetInt32("height");
            // "embed"
            CreatedTime = obj.GetString("created_time", EssentialsDateTime.Parse);
            ModifiedTime = obj.GetString("modified_time", EssentialsDateTime.Parse);
            ReleaseTime = obj.GetString("release_time", EssentialsDateTime.Parse);
            // "content_rating"
            // "license"
            // "privacy"
            // "pictures"
            // "tags"
            // "stats"
            // "metadata" (mostly used when exploring the API, so not a priority)
            // "user"
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