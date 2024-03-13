using MediatR;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

public class GetQuotesListQuery : IRequest<List<QuoteDTO>>
{
}