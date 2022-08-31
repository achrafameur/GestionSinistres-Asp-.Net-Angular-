using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureDetail;

public class GetSinisterNatureDetailQuery : IRequest<SinisterNatureDto>
{
    public GetSinisterNatureDetailQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}