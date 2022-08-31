using Insurise.Application.Features.Production.Durations.Commands.AddDuration;
using Insurise.Application.Features.Production.Durations.Commands.DeleteDuration;
using Insurise.Application.Features.Production.Durations.Commands.UpdateDuration;
using Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;
using Insurise.Application.Features.Production.Durations.Queries.GetDurationsList;
using Insurise.Application.Features.Production.Durations.Queries.GetExceptDurationByProductIdList; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Production;

[Route("api/[controller]")]
[ApiController]
public class DurationController : ControllerBase
{
    private readonly IMediator _mediator;

    public DurationController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("all")]
    public async Task<ActionResult<List<DurationDetailDto>>> GetAllDurations()
    {
        var durations = await _mediator.Send(new GetDurationListQuery());
        return Ok(durations);
    }

    [HttpGet]
    [Route("GetExceptDurationByProductId/{id:int}")]
    public async Task<ActionResult> GetExceptDurationByProductId(int? id)
    {
        var durations = await _mediator.Send(new GetExceptDurationByProductIdListQuery(id));
        return Ok(durations);
    }


    [HttpGet("{id::int}")]
    public async Task<ActionResult<List<DurationDetailDto>>> GetDurationById(int id)
    {
        return Ok(await _mediator.Send(new GetDurationDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> AddDuration([FromBody] CreateDurationCommand createDurationCommand)
    {
        var response = await _mediator.Send(createDurationCommand);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<ActionResult<UpdateDurationCommand>> UpdateDuration([FromBody] UpdateDurationCommand updateDurationCommand)
    {
        await _mediator.Send(updateDurationCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteDuration(int id)
    {
        await _mediator.Send(new DeleteDurationCommand(id));
        return NoContent();
    }
}
