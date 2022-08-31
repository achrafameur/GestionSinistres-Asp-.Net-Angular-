using AutoMapper;
using Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters.Commun.Duration;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Durations.Queries.GetExceptDurationByProductIdList;

public class GetExceptDurationByProductIdListQueryHandler : IRequestHandler<GetExceptDurationByProductIdListQuery, List<DurationDetailDto>>
{ 
    private readonly IRepository<Duration> _durationsRepository;
    private readonly IMapper _mapper;

    public GetExceptDurationByProductIdListQueryHandler(IMapper mapper , IRepository<Duration> durationsRepository)
    {
        _mapper = mapper;
        _durationsRepository =  durationsRepository;
    }

    public async Task<List<DurationDetailDto>?> Handle(GetExceptDurationByProductIdListQuery request, CancellationToken cancellationToken)
    {
        if (request.ProductId.HasValue)
        { 
            var filter = new DurationFilter();
            filter.LoadChildren = true;
            //filter.ProductId = request.ProductId.Value;
            filter.Children = new List<string> { "ProductDurations" };
            var spec = new DurationSpec(filter);
            var durations = await _durationsRepository.ListAsync(spec, cancellationToken);
            var lstdurations = new List<Duration>();
            foreach (Duration? duration in durations)
            {
                if (!duration.ProductDurations.Any(x => x.ProductId == request.ProductId))
                    lstdurations.Add(duration); 
                if(duration.ProductDurations.FirstOrDefault(x => x.ProductId == request.ProductId.Value && x.IsDeleted)!=null)
                    lstdurations.Add(duration);
            } 
            var alldurations = _mapper.Map<List<DurationDetailDto>>(lstdurations.OrderBy(x=>x.Title));  
            return alldurations;
        }
        return null;
    }
}
