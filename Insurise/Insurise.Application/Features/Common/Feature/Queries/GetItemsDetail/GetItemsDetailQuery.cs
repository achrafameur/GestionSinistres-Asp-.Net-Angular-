using InsuriseDTO.Production.Feature;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Queries.GetItemsDetail;

public class GetItemsDetailQuery : IRequest<List<FeatureItemDto>>
{
    public GetItemsDetailQuery(int id)
    {
        FeatureId = id;
    }

    public int FeatureId { get; set; }
}