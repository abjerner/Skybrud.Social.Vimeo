---
outdated: true
order: -7
---

# Getting started

In order to access the Advanced API with Skybrud.Social, you need an instance of {{class:Skybrud.Social.Vimeo.Advanced.VimeoService}}. This class is your starting point to an object oriented approach to the API.

{{class:Skybrud.Social.Vimeo.Advanced.VimeoService}} will internally use an instance of {{class:Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient}} for the raw communication with the Advanced API ({{class:Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient}} is also used for authentication).

If you just need to access public data in the Advanced API, you can simply initialize a new instance of {{class:Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient}} with the consumer key and consumer secret of your Vimeo app:

```csharp
// Initialize a new instance of the OAuth client
VimeoOAuthClient client = new VimeoOAuthClient {
    ConsumerKey = "The consumer key of your app"
    ConsumerSecret = "The consumer secret of your app",
};

// Initialize a new VimeoService instance based on the OAuth client
VimeoService service = VimeoService.CreateFromOAuthClient(client);
```

If you need to make calls to the API on behalf of a user, you can also specify an access token and access token secret in addition to the consumer key and consumer secret.

The pages about [**Authentication**](./authentication/) shows how you can obtain an access token and access token secret of a user.

```csharp
// Initialize a new instance of the OAuth client
VimeoOAuthClient client = new VimeoOAuthClient {
    ConsumerKey = "The consumer key of your app"
    ConsumerSecret = "The consumer secret of your app",
    Token = "The access token of the user",
    TokenSecret = "The access token secret of the user"
};

// Initialize a new VimeoService instance based on the OAuth client
VimeoService service = VimeoService.CreateFromOAuthClient(client);
```

Both the {{class:Skybrud.Social.Vimeo.Advanced.VimeoService}} and the {{class:Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient}} classes are located in the `Skybrud.Social.Vimeo.Advanced` namespace.