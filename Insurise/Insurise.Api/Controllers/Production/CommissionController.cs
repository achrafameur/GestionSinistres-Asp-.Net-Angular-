using Insurise.Application.Features.Common.Commissions.Commands.AddCommission;
using Insurise.Application.Features.Common.Commissions.Commands.DeleteCommission;
using Insurise.Application.Features.Common.Commissions.Commands.UpdateCommission;
using Insurise.Application.Features.Common.Commissions.Queries.GetCommissionDetail;
using Insurise.Application.Features.Common.Commissions.Queries.GetCommissionsList;
using InsuriseDTO.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Production
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CommissionDto>>> GetAllCommissions()
        {
            var result = await _mediator.Send(new GetCommissionsListQuery());
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<CommissionDto>>> GetCommissionById(int id)
        {
            var commissionDetail = new GetCommissionDetailQuery(id);
            return Ok(await _mediator.Send(commissionDetail));
        }
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddCommissionCommand addCommissionCommand)
        {
            var id = await _mediator.Send(addCommissionCommand);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCommissionCommand = new DeleteCommissionCommand(id);
            await _mediator.Send(deleteCommissionCommand);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCommissionCommand updateCommissionCommand)
        {
            await _mediator.Send(updateCommissionCommand);
            return NoContent();
        }
    }
}
