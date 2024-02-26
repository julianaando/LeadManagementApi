namespace LeadManagementApi.Test;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting;
using LeadManagementApi.Controllers;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    public HttpClient _clientTest;

    public IntegrationTests(WebApplicationFactory<Program> factory)
    {
        _clientTest = factory.CreateClient();
    }

    [Theory(DisplayName = "Testing endpoint /GET Leads")]
    [InlineData("/leads")]
    public async Task TestGetLeads(string url)
    {
        var response = await _clientTest.GetAsync(url);
        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
    }
}

