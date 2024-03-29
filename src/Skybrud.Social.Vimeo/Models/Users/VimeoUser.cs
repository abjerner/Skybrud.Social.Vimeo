﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Vimeo.Models.Pictures;

namespace Skybrud.Social.Vimeo.Models.Users {

    /// <summary>
    /// Class describing a Vimeo user.
    /// </summary>
    public class VimeoUser : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user. The ID isn't directly specified by the Vimeo API, but is derived from the <see cref="Uri"/> property.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the URI of the Vimeo user.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets the name of the Vimeo user.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the link (URL for the profile page) of the Vimeo user.
        /// </summary>
        public string Link { get; }

        /// <summary>
        /// Gets the location of the user. Use the <see cref="HasLocation"/> property to check whether a location has been specified.
        /// </summary>
        public string? Location { get; }

        /// <summary>
        /// Gets whether the user has specified a location. If true, the location can be read from the <see cref="Location"/> property.
        /// </summary>
        [MemberNotNullWhen(true, "Location")]
        public bool HasLocation => string.IsNullOrWhiteSpace(Location) == false;

        /// <summary>
        /// Gets the gender of the user.
        /// </summary>
        public VimeoGender Gender { get; }

        /// <summary>
        /// Gets the bio of the user. Use the <see cref="HasBio"/> property to check whether a bio has been specified.
        /// </summary>
        public string? Bio { get; }

        /// <summary>
        /// Gets whether the user has specified a bio. If true, the bio can be read from the <see cref="Bio"/> property.
        /// </summary>
        [MemberNotNullWhen(true, "Bio")]
        public bool HasBio => string.IsNullOrWhiteSpace(Bio) == false;

        /// <summary>
        /// Gets the short bio of the user. Use the <see cref="HasShortBio"/> property to check whether a short bio has been specified.
        /// </summary>
        public string? ShortBio { get; }

        /// <summary>
        /// Gets whether the user has specified a short bio. If true, the short bio can be read from the <see cref="ShortBio"/> property.
        /// </summary>
        [MemberNotNullWhen(true, "ShortBio")]
        public bool HasShortBio => string.IsNullOrWhiteSpace(ShortBio) == false;

        /// <summary>
        /// Gets the timestamp for when the user was created.
        /// </summary>
        public EssentialsTime CreatedTime { get; }

        /// <summary>
        /// Gets the account type of the user.
        /// </summary>
        public VimeoAccountType Account { get; }

        /// <summary>
        /// Gets the default picture of the user. Use the <see cref="HasPicture"/> property to check whether the user
        /// has a default picture.
        /// </summary>
        public VimeoPicture? Picture { get; }

        /// <summary>
        /// Gets whether the user has default picture. If true, information about the picture can be read from the
        /// <see cref="Picture"/> property.
        /// </summary>
        [MemberNotNullWhen(true, "Picture")]
        public bool HasPicture => Picture is not null;

        /// <summary>
        /// Gets an array of websites of the user.
        /// </summary>
        public IReadOnlyList<VimeoUserWebsite> Websites { get; }

        /// <summary>
        /// Gets whether the user has specified any websites. If true, the websites can be read from the
        /// <see cref="Websites"/> property.
        /// </summary>
        public bool HasWebsites => Websites.Count > 0;

        /// <summary>
        /// Gets the resource key of the channel.
        /// </summary>
        public string ResourceKey { get; }

        #endregion

        #region Constructors

        private VimeoUser(JObject json) : base(json) {
            Uri = json.GetString("uri")!;
            Id = long.Parse(Uri.Split('/').Last());
            Name = json.GetString("name")!;
            Link = json.GetString("link")!;
            Location = json.GetString("location");
            Gender = json.GetString("gender", ParseGender);
            Bio = json.GetString("bio");
            ShortBio = json.GetString("short_bio");
            CreatedTime = json.GetString("created_time", EssentialsTime.Parse)!;
            Account = json.GetEnum<VimeoAccountType>("account");
            Picture = json.GetObject("pictures", VimeoPicture.Parse);
            Websites = json.GetArrayItems("websites", VimeoUserWebsite.Parse)!;
            // "metadata"
            ResourceKey = json.GetString("resource_key")!;
            // "preferences"
        }

        #endregion

        #region Member methods

        #endregion

        #region Static methods

        private static VimeoGender ParseGender(string value) {
            return value switch {
                "" => VimeoGender.Unspecified,
                "n" => VimeoGender.RatherNotSay,
                "m" => VimeoGender.Male,
                "f" => VimeoGender.Female,
                "o" => VimeoGender.Other,
                _ => throw new Exception($"Unknown gender: {value}")
            };
        }

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoUser"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoUser"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoUser? Parse(JObject? json) {
            return json == null ? null : new VimeoUser(json);
        }

        #endregion

    }

}