using Refit;
using TestProject.Api.Schemas;

namespace TestProject.Api.Interfaces;

public interface ILoginApiRequests
{
    [Get("/loginfailtotal")]
    Task<List<LoginFailUser>> GetLoginFailTotal(
        [AliasAs("user_name")] string userName = null,
        [AliasAs("fail_count")] int? failCount = null,
        [AliasAs("fetch_limit")] int? fetchLimit = null);

    [Put("/resetloginfailtotal")]
    Task<ApiResponse<string>> ResetLoginFailTotal([Body] ResetLoginFailRequest request);
}

