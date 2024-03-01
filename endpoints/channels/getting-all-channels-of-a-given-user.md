---
order: 10
---

# Getting all channels of a given user

In the `Channels` endpoint, the `GetAll` method will let you get a list of all channels of a given user (at least the channels that you have access to).

In it's simplest form, you can call the method like shown below:

```cshtml
// Get all channels of a given user
VimeoChannelListResponse response = service.Channels.GetAll("umbraco");

// Iterate through the array of channels
foreach (VimeoChannel channel in response.Channels) {
        
    // Do something with the channel
        
}
```

The first parameter is the username of the user we want to get the channels for. It is also possible to specify the ID of the user instead - or an access token to get the channels of the authenticated user.

The list returned by the `GetAll` method is paginated, meaning that by default, it will only return the 50 first channels of the user. The `GetAll` also allows you to specify the page to be returned as well as how many channels that should be returned per page - eg. the first five channels:

```csharp
VimeoChannelListResponse response = Model.Channels.GetAll("umbraco", 1, 5)
```

You can also force the results to be sorted in a specific order:

```csharp
VimeoChannelListResponse response = Model.Channels.GetAll("umbraco", VimeoChannelsSort.MostVideos, 1, 5);
```

This will return the five channels with the most videos.

## Read more at developer.vimeo.com

- [API documentation for the **vimeo.channels.getAll** method](https://developer.vimeo.com/apis/advanced/methods/vimeo.channels.getAll)



## Full example

To summarize the examples above, here is a more complete example with imports and everything you need to implement this in a Razor view:

```cshtml
@using Skybrud.Social.Vimeo.Advanced
@using Skybrud.Social.Vimeo.Advanced.Enums
@using Skybrud.Social.Vimeo.Advanced.Models
@using Skybrud.Social.Vimeo.Advanced.Responses

@inherits WebViewPage<VimeoService>
              
@{

    // Get all channels of a given user
    VimeoChannelListResponse response = Model.Channels.GetAll("umbraco", VimeoChannelsSort.MostVideos, 1, 5);

    <pre>@response.OnThisPage</pre>
    <pre>@response.Page</pre>
    <pre>@response.PerPage</pre>
    <pre>@response.Total</pre>

    foreach (VimeoChannel channel in response.Channels) {
        
        <hr />

        <pre><strong>ID:</strong> @channel.Id</pre>
        <pre><strong>IsFeatured:</strong> @channel.IsFeatured</pre>
        <pre><strong>IsSponsored:</strong> @channel.IsSponsored</pre>
        <pre><strong>IsSubscribed:</strong> @channel.IsSubscribed</pre>
        <pre><strong>Name:</strong> @channel.Name</pre>
        <pre><strong>Description:</strong> @channel.Description</pre>
        <pre><strong>CreatedOn:</strong> @channel.CreatedOn</pre>
        <pre><strong>ModifiedOn:</strong> @channel.ModifiedOn</pre>
        <pre><strong>TotalVideos:</strong> @channel.TotalVideos</pre>
        <pre><strong>TotalSubscribers:</strong> @channel.TotalSubscribers</pre>
        <pre><strong>LogoUrl:</strong> @channel.LogoUrl</pre>
        <pre><strong>BadgeUrl:</strong> @channel.BadgeUrl</pre>
        <pre><strong>ThumbnailUrl:</strong> @channel.ThumbnailUrl</pre>
        <pre><strong>Url:</strong> @channel.Url</pre>
        <pre><strong>Layout:</strong> @channel.Layout</pre>
        <pre><strong>Theme:</strong> @channel.Theme</pre>
        
    }

}
```