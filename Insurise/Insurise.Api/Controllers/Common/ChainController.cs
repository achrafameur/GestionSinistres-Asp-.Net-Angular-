using Insurise.Application.Features.Common.Chains.Commands.CreateChain;
using Insurise.Application.Features.Common.Chains.Commands.DeleteChain;
using Insurise.Application.Features.Common.Chains.Commands.UpdateChain;
using Insurise.Application.Features.Common.Chains.Queries.GetChainDetail;
using Insurise.Application.Features.Common.Chains.Queries.GetChainList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class ChainController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChainController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<ChainDto>>> GetAllChain()
    {
        var result = await _mediator.Send(new GetChainListQuery());
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ChainDto>> GetChainById(int id)
    {
        return Ok(await _mediator.Send(new GetChainDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateChainCommand createChainCommand)
    {
        var id = await _mediator.Send(createChainCommand);
        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateChainCommand updateChainCommand)
    {
        await _mediator.Send(updateChainCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteChainCommand(id));
        return NoContent();
    }
}