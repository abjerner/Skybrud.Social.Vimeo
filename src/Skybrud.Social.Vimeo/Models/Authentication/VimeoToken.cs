using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
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
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the type of the access token.
        /// </summary>
        public string TokenType { get; private set; }

        /// <summary>
        /// Gets a collection of the granted scope.
        /// </summary>
        public VimeoScopeCollection Scope { get; private set; }

        /// <summary>
        /// Gets information about the app.
        /// </summary>
        public VimeoApp App { get; private set; }

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public VimeoUser User { get; private set; }

        #endregion

        #region Constructors

        private VimeoToken(JObject obj) : base(obj) {
            AccessToken = obj.GetString("access_token");
            TokenType = obj.GetString("token_type");
            Scope = obj.GetString("scope", VimeoScopeCollection.Parse);
            App = obj.GetObject("app", VimeoApp.Parse);
            User = obj.GetObject("user", VimeoUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <see cref="VimeoToken"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="VimeoToken"/>.</returns>
        public static VimeoToken Parse(JObject obj) {
            return obj == null ? null : new VimeoToken(obj);
        }

        #endregion

    }

}