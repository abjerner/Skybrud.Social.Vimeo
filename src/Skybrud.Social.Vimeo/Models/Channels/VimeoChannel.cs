using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Vimeo.Models.Pictures;
using Skybrud.Social.Vimeo.Models.Users;

namespace Skybrud.Social.Vimeo.Models.Channels {
    
    /// <summary>
    /// Class describing a Vimeo channel.
    /// </summary>
    public class VimeoChannel : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the channel. The channel isn't directly specified by the Vimeo API, but is derived from the <see cref="Uri"/> property.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the URI of the Vimeo channel.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets the name of the Vimeo channel.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the Vimeo channel.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the channel has a description. If true, the description can be read from the
        /// <see cref="Description"/> property.
        /// </summary>
        public bool HasDescription => !String.IsNullOrWhiteSpace(Description);

        /// <summary>
        /// Gets the link (URL for the channel page) of the Vimeo channel.
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Gets the timestamp for when the channel was created.
        /// </summary>
        public EssentialsDateTime CreatedTime { get; }
        
        /// <summary>
        /// Gets the timestamp for when the channel was last modified.
        /// </summary>
        public EssentialsDateTime ModifiedTime { get; }

        /// <summary>
        /// Gets information about the owner of the channel.
        /// </summary>
        public VimeoUser User { get; }

        /// <summary>
        /// Gets the default picture of the channel. Use the <see cref="HasPicture"/> property to check whether the
        /// channel has a default picture.
        /// </summary>
        public VimeoPicture Picture { get; }

        /// <summary>
        /// Gets whether the channel has a default picture.
        /// </summary>
        public bool HasPicture => Picture != null;

        /// <summary>
        /// Gets information about the header picture of the channel.
        /// </summary>
        public VimeoPicture Header { get; }

        /// <summary>
        /// Gets whether the channel has header picture.
        /// </summary>
        public bool HasHeader => Header != null;

        /// <summary>
        /// Gets privacy information about the channel.
        /// </summary>
        public VimeoChannelPrivacy Privacy { get; }

        /// <summary>
        /// Gets the meta data of the channel.
        /// </summary>
        public VimeoChannelMetaData MetaData { get; }

        /// <summary>
        /// Gets the resource key of the channel.
        /// </summary>
        public string ResourceKey { get; }

        #endregion

        #region Constructors

        private VimeoChannel(JObject obj) : base(obj) {
            Uri = obj.GetString("uri");
            Id = Int64.Parse(Uri.Split('/').Last());
            Name = obj.GetString("name");
            Description = obj.GetString("description");
            Link = obj.GetString("link");
            CreatedTime = obj.GetString("created_time", EssentialsDateTime.Parse);
            ModifiedTime = obj.GetString("modified_time", EssentialsDateTime.Parse);
            User = obj.GetObject("user", VimeoUser.Parse);
            Picture = obj.GetObject("pictures", VimeoPicture.Parse);
            Header = obj.GetObject("header", VimeoPicture.Parse);
            Privacy = obj.GetObject("privacy", VimeoChannelPrivacy.Parse);
            MetaData = obj.GetObject("metadata", VimeoChannelMetaData.Parse);
            ResourceKey = obj.GetString("resource_key");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="VimeoChannel"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoChannel"/>.</returns>
        public static VimeoChannel Parse(JObject obj) {
            return obj == null ? null : new VimeoChannel(obj);
        }

        #endregion

    }

}