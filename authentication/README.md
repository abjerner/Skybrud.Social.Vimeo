# Authentication

To get started with accessing the Vimeo Advanced API, you need to <a href="https://developer.vimeo.com/apps/new" target="_blank"><strong>create a new Vimeo app</strong></a> (or use an <a href="https://developer.vimeo.com/apps" target="_blank"><strong>existing app</strong></a>).

Vimeo supports both OAuth 1.0a (referred to as simply *OAuth* by Vimeo) and OAuth 2.0 for authentication, but only OAuth 1.0a is currently supported in Skybrud.Social.

In Skybrud.Social, you can access the Advanced API using the {{class:Skybrud.Social.Vimeo.Advanced.VimeoHttpService}} class (the {{class:Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient}} class is used internally for the raw communication with the API). If you just need to access public information, you can simply use the client ID and client secret (called consumer key and consumer secret respectively following the OAuth terminology), and as such initialize a new instance of {{class:Skybrud.Social.Vimeo.Advanced.VimeoHttpService}} like:

```csharp
// Initialize a new client
VimeoOAuthClient client = new VimeoOAuthClient {
    ConsumerKey = "Your client ID / consumer key",
    ConsumerSecret = "Your client secret / consumer secret"
};

// Initialize a new service based on the client
VimeoHttpService service = VimeoHttpService.CreateFromOAuthClient(client);
```

The consumer key and consumer secret only identifies your app, but not a specific user. If you need to access private information (or add or change something on behalf of a specific user), you also need to specify an access token and access token. For your own Vimeo user, you can simply read the access token and access token secret from the Vimeo page of your app. Then to initialize a new instance of {{class:Skybrud.Social.Vimeo.Advanced.VimeoService}}, you can update your code to:

```csharp
// Initialize a new client
VimeoOAuthClient client = new VimeoOAuthClient {
    ConsumerKey = "Your client ID / consumer key",
    ConsumerSecret = "Your client secret / consumer secret",
    Token = "Your access token",
    TokenSecret = "Your access token secret"
};

// Initialize a new service based on the client
VimeoService service = VimeoService.CreateFromOAuthClient(client);
```

If you need to obtain the access token and access token secret of visitors of your website, you should have a look at the page about [**setting up an authentication page**](./authentication-page.md).
