using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Endpoints.Raw;

namespace Skybrud.Social.Vimeo.Interfaces {

    /// <summary>
    /// Interface describing an OAuth client used for authentication or making requests to the Vimeo API.
    /// </summary>
    public interface IVimeoOAuthClient {

        /// <summary>
        /// Gets a reference to the raw <strong>Me</strong> endpoint.
        /// </summary>
        VimeoMeRawEndpoint Me { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        VimeoUsersRawEndpoint Users { get; }

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        SocialHttpResponse DoHttpGetRequest(string url);

    }

}