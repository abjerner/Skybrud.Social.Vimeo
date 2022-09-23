namespace Skybrud.Social.Vimeo.Options.Videos {
    
    /// <summary>
    /// Enum class indicating how a list of videos should be sorted.
    /// </summary>
    public enum VimeoVideoSortField {

        /// <summary>
        /// Sort the results by creation date.
        /// </summary>
        Date,

        /// <summary>
        /// Sort the results alphabetically.
        /// </summary>
        Alphabetical,

        /// <summary>
        /// Sort the results by number of plays.
        /// </summary>
        Plays,

        /// <summary>
        /// Sort the results by number of likes.
        /// </summary>
        Likes,

        /// <summary>
        /// Sort the results by number of comments.
        /// </summary>
        Comments,

        /// <summary>
        /// Sort the results by duration.
        /// </summary>
        Duration,

        /// <summary>
        /// Sort the results by date added.
        /// </summary>
        Added,

        /// <summary>
        /// Sort the results by last modification.
        /// </summary>
        ModifiedTime,

        /// <summary>
        /// Sort the results as the user has arranged them.
        /// </summary>
        Manual

    }

}