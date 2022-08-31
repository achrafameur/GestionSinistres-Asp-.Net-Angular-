using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.DeleteExpert;

public class DeleteExpertCommand : IRequest
{
    public DeleteExpertCommand(int expertId)
    {
        ExpertId = expertId;
    }

    public int ExpertId { get; }
}