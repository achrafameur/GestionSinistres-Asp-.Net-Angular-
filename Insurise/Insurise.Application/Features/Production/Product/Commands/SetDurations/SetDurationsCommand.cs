using InsuriseDTO.Common; 
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.SetDurations;

public class SetDurationsCommand : IRequest
{
    public int? ProductDurationId { get; set; }
    public int ProductId { get; set; }
    public int DurationId { get; set; } 
    public bool Actif { get; set; } = true;
    public ICollection<ProductDurationProportionDto> Proportions { get; set; } 
}
