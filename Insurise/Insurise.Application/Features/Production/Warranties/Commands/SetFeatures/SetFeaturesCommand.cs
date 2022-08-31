using InsuriseDTO;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.SetFeatures;

public class SetFeaturesToWarrantyCommand : IRequest
{
    public int WarrantyId { get; set; }
    public ICollection<int>? WarrantyFeatures { get; set; }
}