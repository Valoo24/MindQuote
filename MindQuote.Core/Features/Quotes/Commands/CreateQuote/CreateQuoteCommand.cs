using MediatR;

namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommand : IRequest<CreateQuoteCommandResponse>
{
    public string Content { get; set; }
    public string AuthorFirstName { get; set; }
    public string AuthorLastName { get; set; }
    public string? Origin { get; set; }
}