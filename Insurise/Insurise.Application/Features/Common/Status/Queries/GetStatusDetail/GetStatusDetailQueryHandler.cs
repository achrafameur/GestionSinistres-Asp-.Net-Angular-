using AutoMapper;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Status.Queries.GetStatusDetail;

public class GetStatusDetailQueryHandler : IRequestHandler<GetStatusDetailQuery, StatusDto>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Status> _statusRepository;
    private readonly IMapper _mapper;

    public GetStatusDetailQueryHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Status> statusRepository)
    {
        _mapper = mapper;
        _statusRepository = statusRepository;
    }

    public async Task<StatusDto> Handle(GetStatusDetailQuery request, CancellationToken cancellationToken)
    {
        var status = await _statusRepository.GetByIdAsync(request.StatusId, cancellationToken);
        var returnedStatus = _mapper.Map<StatusDto>(status);

        return returnedStatus;

    }
}