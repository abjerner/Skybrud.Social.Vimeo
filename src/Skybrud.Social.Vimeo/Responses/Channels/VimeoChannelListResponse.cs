using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.Models.Channels;

namespace Skybrud.Social.Vimeo.Responses.Channels {

    /// <summary>
    /// Class representing the response containing a list of Vimeo channels.
    /// </summary>
    public class VimeoChannelListResponse : VimeoResponse<VimeoChannelList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public VimeoChannelListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, VimeoChannelList.Parse);
        }

    }

}