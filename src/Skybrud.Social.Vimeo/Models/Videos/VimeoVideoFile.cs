using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Vimeo.Models.Videos
{
    /// <summary>
    /// Class describing a file of a Vimeo video.
    /// </summary>
    public class VimeoVideoFile : VimeoObject
    {
        /// <summary>
        /// Gets the Video quality - hd, mobile, sd, hls
        /// </summary>
        public string Quality { get; }
        /// <summary>
        /// Video MIME type, fx video/mp4
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// Video width in pixels
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Video height in pixels
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// The Vimeo src link including oauth token that can be used in HTML5 video elements.
        /// </summary>
        public string Link { get; }
        /// <summary>
        /// Create time in the format YYYY-MM-DDTHH:mm:ssZ
        /// </summary>
        public string CreatedTime { get; }
        /// <summary>
        /// FPS of the file
        /// </summary>
        public int FPS { get; }
        /// <summary>
        /// Size in bytes
        /// </summary>
        public int Size { get; }
        /// <summary>
        /// Md5 hash of the file
        /// </summary>
        public string Md5 { get; }
        /// <summary>
        /// Public name of the quality of the file - fx HD 1080p
        /// </summary>
        public string PublicName { get; }
        /// <summary>
        /// Size in a more readable way, fx 32.18MB
        /// </summary>
        public string SizeShort { get; }

        // Example obj:
        //{
        //    "quality": "hd",
        //    "type": "video/mp4",
        //    "width": 1918,
        //    "height": 1080,
        //    "link": "https://player.vimeo.com/external/123456789.hd.mp4?s=91e0428c9c38b28b275bdebe45939221f3fe6cf7&profile_id=119&oauth_token_id=1234567890",
        //    "created_time": "2015-03-19T07:49:29+00:00",
        //    "fps": 25,
        //    "size": 69708426,
        //    "md5": "91fca61b68a131868dc5d899862ae9eb",
        //    "public_name": "HD 1080p",
        //    "size_short": "66.48MB"
        //}
        private VimeoVideoFile(JObject obj) : base(obj)
        {
            Quality = obj.GetString("quality");
            Type = obj.GetString("type");
            Width = obj.GetInt32("width");
            Height = obj.GetInt32("height");
            Link = obj.GetString("link");
            CreatedTime = obj.GetString("created_time");
            FPS = obj.GetInt32("fps");
            Size = obj.GetInt32("size");
            Md5 = obj.GetString("md5");
            PublicName = obj.GetString("public_name");
            SizeShort = obj.GetString("size_short");
        }

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoVideoFile"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoVideoFile"/>.</returns>
        public static VimeoVideoFile Parse(JObject obj)
        {
            return obj == null ? null : new VimeoVideoFile(obj);
        }
    }
}