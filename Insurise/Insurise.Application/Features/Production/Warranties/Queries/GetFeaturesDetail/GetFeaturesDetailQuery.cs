using InsuriseDTO;
using InsuriseDTO.Production.Warranties;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetFeaturesDetail;

public class GetFeaturesDetailQuery : IRequest<List<WarrantyFeatureDto>>
{
    public GetFeaturesDetailQuery(int warrantyId)
    {
        WarrantyId = warrantyId;
    }

    public int WarrantyId { get; set; }
}