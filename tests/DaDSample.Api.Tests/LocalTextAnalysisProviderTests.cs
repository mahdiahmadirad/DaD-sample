using DaDSample.Api.Providers;

namespace DaDSample.Api.Tests;

public sealed class LocalTextAnalysisProviderTests
{
    private readonly LocalTextAnalysisProvider _provider = new();

    [Fact]
    public async Task SummarizeAsync_WhenTextHasAtMostThirtyWords_ReturnsNormalizedText()
    {
        var summary = await _provider.SummarizeAsync("one   two three", CancellationToken.None);

        Assert.Equal("one two three", summary);
    }

    [Fact]
    public async Task SummarizeAsync_WhenTextHasMoreThanThirtyWords_ReturnsFirstThirtyWords()
    {
        var text = string.Join(' ', Enumerable.Range(1, 31).Select(index => $"word{index}"));

        var summary = await _provider.SummarizeAsync(text, CancellationToken.None);

        var expected = $"{string.Join(' ', Enumerable.Range(1, 30).Select(index => $"word{index}"))}…";
        Assert.Equal(expected, summary);
    }
}
