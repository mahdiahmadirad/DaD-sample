using DaDSample.Api.Features.Summarization;
using DaDSample.Api.Providers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAIProvider, LocalTextAnalysisProvider>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapSummarization();

app.Run();

public partial class Program;
