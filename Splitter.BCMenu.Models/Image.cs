namespace Splitter.BCMenu.Models;

public class Image
{
    public Guid Id { get; set; }
    public required string Url { get; set; }
    public Guid ObjectId { get; set; }
}