using Insurise.Application.Features.Sinister.SinisterBinders.Commands.AddSinisterBinder;
using Insurise.Application.Features.Sinister.SinisterBinders.Commands.DeleteSinisterBinder;
using Insurise.Application.Features.Sinister.SinisterBinders.Commands.UpdateSinisterBinder;
using Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBinderDetail;
using Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBindersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Sinister
{

    [Route("api/[controller]")]
    [ApiController]
    public class SinisterBinderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SinisterBinderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<SinisterBinderDto>>> GetAll()
        {
            var dtos = await _mediator.Send(new GetSinisterBindersListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<List<SinisterBinderDto>>> GetById(int id)
        {
            var ExpertDetail = new GetSinisterBinderDetailQuery(id);
            return Ok(await _mediator.Send(ExpertDetail));
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] AddSinisterBinderCommand createSinisterBinderCommand)
        {
            var response = await _mediator.Send(createSinisterBinderCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<UpdateSinisterBinderCommand>> Update([FromBody] UpdateSinisterBinderCommand updateSinisterBinderCommand)
        {
            await _mediator.Send(updateSinisterBinderCommand);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var SinisterBinderToDelete = new DeleteSinisterBinderCommand(id);
            await _mediator.Send(SinisterBinderToDelete);
            return NoContent();
        }
    }
}
