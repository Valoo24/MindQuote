using MediatR;
using MindQuote.Core.Dtos;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

public class GetQuotesListQuery : IRequest<GetQuotesListQueryResponse>
{
}