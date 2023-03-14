using System.ComponentModel.DataAnnotations;

namespace Concurrency.API.Entities;

public class ContentConcurrency
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public string Html { get; set; }
}