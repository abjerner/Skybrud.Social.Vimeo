namespace Skybrud.Social.Vimeo.Models.Users;

/// <summary>
/// Indicates the account type of a Vimeo user.
/// </summary>
/// <see>
///     <cref>https://developer.vimeo.com/api/reference/response/user</cref>
/// </see>
public enum VimeoAccountType {

    /// <summary>
    /// Indicates that Vimeo returned an undocumented or unsupported account type.
    /// </summary>
    Unrecognized = -1,

    /// <summary>
    /// Indicates that an account type was not specified.
    /// </summary>
    Unspecified = 0,

    /// <summary>
    /// Indicates that a user has a <strong>Vimeo Advanced</strong> subscription.
    /// </summary>
    Advanced,

    /// <summary>
    /// Indicates that a user has a <strong>Vimeo Basic</strong> subscription.
    /// </summary>
    Basic,

    /// <summary>
    /// Indicates a user has a <strong>Vimeo Business</strong> subscription.
    /// </summary>
    Business,

    /// <summary>
    /// Indicates a user has a <strong>Vimeo Enterprise</strong> subscription.
    /// </summary>
    Enterprise,

    /// <summary>
    /// Indicates a user has a <strong>Vimeo Free</strong> subscription.
    /// </summary>
    Free,

    /// <summary>
    /// Indicates a user has a <strong>Vimeo Business Live</strong> subscription.
    /// </summary>
    LiveBusiness,

    /// <summary>
    /// Indicates a user has a <strong>Vimeo Premium</strong> subscription.
    /// </summary>
    LivePremium,

    /// <summary>
    /// Indicates a user has a <strong>Vimeo PRO Live</strong> subscription.
    /// </summary>
    LivePro,

    /// <summary>
    /// Indicates a user with a <strong>Vimeo Plus</strong> membership.
    /// </summary>
    Plus,

    /// <summary>
    /// Indicates a user with a <strong>Vimeo Pro</strong> membership.
    /// </summary>
    Pro,

    /// <summary>
    /// Indicates a user with a <strong>Vimeo PRO Unlimited</strong> membership.
    /// </summary>
    /// <see>
    ///     <cref>https://join.vimeo.com/pro-unlimited/</cref>
    /// </see>
    ProUnlimited,

    /// <summary>
    /// Indicates a user with a <strong>Vimeo Producer</strong> membership.
    /// </summary>
    Producer,

    /// <summary>
    /// Indicates a user with a <strong>Vimeo Standard</strong> membership.
    /// </summary>
    Standard,

    /// <summary>
    /// Indicates a user with a <strong>Vimeo Starter</strong> membership.
    /// </summary>
    Starter,

    /// <summary>
    /// Indicates a user with a <strong>Custom</strong> membership. This value is not documented by Vimeo.
    /// </summary>
    Custom

}