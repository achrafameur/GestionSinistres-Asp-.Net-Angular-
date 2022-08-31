using Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesList;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesDetails;

public class GetWarrantiesDetailsQuery : IRequest<WarrantyDto>
{
    public GetWarrantiesDetailsQuery(int warrantyId)
    {
        WarrantyId = warrantyId;
    }

    public int WarrantyId { get; }
}