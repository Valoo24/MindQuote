using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Features.Quotes.Queries.GetQuotesList;
using MindQuote.Core.Mappers.Quotes;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuote;

public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQuery, QuoteDTO>
{
    private IRepository<Quote> _repository;

    public GetQuoteQueryHandler(IRepository<Quote> repository)
    {
        _repository = repository;
    }

    public async Task<QuoteDTO> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAsync().WaitAsync(cancellationToken);
        var entity = result.ToList().Where(q => q.Id == request.Id).FirstOrDefault() ?? null;
        if(entity is null) throw new ArgumentNullException($"No matching Quote found for the Id {request.Id}");
        else return entity.ToDTO();
    }
}