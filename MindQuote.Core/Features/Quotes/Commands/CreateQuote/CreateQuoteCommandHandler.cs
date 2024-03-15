using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers;
using MindQuote.Infra.FakeData;

namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, CreateQuoteCommandResponse>
{
    private IRepository<Quote> _quoteRepository;
    private IRepository<Author> _authorRepository;
    private IRepository<Book> _bookRepository;
    private IRepository<BookAuthorIntermediaryTable> _bookAuthorRepository;
    public CreateQuoteCommandHandler(IRepository<Quote> quoterepository, IRepository<Author> authorRepository, IRepository<Book> bookRepository, IRepository<BookAuthorIntermediaryTable> bookAuthorRepository)
    {
        _quoteRepository = quoterepository;
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
        _bookAuthorRepository = bookAuthorRepository;
    }
    public async Task<CreateQuoteCommandResponse> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        Guid responseQuoteId = Guid.Empty;
        Guid responseAuthorId = Guid.Empty;
        Guid responseBookId = Guid.Empty;
        bool isAnonymousAuthor = string.IsNullOrEmpty(request.AuthorFirstName) && string.IsNullOrEmpty(request.AuthorLastName);

        if (!isAnonymousAuthor)
        {
            var searchAuthorEntity = request.ToAuthorEntity();
            var searchAuthorResult = await _authorRepository.GetAsync(searchAuthorEntity).WaitAsync(cancellationToken);
            if (searchAuthorResult is null)
                responseAuthorId = await _authorRepository.CreateAsync(searchAuthorEntity);
            else
                responseAuthorId = searchAuthorResult.Id;
        }

        if(!string.IsNullOrEmpty(request.Origin))
        {
            var searchBookEntity = request.ToBookEntity();
            var searchBookResult = await _bookRepository.GetAsync(searchBookEntity).WaitAsync(cancellationToken);
            if (searchBookResult is null)
                responseBookId = await _bookRepository.CreateAsync(searchBookEntity);
            else
                responseBookId = searchBookResult.Id;
        }

        if(responseBookId != Guid.Empty)
        {
            var searchBookAuthorIntermediary = new BookAuthorIntermediaryTable
            {
                AuthorId = responseAuthorId,
                BookId = responseBookId,
            };
            var searchBookAuthorResult = await _bookAuthorRepository.GetAsync(searchBookAuthorIntermediary).WaitAsync(cancellationToken);
            if (searchBookAuthorResult is null)
                await _bookAuthorRepository.CreateAsync(searchBookAuthorIntermediary);
        }

        var createQuote = request.ToQuoteEntity();
        createQuote.AuthorId = responseAuthorId;
        createQuote.BookId = responseBookId;
        responseQuoteId = await _quoteRepository.CreateAsync(createQuote);

        return new CreateQuoteCommandResponse
        {
            Content = new CreateQuoteCommandResponseDto
            {
                QuoteId = responseQuoteId,
                AuthorId = responseAuthorId,
                BookId = responseBookId,
            }
        };
    }
}