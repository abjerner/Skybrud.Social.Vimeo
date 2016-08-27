using Skybrud.Social.Vimeo.Objects.Authentication;
using Skybrud.Social.Http;

namespace Skybrud.Social.Vimeo.Responses.Authentication {

    /// <summary>
    /// Class representing a response with information about an access token.
    /// </summary>
    public class VimeoTokenResponse : VimeoResponse<VimeoToken> {

        #region Constructors

        private VimeoTokenResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoToken.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="VimeoTokenResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <see cref="VimeoTokenResponse"/> representing the response.</returns>
        public static VimeoTokenResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new VimeoTokenResponse(response);
        }

        #endregion

    }

}