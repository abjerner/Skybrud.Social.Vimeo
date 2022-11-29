using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Responses.Users;

namespace Skybrud.Social.Vimeo.Endpoints {

    /// <summary>
    /// Class representing the implementation of the me endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/me</cref>
    /// </see>
    public class VimeoMeEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Vimeo service.
        /// </summary>
        public VimeoHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public VimeoMeRawEndpoint Raw => Service.Client.Me;

        #endregion

        #region Constructors

        internal VimeoMeEndpoint(VimeoHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="VimeoUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/me#GET/me</cref>
        /// </see>
        public VimeoUserResponse GetUser() {
            return new VimeoUserResponse(Raw.GetUser());
        }

        #endregion

    }

}