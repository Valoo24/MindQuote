using MindQuote.Core.Abstracts;

namespace MindQuote.Core.Entities;

public class Quote : IEntity
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string AuthorFirstName { get; set; } = string.Empty;
    public string AuthorLastName { get; set; } = string.Empty;
    public string? Origin { get; set; }
}