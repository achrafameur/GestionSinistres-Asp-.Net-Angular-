using MediatR;

namespace Insurise.Application.Features.Common.Branches.Queries.GetBranchDetail;

public class GetBranchDetailQuery : IRequest<BranchDto>
{
    public GetBranchDetailQuery(int branchId)
    {
        BranchId = branchId;
    }

    public int BranchId { get; }
}