using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Vimeo.Models.Users;
using Skybrud.Social.Vimeo.Scopes;

namespace Skybrud.Social.Vimeo.Models.Authentication {

    /// <summary>
    /// Class describing an access token received from the Vimeo API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/authentication#receiving-the-access-token-in-the-authentication-response</cref>
    /// </see>
    public class VimeoToken : VimeoObject {

        #region Properties

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; }

        /// <summary>
        /// Gets the type of the access token.
        /// </summary>
        public string TokenType { get; }

        /// <summary>
        /// Gets a collection of the granted scope.
        /// </summary>
        public VimeoScopeList Scope { get; }

        /// <summary>
        /// Gets information about the app.
        /// </summary>
        public VimeoApp App { get; }

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public VimeoUser User { get; }

        #endregion

        #region Constructors

        private VimeoToken(JObject json) : base(json) {
            AccessToken = json.GetString("access_token")!;
            TokenType = json.GetString("token_type")!;
            Scope = json.GetString("scope", VimeoScopeList.Parse)!;
            App = json.GetObject("app", VimeoApp.Parse)!;
            User = json.GetObject("user", VimeoUser.Parse)!;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoToken"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="VimeoToken"/>.</returns>
        [return: NotNullIfNotNull("json")]
        public static VimeoToken? Parse(JObject? json) {
            return json == null ? null : new VimeoToken(json);
        }

        #endregion

    }

}