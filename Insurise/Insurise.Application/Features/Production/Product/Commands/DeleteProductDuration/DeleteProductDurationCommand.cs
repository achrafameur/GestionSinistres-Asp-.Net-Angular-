using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductDuration;

public class DeleteProductDurationCommand : IRequest
{
    public DeleteProductDurationCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
