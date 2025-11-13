using TestProject.Api.Clients;

namespace TestProject.Api.Tests;

[TestFixture]
public class LoginTests
{
    private LoginClient _client;

    [SetUp]
    public async Task SetUp()
    {
        _client = await LoginClient.CreateAsync();
    }

    [Test]
    public async Task GetLoginFailTotal_NoParams_ReturnsUsers()
    {
        var users = await _client.GetLoginFailTotal();
        Assert.IsNotNull(users);
        Assert.IsTrue(users.Count > 0, "Should return at least one user");
    }

    [TestCase("testuser1")]
    [TestCase("nonexistentuser")]
    public async Task GetLoginFailTotal_ByUserName(string userName)
    {
        var users = await _client.GetLoginFailTotal(userName: userName);
        if (userName == "nonexistentuser")
            Assert.IsTrue(users.Count == 0);
        else
            Assert.IsTrue(users.Any(u => u.UserName == userName));
    }

    [TestCase(0)]
    [TestCase(2)]
    public async Task GetLoginFailTotal_ByFailCount(int failCount)
    {
        var users = await _client.GetLoginFailTotal(failCount: failCount);
        Assert.IsTrue(users.All(u => u.FailCount > failCount));
    }

    [TestCase(1)]
    [TestCase(3)]
    public async Task GetLoginFailTotal_WithFetchLimit(int fetchLimit)
    {
        var users = await _client.GetLoginFailTotal(fetchLimit: fetchLimit);
        Assert.LessOrEqual(users.Count, fetchLimit);
    }

    [TestCase("testuser1")]
    public async Task ResetLoginFailTotal_ExistingUser_SetsFailCountToZero(string userName)
    {
        var response = await _client.ResetLoginFailTotal(userName);
        Assert.IsTrue(response.IsSuccessStatusCode);

        var users = await _client.GetLoginFailTotal(userName: userName);
        Assert.IsTrue(users.Count == 1);
        Assert.AreEqual(0, users[0].FailCount);
    }

    [TestCase("nonexistentuser")]
    public async Task ResetLoginFailTotal_NonExistentUser_ReturnsError(string userName)
    {
        var response = await _client.ResetLoginFailTotal(userName);
        Assert.IsFalse(response.IsSuccessStatusCode);
    }
}

