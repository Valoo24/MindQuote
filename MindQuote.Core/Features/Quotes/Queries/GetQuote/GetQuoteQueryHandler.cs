using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers;

namespace MindQuote.Core.Features.Quotes.Queries.GetQuote;

public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQuery, GetQuoteQueryResponse>
{
    private IRepository<Quote> _quoteRepository;
    private IRepository<Author> _authorRepository;
    private IRepository<Book> _bookRepository;
    public GetQuoteQueryHandler(IRepository<Quote> quoteRepository, IRepository<Author> authorRepository, IRepository<Book> bookRepository)
    {
        _quoteRepository = quoteRepository;
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
    }

    public async Task<GetQuoteQueryResponse> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
    {
        var quote = await _quoteRepository.GetAsync(request.Id).WaitAsync(cancellationToken);

        var dto = quote.ToDTO();

        if (quote.AuthorId != Guid.Empty)
        {
            var author = await _authorRepository.GetAsync(quote.AuthorId).WaitAsync(cancellationToken);
            dto.AddAuthor(author);
        }

        if(quote.BookId != Guid.Empty)
        {
            var book = await _bookRepository.GetAsync(quote.BookId).WaitAsync(cancellationToken);
            dto.AddBook(book);
        }

        return new GetQuoteQueryResponse
        {
            Content = dto
        };
    }
}