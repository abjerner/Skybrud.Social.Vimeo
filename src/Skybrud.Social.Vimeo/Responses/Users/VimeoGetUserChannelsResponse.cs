using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Models.Channels;

namespace Skybrud.Social.Vimeo.Responses.Users {
    
    /// <summary>
    /// Class representing the response containing a collection of Vimeo channels.
    /// </summary>
    public class VimeoGetUserChannelsResponse : VimeoResponse<VimeoChannelsCollection> {

        #region Constructors

        private VimeoGetUserChannelsResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoChannelsCollection.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="VimeoGetUserChannelsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <see cref="VimeoGetUserChannelsResponse"/> representing the response.</returns>
        public static VimeoGetUserChannelsResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new VimeoGetUserChannelsResponse(response);
        }

        #endregion

    }

}