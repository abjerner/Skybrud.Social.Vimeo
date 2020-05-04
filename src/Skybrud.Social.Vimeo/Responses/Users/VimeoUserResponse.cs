using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.Models.Users;

namespace Skybrud.Social.Vimeo.Responses.Users {

    /// <summary>
    /// Class representing a response with information about a Vimeo user.
    /// </summary>
    public class VimeoUserResponse : VimeoResponse<VimeoUser> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public VimeoUserResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoUser.Parse);

        }

    }

}