using MediatR;
using MindQuote.Core.Dtos;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuote;

public class GetQuoteQuery : IRequest<GetQuoteQueryResponse>
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public string? AuthorFirstName { get; set; }
    public string? AuthorLastName { get; set; }
    public string? Origin { get; set; }
}