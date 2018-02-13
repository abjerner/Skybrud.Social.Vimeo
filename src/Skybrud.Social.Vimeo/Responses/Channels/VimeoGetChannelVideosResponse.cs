using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Models.Videos;

namespace Skybrud.Social.Vimeo.Responses.Channels {
    
    /// <summary>
    /// Class representing a response with collection of Vimeo videos.
    /// </summary>
    public class VimeoGetChannelVideosResponse : VimeoResponse<VimeoVideo> {

        #region Constructors

        private VimeoGetChannelVideosResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoVideo.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="VimeoGetChannelVideosResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <see cref="VimeoGetChannelVideosResponse"/> representing the response.</returns>
        public static VimeoGetChannelVideosResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new VimeoGetChannelVideosResponse(response);
        }

        #endregion

    }

}