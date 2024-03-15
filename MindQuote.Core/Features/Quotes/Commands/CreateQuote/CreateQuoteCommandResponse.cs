using MindQuote.Core.Abstracts;

namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandResponse : ICommandResponse<CreateQuoteCommandResponseDto>
{
    public CreateQuoteCommandResponseDto Content { get; set; } = new();
}