using Insurise.Application.Features.Common.Feature.Commands.SetItemsFeatures;
using Insurise.Application.Features.Common.Items.Commands.CreateItem;
using Insurise.Application.Features.Common.Items.Commands.DeleteItem;
using Insurise.Application.Features.Common.Items.Commands.UpdateItem;
using Insurise.Application.Features.Common.Items.Queries.GetFeaturesList;
using Insurise.Application.Features.Common.Items.Queries.GetItemDetail;
using Insurise.Application.Features.Common.Items.Queries.GetItemsList; 
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemDto>>> GetAllItems()
    {
        var result = await _mediator.Send(new GetItemsListQuery());
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemDto>> GetItemById(int id)
    {
        var getItemDetailQuery = new GetItemDetailQuery(id);
        return Ok(await _mediator.Send(getItemDetailQuery));
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateItemCommand createItemCommand)
    {
        var response = await _mediator.Send(createItemCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateItemCommand updateItemCommand)
    {
        await _mediator.Send(updateItemCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleteItemCommand = new DeleteItemCommand(id);
        await _mediator.Send(deleteItemCommand);
        return NoContent();
    }

    [HttpPost("setFeatures")]
    public async Task<ActionResult> SetFeatures([FromBody] SetFeaturesItemsCommand featuresCommand)
    {
        var response = await _mediator.Send(featuresCommand);
        return Ok(response);
    }

    [HttpGet("GetFeaturesByItemId/{id:int}")]
    public async Task<ActionResult> GetFeaturesByItemId(int id)
    {
        var dtos = await _mediator.Send(new GetFeaturesListQuery(id));
        return Ok(dtos);
    }
}
