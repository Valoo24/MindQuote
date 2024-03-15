using MediatR;
using Microsoft.AspNetCore.Mvc;
using MindQuote.Core.Features.Quotes.Commands.CreateQuote;
using MindQuote.Core.Features.Quotes.Queries.GetQuote;
using MindQuote.Core.Features.Quotes.Queries.GetQuotesList;
using Serilog;

namespace MindQuote.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuoteController : Controller
{
    public IMediator _mediator { get; set; }
    public QuoteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<QuoteDTO>>> GetAllQuotes()
    {
        try
        {
            var result = await _mediator.Send(new GetQuotesListQuery());
            Log.Information("Getting all Quotes from Database.");
            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Warning(ex.Message);
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("id={id}")]
    public async Task<ActionResult<QuoteDTO>> GetQuote(Guid id)
    {
        try
        {
            var query = new GetQuoteQuery { Id = id };
            var result = await _mediator.Send(query);
            Log.Information($"Get a quote with Query: {query}");
            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Warning(ex.Message);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> AddQuote([FromBody] CreateQuoteCommand command)
    {
        try
        {
            var result = _mediator.Send(command);
            Log.Information($"Quote {result.Result} added succesfully !");
            return Ok(result);
        }
        catch (Exception ex)
        {
            Log.Warning(ex.Message);
            return BadRequest(ex.Message);
        }
    }
}