using System.Net.Http.Headers;
using Refit;

namespace TestProject.Api;

public class ServiceClientProvider
{
    private static string _token;

    public static async Task<T> GetApiClient<T>()
    {
        var baseUrl = "https://api.site.com";
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };

        if (string.IsNullOrEmpty(_token))
        {
            _token = await GetAuthorizationToken();
        }

        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _token);

        return RestService.For<T>(httpClient);
    }

    private static async Task<string> GetAuthorizationToken()
    {
        return await Task.FromResult("your_token_here");
    }
}