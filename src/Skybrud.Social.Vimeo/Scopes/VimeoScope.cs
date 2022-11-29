using System.Collections.Generic;

namespace Skybrud.Social.Vimeo.Scopes {

    /// <summary>
    /// Class representing a scope of the Vimeo API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/authentication#supported-scopes</cref>
    /// </see>
    public class VimeoScope {

        #region Properties

        /// <summary>
        /// View private videos.
        /// </summary>
        public static readonly VimeoScope Private = new("private", "Private", "View private videos.");

        /// <summary>
        /// View public videos.
        /// </summary>
        public static readonly VimeoScope Public = new("public", "Public", "View public videos.");

        /// <summary>
        /// View Vimeo On Demand purchase history.
        /// </summary>
        public static readonly VimeoScope Purchased = new("purchased", "Purchased", "View Vimeo On Demand purchase history.");

        /// <summary>
        /// Purchase Vimeo On Demand videos.
        /// </summary>
        public static readonly VimeoScope Purchase = new("purchase", "Purchase", "Purchase Vimeo On Demand videos.");

        /// <summary>
        /// Create new videos, groups, albums, etc.
        /// </summary>
        public static readonly VimeoScope Create = new("create", "Create", "Create new videos, groups, albums, etc.");

        /// <summary>
        /// Edit videos, groups, albums, etc.
        /// </summary>
        public static readonly VimeoScope Edit = new("edit", "Edit", "Edit videos, groups, albums, etc.");

        /// <summary>
        /// Delete videos, groups, albums, etc.
        /// </summary>
        public static readonly VimeoScope Delete = new("delete", "Delete", "Delete videos, groups, albums, etc.");

        /// <summary>
        /// Interact with a video on behalf of a user, such as liking a video or adding it to your Watch Later list.
        /// </summary>
        public static readonly VimeoScope Interact = new("interact", "Interact", "Interact with a video on behalf of a user, such as liking a video or adding it to your Watch Later list.");

        /// <summary>
        /// Upload a video.
        /// </summary>
        public static readonly VimeoScope Upload = new("upload", "Upload", "Upload a video.");

        /// <summary>
        /// Manage Vimeo On Demand promotions.
        /// </summary>
        public static readonly VimeoScope PromoCodes = new("promo_codes", "PromoCodes", "Manage Vimeo On Demand promotions.");

        /// <summary>
        /// Access additional video files owned by the authenticated user.
        /// </summary>
        public static readonly VimeoScope VideoFiles = new("video_files", "VideoFiles", "Access additional video files owned by the authenticated user.");

        /// <summary>
        /// Gets an array of all available scopes.
        /// </summary>
        public static IReadOnlyList<VimeoScope> All {
            get {
                return new[] {
                    Private, Public, Purchased, Purchase, Create, Edit, Delete, Interact, Upload, PromoCodes, VideoFiles
                };
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the alias of the scope.
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string? Name { get; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string? Description { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope based on the specified <paramref name="alias"/>, <paramref name="name"/> and
        /// <paramref name="description"/>.
        /// </summary>
        /// <param name="alias">The alias of the scope.</param>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public VimeoScope(string alias, string? name, string? description) {
            Alias = alias;
            Name = name;
            Description = description;
        }

        #endregion

    }

}