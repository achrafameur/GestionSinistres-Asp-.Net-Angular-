using Insurise.Application.Features.Production.Proportions.Commands.AddProportion;
using Insurise.Application.Features.Production.Proportions.Commands.DeleteProportion;
using Insurise.Application.Features.Production.Proportions.Commands.UpdateProportion;
using Insurise.Application.Features.Production.Proportions.Queries.GetProportionDetail;
using Insurise.Application.Features.Production.Proportions.Queries.GetProportionList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Production;

[Route("api/[controller]")]
[ApiController]
public class ProportionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProportionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<ProportionDto>>> GetAll()
    {
        var proportions = await _mediator.Send(new GetProportionListQuery());
        return Ok(proportions);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<ProportionDto>>> GetById(int id)
    {
        var proportionDetail = new GetProportionDetailQuery(id);
        return Ok(await _mediator.Send(proportionDetail));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AddProportionCommand addProportionCommand)
    {
        var response = await _mediator.Send(addProportionCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateProportionCommand updateProportionCommand)
    {
        await _mediator.Send(updateProportionCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteProportionCommand(id));
        return NoContent();
    }
}