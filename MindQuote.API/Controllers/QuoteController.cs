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
    public async Task<IActionResult> GetAllQuotes()
    {
            var result = await _mediator.Send(new GetQuotesListQuery());
            Log.Information("Getting all Quotes from Database.");
            return Ok(result.Content);
    }
    
    [HttpGet("id={id}")]
    public async Task<IActionResult> GetQuote(Guid id)
    {
            var query = new GetQuoteQuery { Id = id };
            var result = await _mediator.Send(query);
            Log.Information($"Get a quote with Query: {query}");
            return Ok(result.Content);
    }

    [HttpPost]
    public async Task<IActionResult> AddQuote([FromBody] CreateQuoteCommand command)
    {
            var result = await _mediator.Send(command);
            Log.Information($"Quote {result.Content} added succesfully !");
            return Ok(result.Content);
    }
}