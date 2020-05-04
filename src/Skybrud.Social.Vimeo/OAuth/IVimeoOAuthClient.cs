using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Client;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.Vimeo.Endpoints.Raw;

namespace Skybrud.Social.Vimeo.OAuth {

    /// <summary>
    /// Interface describing an OAuth client used for authentication or making requests to the Vimeo API.
    /// </summary>
    public interface IVimeoOAuthClient : IHttpClient {

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

        /// <summary>
        /// Gets a reference to the raw <strong>Videos</strong> endpoint.
        /// </summary>
        VimeoVideosRawEndpoint Videos { get; }

        #endregion

        #region Member methods

        /// <summary>
        /// Makes a HTTP GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        IHttpResponse Get(string url);

        /// <summary>
        /// Makes a GET request to the specified <paramref name="url"/>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="queryString">The query string of the request.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the response.</returns>
        IHttpResponse Get(string url, IHttpQueryString queryString);

        #endregion

    }

}