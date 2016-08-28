﻿using System;
using Skybrud.Social.Vimeo.Endpoints;
using Skybrud.Social.Vimeo.Interfaces;
using Skybrud.Social.Vimeo.OAuth2;

namespace Skybrud.Social.Vimeo {
    
    /// <summary>
    /// Class working as an entry point to the Vimeo API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/start</cref>
    /// </see>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints</cref>
    /// </see>
    public class VimeoService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client for communication with the Vimeo API.
        /// </summary>
        public IVimeoOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the <strong>Channels</strong> endpoint.
        /// </summary>
        public VimeoChannelsEndpoint Channels { get; private set; }

        /// <summary>
        /// Gets a reference to the <strong>Me</strong> endpoint.
        /// </summary>
        public VimeoMeEndpoint Me { get; private set; }

        /// <summary>
        /// Gets a reference to the <strong>Users</strong> endpoint.
        /// </summary>
        public VimeoUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new service instance based on the specified <see cref="IVimeoOAuthClient"/>.
        /// </summary>
        /// <param name="client">An instance of <see cref="IVimeoOAuthClient"/>.</param>
        protected VimeoService(IVimeoOAuthClient client) {
            
            if (client == null) throw new ArgumentNullException("client");
            Client = client;

            Channels = new VimeoChannelsEndpoint(this);
            Me = new VimeoMeEndpoint(this);
            Users = new VimeoUsersEndpoint(this);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified access token. Internally a new OAuth 20. client will be
        /// initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>Returns the created instance of <see cref="Skybrud.Social.Vimeo.VimeoService" />.</returns>
        public static VimeoService CreateFromAccessToken(string accessToken) {
            return new VimeoService(new VimeoOAuthClient(accessToken));
        }

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        /// <returns>Returns the created instance of <see cref="Skybrud.Social.Vimeo.VimeoService" />.</returns>
        public static VimeoService CreateFromOAuthClient(IVimeoOAuthClient client) {
            if (client == null) throw new ArgumentNullException("client");
            return new VimeoService(client);
        }

        #endregion

    }

}