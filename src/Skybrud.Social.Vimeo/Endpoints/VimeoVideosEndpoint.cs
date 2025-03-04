using Skybrud.Social.Vimeo.Endpoints.Raw;
using Skybrud.Social.Vimeo.Options.Videos;
using Skybrud.Social.Vimeo.Responses.Videos;

namespace Skybrud.Social.Vimeo.Endpoints;

/// <summary>
/// Class representing the implementation of the <strong>Videos</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developer.vimeo.com/api/endpoints/videos</cref>
/// </see>
public class VimeoVideosEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the Vimeo service.
    /// </summary>
    public VimeoHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public VimeoVideosRawEndpoint Raw => Service.Client.Videos;

    #endregion

    #region Constructors

    internal VimeoVideosEndpoint(VimeoHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets information about the video with the specified <paramref name="videoId"/>.
    /// </summary>
    /// <param name="videoId">The ID of the video</param>
    /// <returns>An instance of <see cref="VimeoVideoResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/reference/videos#get_video</cref>
    /// </see>
    public VimeoVideoResponse GetVideo(long videoId) {
        return new VimeoVideoResponse(Raw.GetVideo(videoId));
    }

    /// <summary>
    /// Gets information about the video matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="VimeoVideoResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/reference/videos#get_video</cref>
    /// </see>
    public VimeoVideoResponse GetVideo(VimeoGetVideoOptions options) {
        return new VimeoVideoResponse(Raw.GetVideo(options));
    }

    /// <summary>
    /// Gets a list of videos of the user matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for request to the API.</param>
    /// <returns>An instance of <see cref="VimeoVideoListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://developer.vimeo.com/api/reference/videos#search_videos</cref>
    /// </see>
    public VimeoVideoListResponse SearchVideos(VimeoSearchVideosOptions options) {
        return new VimeoVideoListResponse(Raw.SearchVideos(options));
    }

    #endregion

}