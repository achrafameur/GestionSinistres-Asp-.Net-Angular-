using Insurise.Application.Features.Common.Status.Commands.AddStatus;
using Insurise.Application.Features.Common.Status.Commands.DeleteStatus;
using Insurise.Application.Features.Common.Status.Commands.UpdateStatus;
using Insurise.Application.Features.Common.Status.Queries.GetStatusDetail;
using Insurise.Application.Features.Common.Status.Queries.GetStatusList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class StatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatusController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("all")]
    public async Task<ActionResult<List<StatusDto>>> GetAll()
    {
        var status = await _mediator.Send(new GetStatusListQuery());
        return Ok(status);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<StatusDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetStatusDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateStatusCommand createStatusCommand)
    {
        var response = await _mediator.Send(createStatusCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateStatusCommand>> Update([FromBody] UpdateStatusCommand updateStatusCommand)
    {
        await _mediator.Send(updateStatusCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteStatusCommand(id));
        return NoContent();
    }
}