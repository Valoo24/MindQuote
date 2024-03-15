using MindQuote.Core.Abstracts;
using MindQuote.Core.Dtos;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuote
{
    public class GetQuoteQueryResponse : IQueryResponse<QuoteDTO>
    {
        public QuoteDTO Content { get; set; } = new();
    }
}