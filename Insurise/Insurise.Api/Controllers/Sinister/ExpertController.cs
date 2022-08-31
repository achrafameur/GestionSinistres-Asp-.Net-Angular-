using Insurise.Application.Features.Sinister.Experts.Commands.AddExpert;
using Insurise.Application.Features.Sinister.Experts.Commands.DeleteExpert;
using Insurise.Application.Features.Sinister.Experts.Commands.SetNatures;
using Insurise.Application.Features.Sinister.Experts.Commands.SetSinisterNatures;
using Insurise.Application.Features.Sinister.Experts.Commands.SetSpecialities;
using Insurise.Application.Features.Sinister.Experts.Commands.UpdateExpert;
using Insurise.Application.Features.Sinister.Experts.Queries.GetExpertDetail;
using Insurise.Application.Features.Sinister.Experts.Queries.GetExpertList;
using Insurise.Application.Features.Sinister.Experts.Queries.GetExpertNatures;
using Insurise.Application.Features.Sinister.Experts.Queries.GetExpertSinisterNatures;
using Insurise.Application.Features.Sinister.Experts.Queries.GetExpertSpecialities;
using InsuriseDTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Sinister;

[Route("api/[controller]")]
[ApiController]
public class ExpertController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExpertController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("all")]
    public async Task<ActionResult<List<ExpertDto>>> GetAll()
    {
        var experts = await _mediator.Send(new GetExpertListQuery());
        return Ok(experts);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<ExpertDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetExpertDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateExpertCommand createExpertCommand)
    {
        var response = await _mediator.Send(createExpertCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateExpertCommand>> Update([FromBody] UpdateExpertCommand updateExpertCommand)
    {
        await _mediator.Send(updateExpertCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteExpertCommand(id));
        return NoContent();
    }

    [HttpPost]
    [Route("setSinisterNatures")]
    public async Task<ActionResult> SetSinisterNatures([FromBody] SetSinisterNaturesCommand sinisterNaturesCommand)
    {
        var response = await _mediator.Send(sinisterNaturesCommand);
        return Ok(response);
    }

    [HttpPost]
    [Route("setNatures")]
    public async Task<ActionResult> SetNatures([FromBody] SetNatureCommand setNatureCommand)
    {
        var response = await _mediator.Send(setNatureCommand);
        return Ok(response);
    }

    [HttpPost]
    [Route("setSpecialities")]
    public async Task<ActionResult> SetSpecialities([FromBody] SetSpecialitiesCommand setSpecialitiesCommand)
    {
        var response = await _mediator.Send(setSpecialitiesCommand);
        return Ok(response);
    }

    [HttpGet("getSinisterNatures/{id:int}")]
    public async Task<ActionResult<List<GetExpertSinisterNaturesDto>>> GetSinisterNatures(int id)
    {
        return Ok(await _mediator.Send(new GetExpertSinisterNaturesQuery(id)));
    }

    [HttpGet("getNatures/{id:int}")]
    public async Task<ActionResult<List<GetExpertNaturesDto>>> GetNatures(int id)
    {
        return Ok(await _mediator.Send(new GetExpertNaturesQuery(id)));
    }

    [HttpGet("getSpecialities/{id:int}")]
    public async Task<ActionResult<List<GetExpertSpecialityDto>>> GetSpecialities(int id)
    {
        return Ok(await _mediator.Send(new GetExpertSpecialitiesQuery(id)));
    }
}
