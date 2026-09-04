using DaDSample.Api.Providers;

namespace DaDSample.Api.Features.Summarization;

public static class SummarizationEndpoint
{
    public static IEndpointRouteBuilder MapSummarization(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/api/summaries", HandleAsync);
        return endpoints;
    }

    private static async Task<IResult> HandleAsync(
        SummarizeRequest request,
        IAIProvider provider,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Text))
        {
            return Results.BadRequest(new { error = "Text is required." });
        }

        var summary = await provider.SummarizeAsync(request.Text, cancellationToken);
        return Results.Ok(new SummarizeResponse(summary));
    }
}
