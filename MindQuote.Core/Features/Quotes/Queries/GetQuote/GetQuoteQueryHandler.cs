using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuote;

public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQuery, GetQuoteQueryResponse>
{
    private IRepository<Quote> _quoteRepository;
    private IRepository<Author> _authorRepository;
    public GetQuoteQueryHandler(IRepository<Quote> quoteRepository, IRepository<Author> authorRepository)
    {
        _quoteRepository = quoteRepository;
        _authorRepository = authorRepository;
    }

    public async Task<GetQuoteQueryResponse> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
    {
        GetQuoteQueryResponse response = new();
        var quotes = await _quoteRepository.GetAsync().WaitAsync(cancellationToken);
        var authors = await _authorRepository.GetAsync().WaitAsync(cancellationToken); 

        var entity = quotes.ToList().Where(q => q.Id == request.Id).FirstOrDefault() ?? 
            throw new ArgumentNullException($"No matching Quote found for the Id {request.Id}");

        var author = authors.FirstOrDefault(a => a.Id == entity.AuthorId) ?? 
            throw new ArgumentNullException();

        response.Content = entity.ToDTO(author);

        return response;
    }
}