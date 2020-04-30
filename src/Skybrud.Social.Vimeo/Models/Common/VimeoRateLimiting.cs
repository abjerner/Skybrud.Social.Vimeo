using System;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Time;

namespace Skybrud.Social.Vimeo.Models.Common {

    /// <summary>
    /// Class with rate-limiting information about a response from the Vimeo API.
    /// </summary>
    public class VimeoRateLimiting {

        #region Properties

        /// <summary>
        /// Gets the total number of calls allowed within the current window.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Gets the remaining number of calls available to your app within the current window.
        /// </summary>
        public int Remaining { get; }

        /// <summary>
        /// Gets the timestamp for when the current window is reset.
        /// </summary>
        public EssentialsDateTime Reset { get; }

        #endregion

        #region Constructors

        private VimeoRateLimiting(int limit, int remaining, EssentialsDateTime reset) {
            Limit = limit;
            Remaining = remaining;
            Reset = reset;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses rate-limiting information from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response that holds the rate-limiting information.</param>
        /// <returns>An instance of <see cref="VimeoRateLimiting"/>.</returns>
        public static VimeoRateLimiting GetFromResponse(IHttpResponse response) {

            int limit;
            int remaining;

            if (!Int32.TryParse(response.Headers["X-Ratelimit-Limit"] ?? "", out limit)) {
                limit = -1;
            }

            if (!Int32.TryParse(response.Headers["X-Ratelimit-Remaining"] ?? "", out remaining)) {
                remaining = -1;
            }

            var reset = EssentialsDateTime.Parse(response.Headers["X-RateLimit-Reset"]);

            return new VimeoRateLimiting(limit, remaining, reset);

        }

        #endregion

    }

}