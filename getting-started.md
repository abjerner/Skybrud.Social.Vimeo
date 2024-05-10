---
outdated: true
order: -7
---

# Getting started

In order to access the Advanced API with Skybrud.Social, you need an instance of <code class="Skybrud.Social.Vimeo.Advanced.VimeoService, Skybrud.Social.Vimeo">VimeoService</code>. This class is your starting point to an object oriented approach to the API.

<code class="Skybrud.Social.Vimeo.Advanced.VimeoService, Skybrud.Social.Vimeo">VimeoService</code> will internally use an instance of <code class="Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient, Skybrud.Social.Vimeo">VimeoService</code> for the raw communication with the Advanced API (<code class="Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient, Skybrud.Social.Vimeo">VimeoService</code> is also used for authentication).

If you just need to access public data in the Advanced API, you can simply initialize a new instance of <code class="Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient, Skybrud.Social.Vimeo">VimeoService</code> with the consumer key and consumer secret of your Vimeo app:

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

Both the <code class="Skybrud.Social.Vimeo.Advanced.VimeoService, Skybrud.Social.Vimeo">VimeoService</code> and the <code class="Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient, Skybrud.Social.Vimeo">VimeoService</code> classes are located in the `Skybrud.Social.Vimeo.Advanced` namespace.