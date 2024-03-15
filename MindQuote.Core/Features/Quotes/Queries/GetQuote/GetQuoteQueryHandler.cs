using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers.Quotes;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuote;

public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQuery, GetQuoteQueryResponse>
{
    private IRepository<Quote> _repository;

    public GetQuoteQueryHandler(IRepository<Quote> repository)
    {
        _repository = repository;
    }

    public async Task<GetQuoteQueryResponse> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
    {
        GetQuoteQueryResponse response = new();
        var result = await _repository.GetAsync().WaitAsync(cancellationToken);
        var entity = result.ToList().Where(q => q.Id == request.Id).FirstOrDefault() ?? 
            throw new ArgumentNullException($"No matching Quote found for the Id {request.Id}");
        
        response.Content = entity.ToDTO();
        return response;
    }
}