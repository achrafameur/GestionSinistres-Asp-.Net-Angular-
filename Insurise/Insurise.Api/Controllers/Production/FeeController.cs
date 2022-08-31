using Insurise.Application.Features.Production.Fees.Commands.AddFees;
using Insurise.Application.Features.Production.Fees.Commands.DeleteFees;
using Insurise.Application.Features.Production.Fees.Commands.UpdateFees;
using Insurise.Application.Features.Production.Fees.Queries.GetFeesDetail;
using Insurise.Application.Features.Production.Fees.Queries.GetFeesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Production;

[Route("api/[controller]")]
[ApiController]
public class FeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<FeesDto>>> GetAll()
    {
        var fees = await _mediator.Send(new GetFeesListQuery());
        return Ok(fees);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<FeesDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetFeesDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateFeesCommand createFeesCommand)
    {
        var response = await _mediator.Send(createFeesCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateFeesCommand>> Update([FromBody] UpdateFeesCommand updateFeesCommand)
    {
        await _mediator.Send(updateFeesCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteFeesCommand(id));
        return NoContent();
    }
}