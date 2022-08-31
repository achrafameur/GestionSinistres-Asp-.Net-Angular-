using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureMandatoryDocuments;

public class GetSinisterNatureMandatoryDocumentsQuery : IRequest<List<GetSinisterNatureMandatoryDocumentsDto>>
{
    public GetSinisterNatureMandatoryDocumentsQuery(int sinisterNatureId)
    {
        SinisterNatureId = sinisterNatureId;
    }

    public int SinisterNatureId { get; }
}