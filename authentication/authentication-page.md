# Setting up an authentication page

This page will describe the steps involved for setting up a page for authenticating with the Vimeo Advanced API using OAuth 1.0a.

To get started, we need to initialize a new instance of the {{class:Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient}} class. This class is used for the authentication, as well as the raw communication with the Advanced API once the user is authenticated. The class has properties which should be populated with information about your Vimeo app:

```csharp
VimeoOAuthClient oauth = new VimeoOAuthClient {
    ConsumerKey = "The consumer key of your app",
    ConsumerSecret = "The consumer secret of your app",
    Callback = "Your callback URI"
};
```

If you don't know how to find your consumer key and consumer secret, head over to the <a href="https://developer.vimeo.com/apps" target="_blank">My API Apps at developer.vimeo.com</a>. The callback URL is simply the URL of your authentication page (so Vimeo knows which URL it should redirect the user back to after a successful authentication).

Once we have an instance of {{class:Skybrud.Social.Vimeo.Advanced.VimeoOAuthClient}}, we can request what in OAuth 1.0a terminology is called a request token. A request token (and a corresponding request token secret) is used to identify the request to Vimeo prior to actually redirecting the user to the Vimeo authentication page. The code to obtain a request token can look like:

```csharp
// Get a request token from the Vimeo API
OAuthRequestToken token = oauth.GetRequestToken();

// Save the token information to the session so we can grab it later
Session[token.Token] = token;

// Redirect the user to the authentication page at Vimeo.com
Response.Redirect(token.AuthorizeUrl);
```

We're saving the response to the session of the user so that we still have the request token and request token secret once the user is redirected back to our authentication page.

Once the user has been authenticated on the Vimeo authentication page, he/she is redirected back to the callback URL you specified earlier. It's wort noticing that the query string will now contain two parameters - `oauth_token` and `oauth_verifier`. `oauth_token` is the request token we received earlier, and both the `oauth_token` and `oauth_verifier` parameters can now be used to obtain an access token and access token secret for the user we're authenticating. Also, we're using using the request token and request token secret to sign/hash the call to the API, which is part of the security involved in OAuth 1.0a.

```csharp
// Grab the request token from the session
OAuthRequestToken token = Session[oAuthToken] as OAuthRequestToken;

// Update the OAuth client with information from the request token
oauth.Token = token.Token;
oauth.TokenSecret = token.TokenSecret;

// Obtain an access token from the request token and OAuth verifier
OAuthAccessToken accessToken = oauth.GetAccessToken(oAuthVerifier);
```

The {{class:Skybrud.Social.OAuth.OAuthAccessToken}} represents the response from the Vimeo API, and contains an `AccessToken` property and an `AccessTokenSecret` property containing the access token and access token secret respectively of the now authenticated user.

Along with the consumer key and consumer secret, you can now use the access token and access token secret to make calls to the Vimeo Advanced API on behalf of the authenticated user.

<div class="alert alert-info">If the user clicks <strong>Don't allow</strong> on Vimeo's authentication page, he/she is redirected to <code>https://vimeo.com/home</code> rather than back to your own authentication page.</div>



## Full example

Below you can see a full example of the steps explained above and implemented in a Razor partial view. Since this is just a very basic example, it will simply print out the access token and access token secret after a successful authentication. Obviously you should store the access token and access token secret somehow or further authenticate the user with your underlying system.

```cshtml
@using Skybrud.Social.OAuth
@using Skybrud.Social.Vimeo.Advanced
@using Skybrud.Social.Vimeo.Advanced.Responses

@inherits WebViewPage
              
@{
    
    // Initialize a new instance of the OAuth client
    VimeoOAuthClient oauth = new VimeoOAuthClient {
        ConsumerKey = "The consumer key of your app",
        ConsumerSecret = "The consumer secret of your app",
        Callback = "Your callback URI"
    };

    // Read some input from the query string
    string action = Request.QueryString["do"];
    string oAuthToken = Request.QueryString["oauth_token"];
    string oAuthVerifier = Request.QueryString["oauth_verifier"];

    // Handle the state when the user clicks our login button
    if (action == "login") {

        // Get a request token from the Vimeo API
        OAuthRequestToken token = oauth.GetRequestToken();

        // Save the token information to the session so we can grab it later
        Session[token.Token] = token;

        // Redirect the user to the authentication page at Vimeo.com
        Response.Redirect(token.AuthorizeUrl);
        return;

    }

    if (!String.IsNullOrEmpty(oAuthToken)) {

        // Grab the request token from the session
        OAuthRequestToken token = Session[oAuthToken] as OAuthRequestToken;

        if (token == null) {

            <p>An error occured. Timeout?</p>

        } else {

            // Some information for development purposes
            <div class="alert alert-info">
                <p><strong>Request Token:</strong> @token.Token</p>
                <p><strong>Request Token Secret:</strong> @token.TokenSecret</p>
            </div>

            // Update the OAuth client with information from the request token
            oauth.Token = token.Token;
            oauth.TokenSecret = token.TokenSecret;

            try {

                // Obtain an access token from the request token and OAuth verifier
                OAuthAccessToken accessToken = oauth.GetAccessToken(oAuthVerifier);

                // Update the OAuth client with the access token and access token secret
                oauth.Token = accessToken.Token;
                oauth.TokenSecret = accessToken.TokenSecret;

                // Initialize a new VimeoHttpService instance based on the OAuth client
                VimeoHttpService service = VimeoHttpService.CreateFromOAuthClient(oauth);
                
                // Get information about the authenticated user
                VimeoUserResponse user = service.People.GetInfo();

                // Some information for development purposes
                <div class="alert alert-info">
                    <strong>Hi @user.Person.DisplayName</strong> (@user.Person.Id)<br />
                    <p><strong>Access Token:</strong> @accessToken.Token</p>
                    <p><strong>Access Token Secret:</strong> @accessToken.TokenSecret</p>
                </div>

            } catch (Exception ex) {
                
                // TODO: Obviously we shouldn't expose exceptions to the user

                <pre style="color: red;">@(ex.GetType().FullName + ": " + ex.Message + "\r\n\r\n" + ex.StackTrace)</pre>

            }

        }

        return;

    }

    <a href="?do=login" class="btn btn-primary">Login with Vimeo</a>

}
```