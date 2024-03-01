---
order: 20
teaser: Endpoint for working with channels and videos of a channel.
---

# Getting all videos of a channel

The `GetVideos` method in the `Channels` endpoint lets you get a list of videos of a given channel:

```csharp
// Get all videos of a channel
VimeoVideoListResponse response = service.Channels.GetVideos(991662);
```

In this example, `991662` is the ID of the channel for Umbraco's <a href="https://vimeo.com/channels/codegarden16" target="_blank">Codegarden 16</a> videos.

The list returned by the `GetVideos` is paginated, and by default, each page will contain up to 50 videos. The specify both a page and the amount of videos to be returned on each page, we can use a overload of the `GetVideos` method:

```csharp
// Get all videos of a channel
VimeoVideoListResponse response = service.Channels.GetVideos(991662, 1, 10);
```

This will request the first page (page `1`) and have a maximum of 10 videos per page.



## Read more at developer.vimeo.com

- [API documentation for the **vimeo.channels.getVideos** method](https://developer.vimeo.com/apis/advanced/methods/vimeo.channels.getVideos)



## Full example

To summarize the examples above, here is a more complete example with imports and everything you need to implement this in a Razor view:

```cshtml
@using Newtonsoft.Json.Linq
@using Skybrud.Social.Vimeo.Advanced
@using Skybrud.Social.Vimeo.Advanced.Responses

@inherits WebViewPage<VimeoService>
              
@{

    // Get all videos of a channel
    VimeoVideoListResponse response = service.Channels.GetVideos(991662, 1, 10);

    <pre>@response.OnThisPage</pre>
    <pre>@response.Page</pre>
    <pre>@response.PerPage</pre>
    <pre>@response.Total</pre>

    foreach (var video in response.Videos) {
        
        <hr />

        <pre>Id: @video.Id</pre>
        <pre>IsHd: @video.IsHd</pre>
        <pre>IsTranscoding: @video.IsTranscoding</pre>
        <pre>License: @video.License</pre>
        <pre>Privacy: @video.Privacy</pre>
        <pre>Title: @video.Title</pre>
        <pre>Description: @video.Description</pre>
        <pre>UploadDate: @video.UploadDate</pre>
        <pre>ModifiedDate: @video.ModifiedDate</pre>
        <pre>Width: @video.Width</pre>
        <pre>Height: @video.Height</pre>
        <pre>Duration: @video.Duration</pre>
        <pre>Owner: @video.Owner</pre>
        <pre>Cast: @video.Cast</pre>
        <pre>Urls: @video.Urls</pre>
        <pre>Thumbnails: @video.Thumbnails</pre>
        
    }

}
```