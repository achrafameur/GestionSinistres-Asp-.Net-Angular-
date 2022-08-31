using MediatR;

namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Queries.GetMandatoryDocumentList;

public class GetMandatoryDocumentListQuery : IRequest<List<MandatoryDocumentDto>>
{
}