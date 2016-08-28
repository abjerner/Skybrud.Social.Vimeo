namespace Skybrud.Social.Vimeo.Objects.Channels {
    
    /// <summary>
    /// ENum class representing the privacy status of a Vimeo channel.
    /// </summary>
    public enum VimeoChannelPrivacyStatus {

        /// <summary>
        /// The channel is visible to anybody (public).
        /// </summary>
        Anybody,

        /// <summary>
        /// The channel is only visible to moderators.
        /// </summary>
        Moderators,

        /// <summary>
        /// The video is only visible to moderators and selected users.
        /// </summary>
        Users

    }

}