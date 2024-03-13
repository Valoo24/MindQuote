using MediatR;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

public class GetQuotesListQueryHandler : IRequestHandler<GetQuotesListQuery, List<QuoteDTO>>
{
    public async Task<List<QuoteDTO>> Handle(GetQuotesListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}