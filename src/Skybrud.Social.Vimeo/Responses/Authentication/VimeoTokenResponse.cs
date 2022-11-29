using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.Models.Authentication;

namespace Skybrud.Social.Vimeo.Responses.Authentication {

    /// <summary>
    /// Class representing a response with information about an access token.
    /// </summary>
    public class VimeoTokenResponse : VimeoResponse<VimeoToken> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public VimeoTokenResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, VimeoToken.Parse);
        }

    }

}