using MindQuote.Core.Abstracts;

namespace MindQuote.Infra.FakeData;

public class BookAuthorIntermediaryTable : IEntity
{
    public Guid Id { get; set; } = Guid.Empty;
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
}