using MindQuote.Core.Abstracts;

namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandResponse : ICommandResponse<Guid>
{
    public Guid Content { get; set; }
}