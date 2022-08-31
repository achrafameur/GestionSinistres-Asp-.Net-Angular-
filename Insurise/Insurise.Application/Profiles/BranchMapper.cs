using AutoMapper;
using Insurise.Application.Features.Common.Branches.Commands.AddBranch;
using Insurise.Application.Features.Common.Branches.Commands.UpdateBranch;
using Insurise.Application.Features.Common.Branches.Queries.GetBranchDetail;
using Insurise.Core.Entities.Common;

namespace Insurise.Application.Profiles;

public class BranchMapper : Profile
{
    public BranchMapper()
    {
        CreateMap<AddBranchCommand, Branch>();
        CreateMap<UpdateBranchCommand, Branch>();

        CreateMap<BranchDto, Branch>();
        CreateMap<Branch, BranchDto>()
            .ConstructUsing(s => new BranchDto(s.Id, s.Title, s.Description, s.ParentId,
                s.BranchParent != null ? s.BranchParent.Title : ""))
            .ForMember(dto => dto.BranchParent,
                opt => opt.MapFrom(s => s.BranchParent != null ? s.BranchParent.Title : ""));
    }
}