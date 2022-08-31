using Insurise.Application.Features.Common.Branches.Commands.AddBranch;
using Insurise.Application.Features.Common.Branches.Commands.DeleteBranch;
using Insurise.Application.Features.Common.Branches.Commands.UpdateBranch;
using Insurise.Application.Features.Common.Branches.Queries.GetBranchDetail;
using Insurise.Application.Features.Common.Branches.Queries.GetBranchesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class BranchController : ControllerBase
{
    private readonly IMediator _mediator;

    public BranchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<BranchDto>>> GetAll()
    {
        var branches = await _mediator.Send(new GetBranchListQuery());
        return Ok(branches);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<BranchDto>>> GetById(int id)
    {
        var branchDetail = new GetBranchDetailQuery(id);
        return Ok(await _mediator.Send(branchDetail));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AddBranchCommand addBranchCommand)
    {
        var response = await _mediator.Send(addBranchCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateBranchCommand updateBranchCommand)
    {
        await _mediator.Send(updateBranchCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var branchToDelete = new DeleteBranchCommand(id);
        await _mediator.Send(branchToDelete);
        return NoContent();
    }
}