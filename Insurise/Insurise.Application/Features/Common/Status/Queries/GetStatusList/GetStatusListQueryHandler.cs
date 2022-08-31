using AutoMapper;
using Insurise.Application.Features.Common.Status.Queries.GetStatusDetail;
using Insurise.Core.Specifications.Filters.Commun.Status;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Status.Queries.GetStatusList;

public class GetStatusListQueryHandler : IRequestHandler<GetStatusListQuery, List<StatusDto>>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Status> _statusRepository;
    private readonly IMapper _mapper;

    public GetStatusListQueryHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Status> statusRepository)
    {
        _mapper = mapper;
        _statusRepository = statusRepository;
    }

    public async Task<List<StatusDto>> Handle(GetStatusListQuery request, CancellationToken cancellationToken)
    {
        var filter = new StatusFilter
        {
            LoadChildren = true,
            Children = new List<string> { "Item" },
            IsPagingEnabled = false
        };
        var spec = new StatusSpec(filter);
        var allStatus = await _statusRepository.ListAsync(spec, cancellationToken);
        return _mapper.Map<List<StatusDto>>(allStatus);
    }
}