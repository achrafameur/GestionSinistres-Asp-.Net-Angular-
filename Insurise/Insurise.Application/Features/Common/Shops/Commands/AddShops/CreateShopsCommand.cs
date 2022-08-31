using MediatR;

namespace Insurise.Application.Features.Common.Shops.Commands.AddShops;

public class CreateShopsCommand : IRequest<int>
{
    public CreateShopsCommand(string title, int type, string code, string description, int? departmentId)
    {
        Title = title;
        Type = type;
        Code = code;
        Description = description;
        DepartmentId = departmentId;
    }

    public string Title { get; set; }
    public int Type { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int? DepartmentId { get; set; }

    public override string ToString()
    {
        return
            $"Shops : Title = {Title} ; Description = {Description}; Code={Code} ; Type={Type} ;";
    }
}