namespace Concurrency.API.Models.ContentConcurrency.Request;

public record UpdateContentConcurrencyRequest
{
    public string Title { get; init; }
    public string Text { get; init; }
    public string Html { get; init; }
}
