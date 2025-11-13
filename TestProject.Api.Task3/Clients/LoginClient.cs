using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Api.Interfaces;
using TestProject.Api.Schemas;

namespace TestProject.Api.Clients;

public class LoginClient
{
    private readonly ILoginApiRequests _apiClient;

    private LoginClient(ILoginApiRequests apiClient)
    {
        _apiClient = apiClient;
    }

    public static async Task<LoginClient> CreateAsync()
    {
        var apiClient = await ServiceClientProvider.GetApiClient<ILoginApiRequests>();
        return new LoginClient(apiClient);
    }

    // Get all users or filtered by params
    public async Task<List<LoginFailUser>> GetLoginFailTotal(string userName = null, int? failCount = null, int? fetchLimit = null)
    {
        return await _apiClient.GetLoginFailTotal(userName, failCount, fetchLimit);
    }

    // Reset fail count for a user
    public async Task<ApiResponse<string>> ResetLoginFailTotal(string userName)
    {
        return await _apiClient.ResetLoginFailTotal(new ResetLoginFailRequest { Username = userName });
    }
}

