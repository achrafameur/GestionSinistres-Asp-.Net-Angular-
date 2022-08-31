using AutoMapper;
using Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBinderDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBindersList;

public class GetSinisterBindersListQueryHandler : IRequestHandler<GetSinisterBindersListQuery, List<SinisterBinderDto>>
{
    private readonly IRepository<SinisterBinder> _SinisterBinderRepository;
    private readonly IMapper _mapper;

    public GetSinisterBindersListQueryHandler(IMapper mapper, IRepository<SinisterBinder> SinisterBinderRepository)
    {
        _mapper = mapper;
        _SinisterBinderRepository = SinisterBinderRepository;
    }

    public async Task<List<SinisterBinderDto>> Handle(GetSinisterBindersListQuery request,
        CancellationToken cancellationToken)
    {
        var allSinisterBinders = await _SinisterBinderRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<SinisterBinderDto>>(allSinisterBinders);
    }
}