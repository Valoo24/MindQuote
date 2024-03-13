using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindQuote.Core.Features.Quotes.Commands.CreateQuote;
using MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

namespace MindQuote.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuoteController : ControllerBase
{
    public IMediator _mediator { get; set; }
    public QuoteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuoteDTO>>> GetQuotes()
    {
        try
        {
            var result = await _mediator.Send(new GetQuotesListQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddQuote([FromBody] CreateQuoteCommand command)
    {
        try 
        { 
            return Ok(_mediator.Send(command));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}