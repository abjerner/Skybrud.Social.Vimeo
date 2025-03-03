using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Vimeo.OAuth;
using Skybrud.Social.Vimeo.Options.Videos;

namespace Skybrud.Social.Vimeo.Endpoints.Raw;

/// <summary>
/// Class representing the raw implementation of the <strong>Videos</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developer.vimeo.com/api/endpoints/videos</cref>
/// </see>
public class VimeoVideosRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the OAuth client.
    /// </summary>
    public VimeoOAuthClient Client { get; }

    #endregion

    #region Constructors

    internal VimeoVideosRawEndpoint(VimeoOAuthClient client) {
            Client = client;
        }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets information about the video with the specified <paramref name="videoId"/>.
    /// </summary>
    /// <param name="videoId">The ID of the video</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/endpoints/videos#GET/videos/{video_id}</cref>
    /// </see>
    public IHttpResponse GetVideo(long videoId) {
        return Client.Get($"/videos/{videoId}");
    }

    /// <summary>
    /// Gets a list of videos of the user matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/reference/videos#search_videos</cref>
    /// </see>
    public IHttpResponse SearchVideos(VimeoSearchVideosOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return Client.GetResponse(options);
    }

    #endregion

}