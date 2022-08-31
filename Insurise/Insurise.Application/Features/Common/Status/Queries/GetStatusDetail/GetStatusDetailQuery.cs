using MediatR;

namespace Insurise.Application.Features.Common.Status.Queries.GetStatusDetail;

public class GetStatusDetailQuery : IRequest<StatusDto>
{
    public GetStatusDetailQuery(int statusId)
    {
        StatusId = statusId;
    }

    public int StatusId { get; }
}