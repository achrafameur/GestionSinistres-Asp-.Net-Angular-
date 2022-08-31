using Insurise.Application.Features.Production.Warranties.Commands.AddWarranty;
using Insurise.Application.Features.Production.Warranties.Commands.DeleteWarranty;
using Insurise.Application.Features.Production.Warranties.Commands.DeleteWarrantyCommission;
using Insurise.Application.Features.Production.Warranties.Commands.DeleteWarrantyFeature;
using Insurise.Application.Features.Production.Warranties.Commands.SetCommissions;
using Insurise.Application.Features.Production.Warranties.Commands.SetFeatures;
using Insurise.Application.Features.Production.Warranties.Commands.SetTaxes;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarranty;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyCommission;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyFeature;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyTax;
using Insurise.Application.Features.Production.Warranties.Queries.GetCommissionsDetail;
using Insurise.Application.Features.Production.Warranties.Queries.GetFeaturesDetail;
using Insurise.Application.Features.Production.Warranties.Queries.GetProductsDetail;
using Insurise.Application.Features.Production.Warranties.Queries.GetTaxesDetail;
using Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesDetails;
using Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Production;

[Route("api/[controller]")]
[ApiController]
public class WarrantyController : ControllerBase
{
    private const string EntityName = "warranty";
    private readonly ILogger<WarrantyController> _log;
    private readonly IMediator _mediator;

    public WarrantyController(ILogger<WarrantyController> log, IMediator mediator)
    {
        _mediator = mediator;
        _log = log;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<WarrantyDto>>> GetAll()
    {
        var warranties = await _mediator.Send(new GetWarrantiesListQuery());
        return Ok(warranties);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<WarrantyDto>>> GetNatureById(int id)
    {
        var warrantyDetail = new GetWarrantiesDetailsQuery(id);
        return Ok(await _mediator.Send(warrantyDetail));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] AddWarrantyCommand addWarrantyCommand)
    {
        _log.LogDebug("REST request to save {}", EntityName);
        var response = await _mediator.Send(addWarrantyCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateWarrantyCommand updateWarrantyCommand)
    {
        await _mediator.Send(updateWarrantyCommand);
        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var warrantyToDelete = new DeleteWarrantyCommand(id);
        await _mediator.Send(warrantyToDelete);
        return NoContent();
    }

    [HttpPost("setFeatures")]
    public async Task<ActionResult> SetFeatures([FromBody] SetFeaturesToWarrantyCommand featuresCommand)
    {
        var response = await _mediator.Send(featuresCommand);
        return Ok(response);
    }

    [HttpPut("UpdateWarrantyFeature")]
    public async Task<ActionResult> UpdateWarrantyFeature(
        [FromBody] UpdateWarrantyFeatureCommand updateWarrantyFeatureCommand)
    {
        await _mediator.Send(updateWarrantyFeatureCommand);
        return Ok();
    }

    [HttpPost("setCommissions")]
    public async Task<ActionResult> SetCommissions([FromBody] SetCommissionsCommand commissionsCommand)
    {
        var response = await _mediator.Send(commissionsCommand);
        return Ok(response);
    }

    [HttpPost("setTaxes")]
    public async Task<ActionResult> SetTaxes([FromBody] SetTaxesCommand taxesCommand)
    {
        var response = await _mediator.Send(taxesCommand);
        return Ok(response);
    }

    [HttpGet("GetFeaturesByWarrantyId/{id:int}")]
    public async Task<ActionResult> GetFeaturesByWarrantyId(int id)
    {
        var features = await _mediator.Send(new GetFeaturesDetailQuery(id));
        return Ok(features);
    }


    [HttpGet("GetTaxesByWarrantyId/{id:int}")]
    public async Task<ActionResult> GetTaxesByWarrantyId(int id)
    {
        var taxes = await _mediator.Send(new GetTaxesDetailQuery(id));
        return Ok(taxes);
    }

    [HttpGet("GetCommissionsByWarrantyId/{id:int}")]
    public async Task<ActionResult> GetCommissionsByWarrantyId(int id)
    {
        var commissions = await _mediator.Send(new GetCommissionsDetailQuery(id));
        return Ok(commissions);
    }

    [HttpDelete]
    [Route("DeleteWarrantyFeatureById/{id:int}")]
    public async Task<ActionResult> DeleteWarrantyFeature(int id)
    {
        await _mediator.Send(new DeleteWarrantyFeatureCommand(id));
        return NoContent();
    }

    [HttpPut]
    [Route("UpdateWarrantyTax")]
    public async Task<ActionResult> UpdateWarrantyTax([FromBody] UpdateWarrantyTaxCommand updateWarrantyTaxCommand)
    {
        await _mediator.Send(updateWarrantyTaxCommand);
        return Ok();
    }

    [HttpPut("UpdateWarrantyCommission")]
    public async Task<ActionResult> UpdateWarrantyCommission(
        [FromBody] UpdateWarrantyCommissionCommand updateWarrantyCommissionCommand)
    {
        await _mediator.Send(updateWarrantyCommissionCommand);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteWarrantyCommissionById/{id:int}")]
    public async Task<ActionResult> DeleteWarrantyCommission(int id)
    {
        await _mediator.Send(new DeleteWarrantyCommissionCommand(id));
        return NoContent();
    }

    [HttpGet]
    [Route("GetProductsByWarrantyId/{id:int}")]
    public async Task<ActionResult> GetProductsByWarrantyId(int id)
    {
        var dtos = await _mediator.Send(new GetProductsDetailQuery(id));
        return Ok(dtos);
    }
}