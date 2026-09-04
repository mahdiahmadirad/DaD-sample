namespace DaDSample.Api.Providers;

public sealed class LocalTextAnalysisProvider : IAIProvider
{
    private const int SummaryWordLimit = 30;

    public Task<string> SummarizeAsync(string text, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        cancellationToken.ThrowIfCancellationRequested();

        var words = text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries);
        var summary = words.Length <= SummaryWordLimit
            ? string.Join(' ', words)
            : $"{string.Join(' ', words.Take(SummaryWordLimit))}…";

        return Task.FromResult(summary);
    }
}
