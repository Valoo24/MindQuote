using MindQuote.Core.Entities;
using MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

namespace MindQuote.Core.Mappers.Quotes;

public static class QuoteMapper
{
    public static Quote ToEntity(this QuoteDTO dto)
    {
        return new Quote
        {
            Id = dto.Id,
            Content = dto.Content,
            AuthorFirstName = dto.AuthorFirstName,
            AuthorLastName = dto.AuthorLastName,
            Origin = dto.Origin,
        };
    }

    public static QuoteDTO ToDTO(this Quote entity)
    {
        return new QuoteDTO
        {
            Id = entity.Id,
            Content = entity.Content,
            AuthorFirstName = entity.AuthorFirstName,
            AuthorLastName = entity.AuthorLastName,
            Origin = entity.Origin,
        };
    }
}