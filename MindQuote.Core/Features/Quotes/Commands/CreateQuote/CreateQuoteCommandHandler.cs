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
        Guid responseQuoteId = Guid.Empty;
        Guid responseAuthorId = Guid.Empty;
        Guid responseBookId = Guid.Empty;
        bool isAnonymousAuthor = string.IsNullOrEmpty(request.AuthorFirstName) && string.IsNullOrEmpty(request.AuthorLastName);

        if (!isAnonymousAuthor)
        {
            //On cherche l'auteur avec son prénom et son nom et s'il n'existe pas on le crée.
        }

        if(!string.IsNullOrEmpty(request.Origin))
        {
            //On vérifie le livre avec son titre et s'il n'existe pas on le crée
        }

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