using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Responses.Users;

namespace Skybrud.Social.Vimeo.Endpoints {

    /// <summary>
    /// Class representing the implementation of the users endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/users</cref>
    /// </see>
    public class VimeoUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Vimeo service.
        /// </summary>
        public VimeoService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public VimeoUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal VimeoUsersEndpoint(VimeoService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>Returns an instance of <see cref="VimeoGetUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public VimeoGetUserResponse GetInfo(long userId) {
            return VimeoGetUserResponse.ParseResponse(Raw.GetInfo(userId));
        }

        /// <summary>
        /// Gets information about the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>Returns an instance of <see cref="VimeoGetUserResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.vimeo.com/api/endpoints/users#/{user_id}</cref>
        /// </see>
        public VimeoGetUserResponse GetInfo(string username) {
            return VimeoGetUserResponse.ParseResponse(Raw.GetInfo(username));
        }
        
        #endregion

    }

}