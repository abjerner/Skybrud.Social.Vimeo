using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Models.Videos;

namespace Skybrud.Social.Vimeo.Responses.Videos {
    
    /// <summary>
    /// Class representing a response with information about a single Vimeo videos.
    /// </summary>
    public class VimeoGetVideoResponse : VimeoResponse<VimeoVideo> {

        #region Constructors

        private VimeoGetVideoResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoVideo.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="VimeoGetVideoResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="VimeoGetVideoResponse"/> representing the response.</returns>
        public static VimeoGetVideoResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new VimeoGetVideoResponse(response);
        }

        #endregion

    }

}