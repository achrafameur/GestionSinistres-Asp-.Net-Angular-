using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.SetShops;

public class SetShopsCommand : IRequest
{
    public int ProductId { get; set; }
    public ICollection<ProductShopDto>? ProductShops { get; set; }
}