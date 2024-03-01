---
teaser: See how to get information about a specific user by either an ID or a username.
---

# Getting information about a person

A user on Vimeo is referred to as a person (or people in plural). The `People` endpoint exposes a `GetInfo` method to get information about a given person by either the ID or the username of the user.

The partial Razor view below illustrates how you can use the `GetInfo` method (along with some of the properties available for a person):

```cshtml
@using Skybrud.Social.Vimeo.Advanced
@using Skybrud.Social.Vimeo.Advanced.Responses

@inherits WebViewPage<VimeoHttpService>
              
@{

    // Get information about a specific user
    VimeoUserResponse response = Model.People.GetInfo("umbraco");

    <pre><strong>ID:</strong> @response.Person.Id</pre>
    <pre><strong>Username:</strong> @response.Person.Username</pre>
    <pre><strong>Display name:</strong> @response.Person.DisplayName</pre>
    <pre><strong>Created on:</strong> @response.Person.CreatedOn</pre>
    <pre><strong>Bio:</strong> @response.Person.Bio</pre>
    <pre><strong>Location:</strong> @response.Person.Location</pre>
    <pre><strong>Number of albums:</strong> @response.Person.NumberOfAlbums</pre>
    <pre><strong>Number of channels:</strong> @response.Person.NumberOfChannels</pre>
    <pre><strong>Number of contacts:</strong> @response.Person.NumberOfContacts</pre>
    <pre><strong>Number of groups:</strong> @response.Person.NumberOfGroups</pre>
    <pre><strong>Number of likes:</strong> @response.Person.NumberOfLikes</pre>
    <pre><strong>Number of uploads:</strong> @response.Person.NumberOfUploads</pre>
    <pre><strong>Number of videos:</strong> @response.Person.NumberOfVideos</pre>
    <pre><strong>Number of videos appear in:</strong> @response.Person.NumberOfVideosAppearIn</pre>

}
```

The API returns a few more properties, but these are currently not supported in **Skybrud.Social.Vimeo**.

As an alternative to an ID or a username, you can also specify an OAuth token to get information about the authenticated user.



## Read more at developer.vimeo.com

- [API documentation for the **vimeo.people.getInfo** method](https://developer.vimeo.com/apis/advanced/methods/vimeo.people.getInfo)