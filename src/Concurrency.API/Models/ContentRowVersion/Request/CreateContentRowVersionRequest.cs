namespace Concurrency.API.Models.ContentRowVersion.Request;

public record CreateContentRowVersionRequest
{
    public string Title { get; init; }
    public string Text { get; init; }
    public string Html { get; init; }
}
