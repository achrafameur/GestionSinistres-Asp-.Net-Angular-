using MediatR;

namespace Insurise.Application.Features.Production.Fees.Commands.DeleteFees;

public class DeleteFeesCommand : IRequest
{
    public DeleteFeesCommand(int id)
    {
        feesId = id;
    }

    public int feesId { get; }
}