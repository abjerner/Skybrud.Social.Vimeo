using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.Models.Channels;

namespace Skybrud.Social.Vimeo.Responses.Channels {

    /// <summary>
    /// Class representing a response with information about a Vimeo channel.
    /// </summary>
    public class VimeoChannelResponse : VimeoResponse<VimeoChannel> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public VimeoChannelResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, VimeoChannel.Parse);
        }

    }

}