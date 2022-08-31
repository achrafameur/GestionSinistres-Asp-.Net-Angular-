using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesList;

public class GetWarrantiesListQuery : IRequest<List<WarrantyDto>>
{
}