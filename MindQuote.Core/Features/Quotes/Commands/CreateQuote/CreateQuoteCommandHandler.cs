using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers.Quotes;

namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, CreateQuoteCommandResponse>
{
    private IRepository<Quote> _repository;
    public CreateQuoteCommandHandler(IRepository<Quote> repository)
    {
        _repository = repository;
    }
    public async Task<CreateQuoteCommandResponse> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        CreateQuoteCommandResponse response = new();
        response.Content = await _repository.CreateAsync(request.ToEntity());
        return response;
    }
}