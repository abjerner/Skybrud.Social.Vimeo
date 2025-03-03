using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.Vimeo.Models.Tags;

/// <summary>
/// Class representing the metadata of a Vimeo tag.
/// </summary>
public class VimeoTagMetadata : VimeoObject {

    #region Properties

    /// <summary>
    /// Gets information about the connections of the channel.
    /// </summary>
    public VimeoTagConnections Connections { get; }

    #endregion

    #region Constructors

    private VimeoTagMetadata(JObject json) : base(json) {
        Connections = json.GetObject("connections", VimeoTagConnections.Parse)!;
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="VimeoTagMetadata"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="VimeoTagMetadata"/>.</returns>
    [return: NotNullIfNotNull(nameof(json))]
    public static VimeoTagMetadata? Parse(JObject? json) {
        return json == null ? null : new VimeoTagMetadata(json);
    }

    #endregion

}