namespace Concurrency.API.Models.ContentRowVersion.Response;

public record GetContentRowVersionResponse
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Text { get; init; }
    public string Html { get; init; }
}
