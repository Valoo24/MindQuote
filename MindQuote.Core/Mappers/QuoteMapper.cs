using MindQuote.Core.Dtos;
using MindQuote.Core.Entities;
using MindQuote.Core.Features.Quotes.Commands.CreateQuote;

namespace MindQuote.Core.Mappers;

public static class QuoteMapper
{
    public static Quote ToQuoteEntity(this CreateQuoteCommand command)
    {
        return new Quote
        {
            Id = Guid.NewGuid(),
            Content = command.Content
        };
    }

    public static Quote ToQuoteEntity(this CreateQuoteCommand command, Author author)
    {
        return new Quote
        {
            Id = Guid.NewGuid(),
            AuthorId = author.Id,
            Content = command.Content
        };
    }

    public static QuoteDTO ToDTO(this Quote entity)
    {
        return new QuoteDTO
        {
            Id = entity.Id,
            Content = entity.Content,
        };
    }

    public static QuoteDTO ToDTO(this Quote entity, Author author)
    {
        return new QuoteDTO
        {
            Id = entity.Id,
            Content = entity.Content,
            AuthorFirstName = author.FirstName,
            AuthorLastName = author.LastName
        };
    }
}