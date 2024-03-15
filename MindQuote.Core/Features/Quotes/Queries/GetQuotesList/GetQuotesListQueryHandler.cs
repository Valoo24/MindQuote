using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers.Quotes;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

public class GetQuotesListQueryHandler : IRequestHandler<GetQuotesListQuery, List<QuoteDTO>>
{
    private IRepository<Quote> _repository;
    public GetQuotesListQueryHandler(IRepository<Quote> repository)
    {
        _repository = repository;
    }
    public async Task<List<QuoteDTO>> Handle(GetQuotesListQuery request, CancellationToken cancellationToken)
    {
        List<QuoteDTO> dtos = new List<QuoteDTO>();
        var result = await _repository.GetAsync();
        foreach(var entity in result) 
        {
            dtos.Add(entity.ToDTO());
        }
        return dtos;
    }
}