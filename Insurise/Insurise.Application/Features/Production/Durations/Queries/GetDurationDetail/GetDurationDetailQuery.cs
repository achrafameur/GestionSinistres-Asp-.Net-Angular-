using MediatR;

namespace Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;

public class GetDurationDetailQuery : IRequest<DurationDetailDto>
{
    public GetDurationDetailQuery(int id)
    {
        DurationId = id;
    }

    public int DurationId { get; set; }
}