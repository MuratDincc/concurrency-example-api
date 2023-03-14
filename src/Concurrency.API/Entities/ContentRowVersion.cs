using System.ComponentModel.DataAnnotations;

namespace Concurrency.API.Entities;

public class ContentRowVersion
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Text { get; set; }

    public string Html { get; set; }

    [Timestamp]
    public byte[] RowVersion { get; set; }
}