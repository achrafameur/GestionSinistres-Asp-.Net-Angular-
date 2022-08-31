using Insurise.Application.Features.Common.Natures.Commands.CreateNature;
using Insurise.Application.Features.Common.Natures.Commands.DeleteNature;
using Insurise.Application.Features.Common.Natures.Commands.UpdateNature;
using Insurise.Application.Features.Common.Natures.Queries.GetNatureDetail;
using Insurise.Application.Features.Common.Natures.Queries.GetNaturesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class NatureController : ControllerBase
{
    private readonly IMediator _mediator;

    public NatureController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<NatureDto>>> GetAllNatures()
    {
        var result = await _mediator.Send(new GetNaturesListQuery());
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<NatureDto>>> GetNatureById(int id)
    {
        return Ok(await _mediator.Send(new GetNatureDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateNatureCommand createNatureCommand)
    {
        var id = await _mediator.Send(createNatureCommand);
        return Ok(id);
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateNatureCommand updateNatureCommand)
    {
        await _mediator.Send(updateNatureCommand);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteNatureCommand(id));
        return NoContent();
    }
}