using InsuriseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertSinisterNatures;

public class GetExpertSinisterNaturesQuery : IRequest<List<GetExpertSinisterNaturesDto>>
{
    public GetExpertSinisterNaturesQuery(int expertId)
    {
        ExpertId = expertId;
    }

    public int ExpertId { get; }
}