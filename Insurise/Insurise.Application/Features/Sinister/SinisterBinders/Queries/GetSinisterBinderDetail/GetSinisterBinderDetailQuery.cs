using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBinderDetail;

public class GetSinisterBinderDetailQuery : IRequest<SinisterBinderDto>
{
    public GetSinisterBinderDetailQuery(int sinisterBinderId)
    {
        SinisterBinderId = sinisterBinderId;
    }

    public int SinisterBinderId { get; }
}