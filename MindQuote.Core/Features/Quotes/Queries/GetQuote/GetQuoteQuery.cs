using MediatR;
using MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuote;

public class GetQuoteQuery : IRequest<QuoteDTO>
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public string? AuthorFirstName { get; set; }
    public string? AuthorLastName { get; set; }
    public string? Origin { get; set; }
}