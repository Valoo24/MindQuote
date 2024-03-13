using MediatR;
using MindQuote.Core.Abstracts;
using MindQuote.Core.Entities;
using MindQuote.Core.Mappers.Quotes;

namespace MindQuote.Core.Features.Quotes.Commands.CreateQuote;

public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommand, Guid>
{
    private IRepository<Quote> _repository;
    public CreateQuoteCommandHandler(IRepository<Quote> repository)
    {
        _repository = repository;
    }
    public async Task<Guid> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(request.ToEntity());
    }
}