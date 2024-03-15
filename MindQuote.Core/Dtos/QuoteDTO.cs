namespace MindQuote.Core.Dtos;

public class QuoteDTO
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string AuthorFirstName { get; set; } = string.Empty;
    public string AuthorLastName { get; set; } = string.Empty;
    public string? Origin { get; set; } = null;
}