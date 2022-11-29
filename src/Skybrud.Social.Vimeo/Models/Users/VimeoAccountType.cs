namespace Skybrud.Social.Vimeo.Models.Users {

    /// <summary>
    /// Indicates the account type of a Vimeo user.
    /// </summary>
    public enum VimeoAccountType {

        /// <summary>
        /// Indicates a user with a basic membership (free).
        /// </summary>
        Basic,

        /// <summary>
        /// Indicates a user with a <strong>Business</strong> membership.
        /// </summary>
        Business,

        /// <summary>
        /// Indicates a user with a <strong>Plus</strong> membership.
        /// </summary>
        Plus,

        /// <summary>
        /// Indicates a user with a <strong>Pro</strong> membership.
        /// </summary>
        Pro,

        /// <summary>
        /// Indicates a user with a <strong>Vimeo PRO Unlimited</strong> membership.
        /// </summary>
        /// <see>
        ///     <cref>https://join.vimeo.com/pro-unlimited/</cref>
        /// </see>
        ProUnlimited

    }

}