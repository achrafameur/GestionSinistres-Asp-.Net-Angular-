using MediatR;

namespace Insurise.Application.Features.Production.Durations.Commands.DeleteDuration;

public class DeleteDurationCommand : IRequest
{
    public DeleteDurationCommand(int id)
    {
        DurationId = id;
    }

    public int DurationId { get; set; }
}