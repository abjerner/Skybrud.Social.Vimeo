using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.Models.Videos;

namespace Skybrud.Social.Vimeo.Responses.Videos {
    
    /// <summary>
    /// Class representing a response with information about a single Vimeo videos.
    /// </summary>
    public class VimeoVideoResponse : VimeoResponse<VimeoVideo> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public VimeoVideoResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoVideo.Parse);

        }

    }

}