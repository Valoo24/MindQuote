using MindQuote.Core.Dtos;
using MindQuote.Core.Entities;
using MindQuote.Core.Features.Quotes.Commands.CreateQuote;

namespace MindQuote.Core.Mappers;

public static class BookMapper
{
    public static Book ToBookEntity(this CreateQuoteCommand command)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = command.Origin
        };
    }
}