using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Vimeo.Options.Videos;

/// <summary>
/// Options describing a request to get information about a specific Vimeo video.
/// </summary>
public class VimeoGetVideoOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the video.
    /// </summary>
#if NET8_0_OR_GREATER
    public required long VideoId { get; set; }
#else
    public long VideoId { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public VimeoGetVideoOptions() { }

    /// <summary>
    /// Initializes a new instance with the specified options.
    /// </summary>
    /// <param name="videoId">The ID of the video.</param>
#if NET8_0_OR_GREATER
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
    public VimeoGetVideoOptions(long videoId) {
        VideoId = videoId;
    }

    #endregion

    #region Members methods

    /// <inheritdoc />
    public IHttpRequest GetRequest() {
        if (VideoId == 0) throw new PropertyNotSetException(nameof(VideoId));
        return new HttpRequest(HttpMethod.Get, $"/videos/{VideoId}");
    }

    #endregion

}