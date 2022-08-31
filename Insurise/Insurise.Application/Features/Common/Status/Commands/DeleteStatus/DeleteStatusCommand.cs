using MediatR;

namespace Insurise.Application.Features.Common.Status.Commands.DeleteStatus;

public class DeleteStatusCommand : IRequest
{
    public DeleteStatusCommand(int statusId)
    {
        StatusId = statusId;
    }

    public int StatusId { get; }
}