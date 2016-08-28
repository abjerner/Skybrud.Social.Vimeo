using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;
using Skybrud.Social.Vimeo.Endpoints.Raw;

namespace Skybrud.Social.Vimeo.Interfaces {

    /// <summary>
    /// Interface describing an OAuth client used for authentication or making requests to the Vimeo API.
    /// </summary>
    public interface IVimeoOAuthClient {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw <strong>Channels</strong> endpoint.
        /// </summary>
        VimeoChannelsRawEndpoint Channels { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Me</strong> endpoint.
        /// </summary>
        VimeoMeRawEndpoint Me { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Users</strong> endpoint.
        /// </summary>
        VimeoUsersRawEndpoint Users { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        SocialHttpResponse DoHttpGetRequest(string url);

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="options">The options for the call to the specified <code>url</code>.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        SocialHttpResponse DoHttpGetRequest(string url, IHttpGetOptions options);

        #endregion

    }

}