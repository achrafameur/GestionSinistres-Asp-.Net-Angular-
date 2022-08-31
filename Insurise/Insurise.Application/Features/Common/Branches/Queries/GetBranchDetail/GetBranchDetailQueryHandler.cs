using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Branches.Queries.GetBranchDetail;

public class GetBranchDetailQueryHandler : IRequestHandler<GetBranchDetailQuery, BranchDto>
{
    private readonly IRepository<Branch> _branchRepository;
    private readonly IMapper _mapper;

    public GetBranchDetailQueryHandler(IMapper mapper, IRepository<Branch> branchRepository)
    {
        _mapper = mapper;
        _branchRepository = branchRepository;
    }

    public async Task<BranchDto> Handle(GetBranchDetailQuery request, CancellationToken cancellationToken)
    {
        var branch = await _branchRepository.GetByIdAsync(request.BranchId, cancellationToken);
        var returnedBranch = _mapper.Map<BranchDto>(branch);

        return returnedBranch;
    }
}