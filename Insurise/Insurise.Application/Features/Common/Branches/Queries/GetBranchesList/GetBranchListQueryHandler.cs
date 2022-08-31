using AutoMapper;
using Insurise.Application.Features.Common.Branches.Queries.GetBranchDetail;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters.Commun.Branchs;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Branches.Queries.GetBranchesList;

public class GetBranchListQueryHandler : IRequestHandler<GetBranchListQuery, List<BranchDto>>
{
    private readonly IRepository<Branch> _branchRepository;
    private readonly IMapper _mapper;

    public GetBranchListQueryHandler(IMapper mapper, IRepository<Branch> branchRepository)
    {
        _mapper = mapper;
        _branchRepository = branchRepository;
    }

    public async Task<List<BranchDto>> Handle(GetBranchListQuery request, CancellationToken cancellationToken)
    {
        var filter = new BranchFilter
        {
            LoadChildren = true,
            Children = new List<string> {"BranchParent"},
            IsPagingEnabled = false
        };
        var spec = new BranchSpec(filter);
        var allBranches = await _branchRepository.ListAsync(spec, cancellationToken);
        return _mapper.Map<List<BranchDto>>(allBranches);
    }
}