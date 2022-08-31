using Insurise.Application.Features.Sinister.SinisterNatures.Commands.AddSinisterNature;
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.DeleteSinisterNature; 
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetMandatoryDocuments;
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetSinisterNaturesFeatures;
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetSpecialities;
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.UpdateSinisterNature;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureDetail;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureFeatures;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureMandatoryDocuments;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNaturesList;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureSpecialities; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Sinister;

[Route("api/[controller]")]
[ApiController]
public class SinisterNatureController : ControllerBase
{
    private readonly IMediator _mediator;

    public SinisterNatureController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<SinisterNatureDto>>> GetAll()
    {
        var sinisterNatures = await _mediator.Send(new GetSinisterNaturesListQuery());
        return Ok(sinisterNatures);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<SinisterNatureDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetSinisterNatureDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateSinisterNatureCommand createSinisterNatureCommand)
    {
        var response = await _mediator.Send(createSinisterNatureCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateSinisterNatureCommand>> Update(
        [FromBody] UpdateSinisterNatureCommand updateSinisterNatureCommand)
    {
        await _mediator.Send(updateSinisterNatureCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteSinisterNatureCommand(id));
        return NoContent();
    }

    [HttpPost]
    [Route("setMandatoryDocuments")]
    public async Task<ActionResult> SetMandatoryDocuments([FromBody] SetMandatoryDocumentsCommand mandatoryDocumentsCommand)
    {
        var response = await _mediator.Send(mandatoryDocumentsCommand);
        return Ok(response);
    }

    [HttpPost]
    [Route("setSpecialities")]
    public async Task<ActionResult> SetSpecialities([FromBody] SetSinisterNatureSpecialitiesCommand sinisterNatureSpecialitiesCommand)
    {
        var response = await _mediator.Send(sinisterNatureSpecialitiesCommand);
        return Ok(response);
    }

        [HttpPost]
        [Route("setSinisterNatureFeatures")]
        public async Task<ActionResult> SetFeatures([FromBody] SetSinisterNaturesFeaturesCommand FeaturesCommand)
        { 
            var response = await _mediator.Send(FeaturesCommand);
            return Ok(response);

        }

    [HttpGet("getSpecialities/{id:int}")]
    public async Task<ActionResult<List<GetSinisterNatureSpecialitiesDto>>> GetSpecialities(int id)
    {
        return Ok(await _mediator.Send(new GetSinisterNatureSpecialitiesQuery(id)));
    }

    [HttpGet("getFeatures/{id:int}")]
    public async Task<ActionResult<List<GetSinisterNatureFeaturesDto>>> GetFeatures(int id)
    {
        return Ok(await _mediator.Send(new GetSinisterNatureFeaturesQuery(id)));
    }

    [HttpGet("getMandatoryDocuments/{id:int}")]
    public async Task<ActionResult<List<GetSinisterNatureMandatoryDocumentsDto>>> GetMandatoryDocuments(int id)
    {
        return Ok(await _mediator.Send(new GetSinisterNatureMandatoryDocumentsQuery(id)));
    }
}
