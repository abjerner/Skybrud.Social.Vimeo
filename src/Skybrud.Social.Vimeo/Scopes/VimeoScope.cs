namespace Skybrud.Social.Vimeo.Scopes {

    /// <see>
    ///     <cref>https://developer.vimeo.com/api/authentication#supported-scopes</cref>
    /// </see>
    public class VimeoScope {

        #region Properties

        /// <summary>
        /// View private videos.
        /// </summary>
        public static readonly VimeoScope Private = new VimeoScope("private", "Private", "View private videos.");
        
        /// <summary>
        /// View public videos.
        /// </summary>
        public static readonly VimeoScope Public = new VimeoScope("public", "Public", "View public videos.");

        /// <summary>
        /// View Vimeo On Demand purchase history.
        /// </summary>
        public static readonly VimeoScope Purchased = new VimeoScope("purchased", "Purchased", "View Vimeo On Demand purchase history.");

        /// <summary>
        /// Purchase Vimeo On Demand videos.
        /// </summary>
        public static readonly VimeoScope Purchase = new VimeoScope("purchase", "Purchase", "Purchase Vimeo On Demand videos.");

        /// <summary>
        /// Create new videos, groups, albums, etc.
        /// </summary>
        public static readonly VimeoScope Create = new VimeoScope("create", "Create", "Create new videos, groups, albums, etc.");
        
        /// <summary>
        /// Edit videos, groups, albums, etc.
        /// </summary>
        public static readonly VimeoScope Edit = new VimeoScope("edit", "Edit", "Edit videos, groups, albums, etc.");
        
        /// <summary>
        /// Delete videos, groups, albums, etc.
        /// </summary>
        public static readonly VimeoScope Delete = new VimeoScope("delete", "Delete", "Delete videos, groups, albums, etc.");
        
        /// <summary>
        /// Interact with a video on behalf of a user, such as liking a video or adding it to your Watch Later list.
        /// </summary>
        public static readonly VimeoScope Interact = new VimeoScope("interact", "Interact", "Interact with a video on behalf of a user, such as liking a video or adding it to your Watch Later list.");

        /// <summary>
        /// Upload a video.
        /// </summary>
        public static readonly VimeoScope Upload = new VimeoScope("upload", "Upload", "Upload a video.");

        /// <summary>
        /// Manage Vimeo On Demand promotions.
        /// </summary>
        public static readonly VimeoScope PromoCodes = new VimeoScope("promo_codes", "PromoCodes", "Manage Vimeo On Demand promotions.");

        /// <summary>
        /// Access additional video files owned by the authenticated user.
        /// </summary>
        public static readonly VimeoScope VideoFiles = new VimeoScope("video_files", "VideoFiles", "Access additional video files owned by the authenticated user.");

        /// <summary>
        /// Gets an array of all available scopes.
        /// </summary>
        public static VimeoScope[] All {
            get {
                return new [] {
                    Private, Public, Purchased, Purchase, Create, Edit, Delete, Interact, Upload, PromoCodes, VideoFiles
                };
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the alias of the scope.
        /// </summary>
        public string Alias { get; private set; }

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructors

        public VimeoScope(string alias, string name, string description) {
            Alias = alias;
            Name = name;
            Description = description;
        }

        #endregion

    }

}