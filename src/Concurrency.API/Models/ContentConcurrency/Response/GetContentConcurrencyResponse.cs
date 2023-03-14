namespace Concurrency.API.Models.ContentConcurrency.Response;

public record GetContentConcurrencyResponse
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Text { get; init; }
    public string Html { get; init; }
}
