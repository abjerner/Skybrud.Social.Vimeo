namespace Skybrud.Social.Vimeo.Models.Users {
    
    /// <summary>
    /// Enum class indicating the gender of a Vimeo user.
    /// </summary>
    public enum VimeoGender {

        /// <summary>
        /// Indicates that the user hasn't yet specified their gender.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that the user doesn't wish to specify their gender.
        /// </summary>
        RatherNotSay,

        /// <summary>
        /// Indicates that the user is a male (he/him).
        /// </summary>
        Male,

        /// <summary>
        /// Indicates that the user is a female (she/her).
        /// </summary>
        Female,

        /// <summary>
        /// Indicates that the user does not identify as either male or female (wishes to be entitled (they/them).
        /// </summary>
        Other

    }

}