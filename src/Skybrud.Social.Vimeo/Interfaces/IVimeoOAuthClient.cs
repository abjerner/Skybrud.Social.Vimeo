using Skybrud.Social.Http;
using Skybrud.Social.Vimeo.Endpoints.Raw;

namespace Skybrud.Social.Vimeo.Interfaces {

    public interface IVimeoOAuthClient {

        VimeoMeRawEndpoint Me { get; }

        VimeoUsersRawEndpoint Users { get; }

        SocialHttpResponse DoHttpGetRequest(string url);

    }

}