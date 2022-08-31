using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Branches.Commands.UpdateBranch;

public class UpdateBranchEventHandler : IRequestHandler<UpdateBranchCommand>
{
    private readonly IRepository<Branch> _branchRepository;
    private readonly IMapper _mapper;

    public UpdateBranchEventHandler(IMapper mapper, IRepository<Branch> branchRepository)
    {
        _mapper = mapper;
        _branchRepository = branchRepository;
    }

    public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        var branchToUpdate = await _branchRepository.GetByIdAsync(request.BranchId, cancellationToken);

        if (branchToUpdate == null) throw new BranchNotFoundException(request.BranchId);

        _mapper.Map(request, branchToUpdate, typeof(UpdateBranchCommand), typeof(Branch));

        await _branchRepository.UpdateAsync(branchToUpdate, cancellationToken);

        return Unit.Value;
    }
}