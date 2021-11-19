namespace Skybrud.Social.Vimeo.Models.Videos {
    
    /// <summary>
    /// Enum class representing the quality of a <see cref="VimeoVideoFile"/>.
    /// </summary>
    public enum VimeoVideoQuality {
        
        /// <summary>
        /// Indicates that the file is of standard quality.
        /// </summary>
        Standard,
        
        /// <summary>
        /// Indicates that the video file is of high definition quality.
        /// </summary>
        HighDefinition,
        
        /// <summary>
        /// Indicates that the video file quality is suited for mobile devices.
        /// </summary>
        Mobile,
        
        /// <summary>
        /// Indicates that the video file quality is suited for mobile devices.
        /// </summary>
        Streaming,
        
        Unrecognized

    }

}