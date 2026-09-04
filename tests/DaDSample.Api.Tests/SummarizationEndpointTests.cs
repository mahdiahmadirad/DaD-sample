using System.Net;
using System.Net.Http.Json;
using DaDSample.Api.Features.Summarization;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DaDSample.Api.Tests;

public sealed class SummarizationEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public SummarizationEndpointTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostSummary_WhenTextIsBlank_ReturnsBadRequest()
    {
        var response = await _client.PostAsJsonAsync("/api/summaries", new SummarizeRequest("   "));

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task PostSummary_WhenTextIsValid_ReturnsSummary()
    {
        var response = await _client.PostAsJsonAsync(
            "/api/summaries",
            new SummarizeRequest("Document-aware development keeps project intent explicit."));

        response.EnsureSuccessStatusCode();
        var payload = await response.Content.ReadFromJsonAsync<SummarizeResponse>();

        Assert.NotNull(payload);
        Assert.Equal("Document-aware development keeps project intent explicit.", payload.Summary);
    }
}
