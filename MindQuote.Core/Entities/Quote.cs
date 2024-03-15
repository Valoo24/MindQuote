using MindQuote.Core.Abstracts;

namespace MindQuote.Core.Entities;

public class Quote : IEntity
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; } = string.Empty;
}