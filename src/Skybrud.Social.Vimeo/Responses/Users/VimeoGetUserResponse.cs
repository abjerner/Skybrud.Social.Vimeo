using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Models.Users;

namespace Skybrud.Social.Vimeo.Responses.Users {

    /// <summary>
    /// Class representing a response with information about a Vimeo user.
    /// </summary>
    public class VimeoGetUserResponse : VimeoResponse<VimeoUser> {

        #region Constructors

        private VimeoGetUserResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoUser.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="VimeoGetUserResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="VimeoGetUserResponse"/> representing the response.</returns>
        public static VimeoGetUserResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new VimeoGetUserResponse(response);
        }

        #endregion

    }

}