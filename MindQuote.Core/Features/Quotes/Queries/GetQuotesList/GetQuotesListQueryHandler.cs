using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

public class GetQuotesListQueryHandler : IRequestHandler<GetQuotesListQuery, GetQuotesListQueryResponse>
{
    private IRepository<Quote> _quoteRepository;
    private IRepository<Author> _authorRepository;
    public GetQuotesListQueryHandler(IRepository<Quote> quoteRepository, IRepository<Author> authorRepository)
    {
        _quoteRepository = quoteRepository;
        _authorRepository = authorRepository;

    }
    public async Task<GetQuotesListQueryResponse> Handle(GetQuotesListQuery request, CancellationToken cancellationToken)
    {
        GetQuotesListQueryResponse response = new();
        var quotes = await _quoteRepository.GetAsync().WaitAsync(cancellationToken);
        var authors = await _authorRepository.GetAsync().WaitAsync(cancellationToken);

        foreach (var entity in quotes)
        {
            var author = authors.FirstOrDefault(a => a.Id == entity.AuthorId) ?? 
                throw new ArgumentNullException(nameof(entity));

            var dto = entity.ToDTO(author);

            response.Content.Add(dto);
        }

        return response;
    }
}