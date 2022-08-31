using Insurise.Application.Features.Common.Shops.Commands.AddShops;
using Insurise.Application.Features.Common.Shops.Commands.DeleteShops;
using Insurise.Application.Features.Common.Shops.Commands.UpdateShops;
using Insurise.Application.Features.Common.Shops.Queries.GetShopsDetail;
using Insurise.Application.Features.Common.Shops.Queries.GetShopsList;
using InsuriseDTO.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Common;

[Route("api/[controller]")]
[ApiController]
public class ShopController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShopController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<ShopDto>>> GetAll()
    {
        var shops = await _mediator.Send(new GetShopsListQuery());
        return Ok(shops);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<ShopDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetShopsDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateShopsCommand createShopsCommand)
    {
        var response = await _mediator.Send(createShopsCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateShopsCommand>> Update([FromBody] UpdateShopsCommand updateShopsCommand)
    {
        await _mediator.Send(updateShopsCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteShopsCommand(id));
        return NoContent();
    }
}
