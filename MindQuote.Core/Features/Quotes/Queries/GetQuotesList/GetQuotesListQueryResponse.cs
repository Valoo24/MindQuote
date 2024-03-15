using MindQuote.Core.Abstracts;
using MindQuote.Core.Dtos;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList
{
    public class GetQuotesListQueryResponse : IQueryResponse<List<QuoteDTO>>
    {
        public List<QuoteDTO> Content { get; set; } = new();
    }
}