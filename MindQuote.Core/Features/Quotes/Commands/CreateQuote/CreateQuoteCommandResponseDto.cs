namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandResponseDto
{
    public Guid QuoteId { get; set; }
    public Guid AuthorId { get; set; }
}