﻿using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.Vimeo.Exceptions;
using Skybrud.Social.Vimeo.Models.Common;

// ReSharper disable ConditionalAccessQualifierIsNonNullableAccordingToAPIContract

namespace Skybrud.Social.Vimeo.Responses {

    /// <summary>
    /// Class representing a response from the Vimeo API.
    /// </summary>
    public class VimeoResponse : HttpResponseBase {

        #region Properties

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public VimeoRateLimiting RateLimiting { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected VimeoResponse(IHttpResponse response) : base(response) {
            
            RateLimiting = VimeoRateLimiting.GetFromResponse(response);

            ValidateResponse(response);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public static void ValidateResponse(IHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            switch (response.ContentType?.Split(';')[0]) {

                case HttpConstants.TextPlain:
                    throw new VimeoHttpException(response, response.Body, null);

                case HttpConstants.ApplicationJson:
                    JObject obj = ParseJsonObject(response.Body);
                    throw new VimeoHttpException(response, obj.GetString("error")!, obj.GetString("error_description")!);

                default:
                    throw new VimeoHttpException(response, null, null);

            }

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
        public T Body { get; protected set; } = default!;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        protected VimeoResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}