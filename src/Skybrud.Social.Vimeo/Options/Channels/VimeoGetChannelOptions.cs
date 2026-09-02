using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Vimeo.Options.Channels;

/// <summary>
/// Options describing a request to get information about a specific Vimeo channel.
/// </summary>
public class VimeoGetChannelOptions : IHttpRequestOptions {

    #region Properties

    /// <summary>
    /// Gets or sets the ID of the channel.
    /// </summary>
#if NET8_0_OR_GREATER
    public required long ChannelId { get; set; }
#else
    public long ChannelId { get; set; }
#endif

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance with default options.
    /// </summary>
    public VimeoGetChannelOptions() { }

    /// <summary>
    /// Initializes a new instance with the specified options.
    /// </summary>
    /// <param name="channelId">The ID of the channel.</param>
#if NET8_0_OR_GREATER
    [System.Diagnostics.CodeAnalysis.SetsRequiredMembers]
#endif
    public VimeoGetChannelOptions(long channelId) {
        ChannelId = channelId;
    }

    #endregion

    #region Members methods

    /// <summary>
    /// Gets an instance of <see cref="IHttpRequest"/> representing the request.
    /// </summary>
    public IHttpRequest GetRequest() {
        if (ChannelId == 0) throw new PropertyNotSetException(nameof(ChannelId));
        return new HttpRequest(HttpMethod.Get, $"/channels/{ChannelId}");
    }

    #endregion

}