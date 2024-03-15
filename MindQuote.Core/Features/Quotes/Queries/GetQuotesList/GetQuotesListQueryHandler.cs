using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

public class GetQuotesListQueryHandler : IRequestHandler<GetQuotesListQuery, GetQuotesListQueryResponse>
{
    private IRepository<Quote> _quoteRepository;
    private IRepository<Author> _authorRepository;
    private IRepository<Book> _bookRepository;
    public GetQuotesListQueryHandler(IRepository<Quote> quoteRepository, IRepository<Author> authorRepository, IRepository<Book> bookRepository)
    {
        _quoteRepository = quoteRepository;
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;

    }
    public async Task<GetQuotesListQueryResponse> Handle(GetQuotesListQuery request, CancellationToken cancellationToken)
    {
        GetQuotesListQueryResponse response = new();
        var quotes = await _quoteRepository.GetAsync().WaitAsync(cancellationToken);

        foreach (var quote in quotes)
        {
            var dto = quote.ToDTO();
            if(quote.AuthorId != Guid.Empty)
            {
                var author = await _authorRepository.GetAsync(quote.AuthorId).WaitAsync(cancellationToken);
                dto.AddAuthor(author);
            }

            if (quote.BookId != Guid.Empty)
            {
                var book = await _bookRepository.GetAsync(quote.BookId).WaitAsync(cancellationToken);
                dto.AddBook(book);
            }
            response.Content.Add(dto);
        }

        return response;
    }
}