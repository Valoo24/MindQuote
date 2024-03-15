using MindQuote.Core.Entities;
using MindQuote.Core.Features.Quotes.Commands.CreateQuote;

namespace MindQuote.Core.Mappers;

public static class AuthorMapper
{
    public static Author ToAuthorEntity(this CreateQuoteCommand command)
    {
        return new Author
        {
            Id = Guid.NewGuid(),
            FirstName = command.AuthorFirstName,
            LastName = command.AuthorLastName
        };
    }

}