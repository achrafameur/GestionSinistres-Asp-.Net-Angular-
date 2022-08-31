using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.SetFees;

public class SetFeesCommand : IRequest
{
    public int ProductId { get; set; }
    public ICollection<int>? ProductFees { get; set; }
}