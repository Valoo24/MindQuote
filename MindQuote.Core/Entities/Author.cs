using MindQuote.Core.Abstracts;

namespace MindQuote.Core.Entities;

public class Author : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}