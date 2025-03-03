using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Channels;

/// <summary>
/// Class representing the metadata of a Vimeo channel.
/// </summary>
public class VimeoChannelMetadata : VimeoObject {

    #region Properties

    /// <summary>
    /// Gets information about the connections of the channel.
    /// </summary>
    public VimeoChannelConnections Connections { get; }

    #endregion

    #region Constructors

    private VimeoChannelMetadata(JObject json) : base(json) {
        Connections = json.GetObject("connections", VimeoChannelConnections.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoChannelMetadata"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="VimeoChannelMetadata"/>.</returns>
    [return: NotNullIfNotNull(nameof(json))]
    public static VimeoChannelMetadata? Parse(JObject? json) {
        return json == null ? null : new VimeoChannelMetadata(json);
    }

    #endregion

}