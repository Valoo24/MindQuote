using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindQuote.Core.Features.Quotes.Queries.GetQuotesList;

namespace MindQuote.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuotesController : ControllerBase
{
    public IMediator _mediator { get; set; }
    public QuotesController(IMediator mediator)
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
}