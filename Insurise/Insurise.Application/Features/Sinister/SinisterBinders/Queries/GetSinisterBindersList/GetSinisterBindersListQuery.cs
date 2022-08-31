using Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBinderDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBindersList;

public class GetSinisterBindersListQuery : IRequest<List<SinisterBinderDto>>
{
}