using Insurise.Application.Features.Sinister.Tiers.Commands.AddTiers;
using Insurise.Application.Features.Sinister.Tiers.Commands.DeleteTiers;
using Insurise.Application.Features.Sinister.Tiers.Commands.UpdateTiers;
using Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersDetail;
using Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Sinister;

[Route("api/[controller]")]
[ApiController]
public class TiersController : ControllerBase
{
    private readonly IMediator _mediator;

    public TiersController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("all")]
    public async Task<ActionResult<List<TiersDto>>> GetAll()
    {
        var tiers = await _mediator.Send(new GetTiersListQuery());
        return Ok(tiers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<TiersDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetTiersDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateTiersCommand createTiersCommand)
    {
        var response = await _mediator.Send(createTiersCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateTiersCommand>> Update([FromBody] UpdateTiersCommand updateTiersCommand)
    {
        await _mediator.Send(updateTiersCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTiersCommand(id));
        return NoContent();
    }
}