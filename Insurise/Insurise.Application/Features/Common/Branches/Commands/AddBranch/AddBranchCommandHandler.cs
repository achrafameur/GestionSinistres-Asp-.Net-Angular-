using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Branches.Commands.AddBranch;

public class AddBranchCommandHandler : IRequestHandler<AddBranchCommand, int>
{
    private readonly IRepository<Branch> _branchRepository;
    private readonly IMapper _mapper;

    public AddBranchCommandHandler(IMapper mapper, IRepository<Branch> branchRepository)
    {
        _mapper = mapper;
        _branchRepository = branchRepository;
    }

    public async Task<int> Handle(AddBranchCommand request, CancellationToken cancellationToken)
    {
        var branch = _mapper.Map<Branch>(request);
        branch = await _branchRepository.AddAsync(branch, cancellationToken);

        return branch.Id;
    }
}