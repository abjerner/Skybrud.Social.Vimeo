using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.Models.Videos;

namespace Skybrud.Social.Vimeo.Responses.Videos {
    
    /// <summary>
    /// Class representing a response with a collection of Vimeo videos.
    /// </summary>
    public class VimeoVideoListResponse : VimeoResponse<VimeoVideoList> {

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public VimeoVideoListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, VimeoVideoList.Parse)!;
        }

    }

}