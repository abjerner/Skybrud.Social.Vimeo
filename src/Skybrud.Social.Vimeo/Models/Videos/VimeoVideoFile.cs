using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Vimeo.Models.Videos {

    /// <summary>
    /// Class describing a file of a Vimeo video.
    /// </summary>
    public class VimeoVideoFile : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the video quality.
        /// </summary>
        public VimeoVideoQuality Quality { get; }

        /// <summary>
        /// Gets the MIME type of the video file - eg. <c>video/mp4</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the width in pixels.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height in pixels.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the Vimeo src link including OAuth token that can be used in HTML5 video elements.
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Gets the timestamp for when the file was created.
        /// </summary>
        public EssentialsTime CreatedTime { get; }

        /// <summary>
        /// Gets the frames per second of the video file.
        /// </summary>
        public int Fps { get; }

        /// <summary>
        /// Gets the video file's size in bytes.
        /// </summary>
        public long Size { get; }

        /// <summary>
        /// Gets the MD5 hash of the file.
        /// </summary>
        public string Md5 { get; }

        /// <summary>
        /// Gets the public name of the quality of the file - eg <c>HD 1080p</c>.
        /// </summary>
        public string PublicName { get; }

        /// <summary>
        /// Gets the video file's size in a more readable way - eg <c>32.18MB</c>.
        /// </summary>
        public string SizeShort { get; }

        #endregion

        #region Constructors

        private VimeoVideoFile(JObject json) : base(json) {
            Quality = json.GetString("quality", ParseQuality);
            Type = json.GetString("type")!;
            Width = json.GetInt32("width");
            Height = json.GetInt32("height");
            Link = json.GetString("link")!;
            CreatedTime = json.GetString("created_time", EssentialsTime.Parse)!;
            Fps = json.GetInt32("fps");
            Size = json.GetInt64("size");
            Md5 = json.GetString("md5")!;
            PublicName = json.GetString("public_name")!;
            SizeShort = json.GetString("size_short")!;
        }

        #endregion

        #region Static methods

        private static VimeoVideoQuality ParseQuality(string value) {
            return value switch {
                "sd" => VimeoVideoQuality.Standard,
                "hd" => VimeoVideoQuality.HighDefinition,
                "mobile" => VimeoVideoQuality.Mobile,
                "hls" => VimeoVideoQuality.Streaming,
                _ => VimeoVideoQuality.Unrecognized
            };
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoVideoFile"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoFile"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoVideoFile? Parse(JObject? json) {
            return json == null ? null : new VimeoVideoFile(json);
        }

        #endregion

    }

}