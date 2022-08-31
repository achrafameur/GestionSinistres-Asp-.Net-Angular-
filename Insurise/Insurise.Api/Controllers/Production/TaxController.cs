using Insurise.Application.Features.Production.Tax.Commands.AddTax;
using Insurise.Application.Features.Production.Tax.Commands.DeleteTax;
using Insurise.Application.Features.Production.Tax.Commands.UpdateTax;
using Insurise.Application.Features.Production.Tax.Queries.GetTaxDetail;
using Insurise.Application.Features.Production.Tax.Queries.GetTaxList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Production;

[Route("api/[controller]")]
[ApiController]
public class TaxController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaxController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<TaxDto>>> GetAllTaxes()
    {
        var taxes = await _mediator.Send(new GetTaxListQuery());
        return Ok(taxes);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<TaxDto>>> GetTaxById(int id)
    {
        var taxDetails = new GetTaxDetailQuery(id);
        return Ok(await _mediator.Send(taxDetails));
    }

    [HttpPost]
    public async Task<ActionResult> AddTax([FromBody] CreateTaxCommand createTaxCommand)
    {
        var response = await _mediator.Send(createTaxCommand);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTax(int id)
    {
        await _mediator.Send(new DeleteTaxCommand(id));
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult<UpdateTaxCommand>> UpdateTax([FromBody] UpdateTaxCommand updateTaxCommand)
    {
        var updatedTax = await _mediator.Send(updateTaxCommand);
        return Ok(updatedTax);
    }
}