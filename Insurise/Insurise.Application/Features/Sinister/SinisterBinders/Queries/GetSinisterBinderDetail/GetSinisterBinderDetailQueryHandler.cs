using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBinderDetail;

public class GetSinisterBinderDetailQueryHandler : IRequestHandler<GetSinisterBinderDetailQuery, SinisterBinderDto>
{
    private readonly IRepository<SinisterBinder> _SinisterBinderRepository;
    private readonly IMapper _mapper;

    public GetSinisterBinderDetailQueryHandler(IMapper mapper, IRepository<SinisterBinder> SinisterBinderRepository)
    {
        _mapper = mapper;
        _SinisterBinderRepository = SinisterBinderRepository;
    }

    public async Task<SinisterBinderDto> Handle(GetSinisterBinderDetailQuery request,
        CancellationToken cancellationToken)
    {
        var sinisterBinder = await _SinisterBinderRepository.GetByIdAsync(request.SinisterBinderId, cancellationToken);
        var returnedSinisterBinder = _mapper.Map<SinisterBinderDto>(sinisterBinder);

        return returnedSinisterBinder;
    }
}