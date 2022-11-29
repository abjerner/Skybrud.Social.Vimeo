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

        private VimeoVideoFile(JObject obj) : base(obj) {
            Quality = obj.GetString("quality", ParseQuality);
            Type = obj.GetString("type")!;
            Width = obj.GetInt32("width");
            Height = obj.GetInt32("height");
            Link = obj.GetString("link")!;
            CreatedTime = obj.GetString("created_time", EssentialsTime.Parse)!;
            Fps = obj.GetInt32("fps");
            Size = obj.GetInt64("size");
            Md5 = obj.GetString("md5")!;
            PublicName = obj.GetString("public_name")!;
            SizeShort = obj.GetString("size_short")!;
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
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideoFile"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoFile"/>.</returns>
        [return: NotNullIfNotNull("obj")]
        public static VimeoVideoFile? Parse(JObject? obj) {
            return obj == null ? null : new VimeoVideoFile(obj);
        }

        #endregion

    }

}