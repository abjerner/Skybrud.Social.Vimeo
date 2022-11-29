using System;
using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Social.Vimeo.Exceptions;
using Skybrud.Social.Vimeo.Models.Common;
using Skybrud.Social.Vimeo.Models.Errors;

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

        #region Member methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> string into an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <typeparamref name="T"/>.</param>
        /// <returns>An instance of <typeparamref name="T"/> parsed from the specified <paramref name="json"/> string.</returns>
        protected new T ParseJsonObject<T>(string json, Func<JObject, T?> func) {
            try {
                return JsonUtils.ParseJsonObject(json, func)!;
            } catch (Exception ex) {
                throw new VimeoResponseParseException(Response, ex);
            }
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
                    throw new VimeoHttpException(response, response.Body);

                case HttpConstants.ApplicationJson:
                case "application/vnd.vimeo.error+json":
                    VimeoError error = HttpResponseBase.ParseJsonObject(response.Body, VimeoError.Parse)!;
                    throw new VimeoHttpException(response, error);

                default:
                    throw new VimeoHttpException(response);

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