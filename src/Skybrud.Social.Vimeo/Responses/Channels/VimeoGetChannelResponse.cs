using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Objects.Channels;

namespace Skybrud.Social.Vimeo.Responses.Channels {
    
    /// <summary>
    /// Class representing a response with information about a Vimeo channel.
    /// </summary>
    public class VimeoGetChannelResponse : VimeoResponse<VimeoChannel> {

        #region Constructors

        private VimeoGetChannelResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, VimeoChannel.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <see cref="VimeoGetChannelResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <see cref="VimeoGetChannelResponse"/> representing the response.</returns>
        public static VimeoGetChannelResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new VimeoGetChannelResponse(response);
        }

        #endregion

    }

}