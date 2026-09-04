namespace DaDSample.Api.Providers;

public interface IAIProvider
{
    Task<string> SummarizeAsync(string text, CancellationToken cancellationToken);
}
