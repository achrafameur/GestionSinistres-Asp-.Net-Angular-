using Insurise.Application.Features.Sinister.AvgCosts.Commands.AddAvgCost;
using Insurise.Application.Features.Sinister.AvgCosts.Commands.DeleteAvgCost;
using Insurise.Application.Features.Sinister.AvgCosts.Commands.UpdateAvgCost;
using Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostDetail;
using Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Sinister;

[Route("api/[controller]")]
[ApiController]
public class SinisterNatureAverageCostController : ControllerBase
{
    private readonly IMediator _mediator;

    public SinisterNatureAverageCostController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("all")]
    public async Task<ActionResult<List<AvgCostDto>>> GetAll()
    {
        var averageCosts = await _mediator.Send(new GetAvgCostsListQuery());
        return Ok(averageCosts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<AvgCostDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetAvgCostDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateSinisterNatureAverageCostCommand createAvgCostCommand)
    {
        var response = await _mediator.Send(createAvgCostCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateSinisterNatureAverageCostCommand>> Update(
        [FromBody] UpdateSinisterNatureAverageCostCommand updateAvgCostCommand)
    {
        await _mediator.Send(updateAvgCostCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteAvgCostCommand(id));
        return NoContent();
    }
}
