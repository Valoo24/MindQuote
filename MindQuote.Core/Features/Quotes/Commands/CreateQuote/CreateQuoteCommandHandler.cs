using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers;

namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, CreateQuoteCommandResponse>
{
    private IRepository<Quote> _quoteRepository;
    private IRepository<Author> _authorRepository;
    public CreateQuoteCommandHandler(IRepository<Quote> repository, IRepository<Author> authorRepository)
    {
        _quoteRepository = repository;
        _authorRepository = authorRepository;
    }
    public async Task<CreateQuoteCommandResponse> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        CreateQuoteCommandResponse response = new();
        var authors = await _authorRepository.GetAsync().WaitAsync(cancellationToken);

        var newAuthor = request.ToAuthorEntity();

        var result = authors.FirstOrDefault(a => a.FirstName == newAuthor.FirstName && a.LastName == newAuthor.LastName);

        if (result is null) response.Content.AuthorId = await _authorRepository.CreateAsync(newAuthor);
        else response.Content.AuthorId = result.Id;

        response.Content.QuoteId = await _quoteRepository.CreateAsync(request.ToQuoteEntity(newAuthor));

        return response;
    }
}