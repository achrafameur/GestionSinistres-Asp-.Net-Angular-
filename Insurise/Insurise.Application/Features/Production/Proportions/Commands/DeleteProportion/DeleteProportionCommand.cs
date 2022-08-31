using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Commands.DeleteProportion;

public class DeleteProportionCommand : IRequest
{
    public DeleteProportionCommand(int proportionId)
    {
        ProportionId = proportionId;
    }

    public int ProportionId { get; }
}