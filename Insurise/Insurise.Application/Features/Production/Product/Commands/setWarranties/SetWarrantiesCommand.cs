using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.setWarranties;

public class SetWarrantiesCommand : IRequest
{
    public int ProductId { get; set; }
    public ICollection<int>? ProductWarranties { get; set; }
}