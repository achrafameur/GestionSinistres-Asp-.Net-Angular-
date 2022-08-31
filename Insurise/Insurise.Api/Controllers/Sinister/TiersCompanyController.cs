using Insurise.Application.Features.Sinister.TiersCompanies.Commands.AddTiersCompany;
using Insurise.Application.Features.Sinister.TiersCompanies.Commands.DeleteTiersCompany;
using Insurise.Application.Features.Sinister.TiersCompanies.Commands.UpdateTiersCompany;
using Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompaniesList;
using Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompanyDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Sinister;

[Route("api/[controller]")]
[ApiController]
public class TiersCompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public TiersCompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("all")]
    public async Task<ActionResult<List<TiersCompanyDto>>> GetAll()
    {
        var tiers = await _mediator.Send(new GetTiersCompaniesListQuery());
        return Ok(tiers);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<List<TiersCompanyDto>>> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetTiersCompanyDetailQuery(id)));
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateTiersCompanyCommand createTiersCompanyCommand)
    {
        var response = await _mediator.Send(createTiersCompanyCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateTiersCompanyCommand>> Update(
        [FromBody] UpdateTiersCompanyCommand updateTiersCompanyCommand)
    {
        await _mediator.Send(updateTiersCompanyCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTiersCompanyCommand(id));
        return NoContent();
    }
}