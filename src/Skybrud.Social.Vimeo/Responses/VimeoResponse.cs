using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Exceptions;
using Skybrud.Social.Vimeo.Models.Common;

namespace Skybrud.Social.Vimeo.Responses {

    /// <summary>
    /// Class representing a response from the Vimeo API.
    /// </summary>
    public class VimeoResponse : SocialResponse {

        #region Properties

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public VimeoRateLimiting RateLimiting { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        protected VimeoResponse(SocialHttpResponse response) : base(response) {
            RateLimiting = VimeoRateLimiting.GetFromResponse(response);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            JObject obj = ParseJsonObject(response.Body);
            throw new VimeoHttpException(response, obj.GetString("error"), obj.GetString("error_description"));

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Vimeo API.
    /// </summary>
    public class VimeoResponse<T> : VimeoResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        protected VimeoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}