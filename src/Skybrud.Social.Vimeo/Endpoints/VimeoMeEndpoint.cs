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
        public VimeoService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public VimeoMeRawEndpoint Raw {
            get { return Service.Client.Me; }
        }

        #endregion

        #region Constructors

        internal VimeoMeEndpoint(VimeoService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <see cref="VimeoGetUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/me#GET/me</cref>
        /// </see>
        public VimeoGetUserResponse GetInfo() {
            return VimeoGetUserResponse.ParseResponse(Raw.GetInfo());
        }

        #endregion

    }

}