using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Models.Videos;

namespace Skybrud.Social.Vimeo.Responses.Videos {
    
    /// <summary>
    /// Class representing a response with a collection of Vimeo videos.
    /// </summary>
    public class VimeoGetVideosResponse : VimeoResponse<VimeoVideosCollection> {

        #region Constructors

        private VimeoGetVideosResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoVideosCollection.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="VimeoGetVideosResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="VimeoGetVideosResponse"/> representing the response.</returns>
        public static VimeoGetVideosResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new VimeoGetVideosResponse(response);
        }

        #endregion

    }

}