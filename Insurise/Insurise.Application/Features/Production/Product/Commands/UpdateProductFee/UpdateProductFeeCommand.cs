using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.UpdateProductFee;

public class UpdateProductFeeCommand : IRequest
{
    public UpdateProductFeeCommand(int id,  int rank)
    {
        Id = id; 
        Rank = rank;
    }
    public int Id { get; set; } 
    public int Rank { get; set; }
}

