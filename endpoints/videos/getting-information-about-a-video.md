# Getting information about a video

In the `Videos` endpoint, the `GetInfo` method lets you request information about a given video by it's ID. For instance to get information about the <a href="https://vimeo.com/172382998" target="_blank">Umbraco: The Friendly CMS</a> video, the code could look as:

```csharp
// Get information about a specific video
VimeoVideoResponse response = Model.Videos.GetInfo(172382998);

// Get a reference to the video
VimeoVideo video = response.Video;
```



## Read more at developer.vimeo.com

- [API documentation for the **vimeo.videos.getInfo** method](https://developer.vimeo.com/apis/advanced/methods/vimeo.videos.getInfo)



## Full example

To summarize the examples above, here is a more complete example with imports and everything you need to implement this in a Razor view:

```cshtml
@using Newtonsoft.Json.Linq
@using Skybrud.Social.Vimeo.Advanced
@using Skybrud.Social.Vimeo.Advanced.Objects
@using Skybrud.Social.Vimeo.Advanced.Responses

@inherits WebViewPage<VimeoHttpService>
              
@{

    // Get information about a specific video
    VimeoVideoResponse response = Model.Videos.GetInfo(172382998);

    // Get a reference to the video
    VimeoVideo video = response.Video;

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
```