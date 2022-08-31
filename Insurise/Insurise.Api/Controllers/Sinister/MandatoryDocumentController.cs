using Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.AddMandatoryDocument;
using Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.DeleteMandatoryDocument;
using Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.UpdateMandatoryDocument;
using Insurise.Application.Features.Sinister.MandatoryDocuments.Queries.GetMandatoryDocumentList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insurise.Api.Controllers.Sinister;

[Route("api/[controller]")]
[ApiController]
public class MandatoryDocumentController : ControllerBase
{
    private readonly IMediator _mediator;

    public MandatoryDocumentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<MandatoryDocumentDto>>> GetAll()
    {
        var dtos = await _mediator.Send(new GetMandatoryDocumentListQuery());
        return Ok(dtos);
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateMandatoryDocumentCommand createMandatoryDocumentCommand)
    {
        var response = await _mediator.Send(createMandatoryDocumentCommand);
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdateMandatoryDocumentCommand>> Update(
        [FromBody] UpdateMandatoryDocumentCommand updateMandatoryDocumentCommand)
    {
        await _mediator.Send(updateMandatoryDocumentCommand);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var MandatoryDocumentToDelete = new DeleteMandatoryDocumentCommand(id);
        await _mediator.Send(MandatoryDocumentToDelete);
        return NoContent();
    }
}