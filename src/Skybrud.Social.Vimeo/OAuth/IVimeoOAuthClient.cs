using Skybrud.Social.Interfaces.Http;
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

    }

}