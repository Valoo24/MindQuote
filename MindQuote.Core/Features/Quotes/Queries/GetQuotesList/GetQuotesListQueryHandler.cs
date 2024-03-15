using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Dtos;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers.Quotes;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

public class GetQuotesListQueryHandler : IRequestHandler<GetQuotesListQuery, GetQuotesListQueryResponse>
{
    private IRepository<Quote> _repository;
    public GetQuotesListQueryHandler(IRepository<Quote> repository)
    {
        _repository = repository;
    }
    public async Task<GetQuotesListQueryResponse> Handle(GetQuotesListQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync();
        GetQuotesListQueryResponse response = new();
        foreach (var entity in result)
        {
            response.Content.Add(entity.ToDTO());
        }

        return response;
    }
}