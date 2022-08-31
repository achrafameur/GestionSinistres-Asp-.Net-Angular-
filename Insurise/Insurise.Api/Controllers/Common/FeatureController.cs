using Insurise.Application.Features.Common.Feature.Commands.Add;
using Insurise.Application.Features.Common.Feature.Commands.Delete;
using Insurise.Application.Features.Common.Feature.Commands.SetItemsFeatures;
using Insurise.Application.Features.Common.Feature.Commands.Update;
using Insurise.Application.Features.Common.Feature.Queries.GetDetail;
using Insurise.Application.Features.Common.Feature.Queries.GetItemsDetail;
using Insurise.Application.Features.Common.Feature.Queries.GetList; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class FeatureController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<FeatureController> _log;

    public FeatureController(IMediator mediator, ILogger<FeatureController> log)
    {
        _mediator = mediator;
        _log = log;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<FeatureDto>>> GetAll()
    {
        var features = await _mediator.Send(new GetFeatureListQuery());
        return Ok(features);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<FeatureDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetFeatureDetailQuery(id)));
    }

    [HttpPost]

    public async Task<ActionResult> Create([FromBody] AddFeatureCommand addFeatureCommand)
    {
        var response = await _mediator.Send(addFeatureCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateFeatureCommand>> Update([FromBody] UpdateFeatureCommand updateFeatureCommand)
    {
        await _mediator.Send(updateFeatureCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteFeatureCommand(id));
        return NoContent();
    }
    [HttpPost("setItems")]
    public async Task<ActionResult> SetItems([FromBody] SetFeaturesItemsCommand itemsCommand)
    {
        var response = await _mediator.Send(itemsCommand);
        return Ok(response);

    }

    [HttpGet("GetItemsByFeatureId/{id:int}")]
    public async Task<ActionResult> GetItemsByFeatureId(int id)
    {
        var features = await _mediator.Send(new GetItemsDetailQuery(id));
        return Ok(features);

    }
}
