using Insurise.Application.Features.Common.Branches.Queries.GetBranchDetail;
using MediatR;

namespace Insurise.Application.Features.Common.Branches.Queries.GetBranchesList;

public class GetBranchListQuery : IRequest<List<BranchDto>>
{
}