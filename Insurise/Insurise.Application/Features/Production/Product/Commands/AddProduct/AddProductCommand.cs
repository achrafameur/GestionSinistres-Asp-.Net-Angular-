using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.AddProduct;

public class AddProductCommand : IRequest<int>
{
    public AddProductCommand(string title, string? description, DateTime? startDate, DateTime? expirationDate,
        double? defaultDiscount, int? branchId, string? code, int? certificateId, string? fileName, string? image)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        ExpirationDate = expirationDate;
        DefaultDiscount = defaultDiscount;
        BranchId = branchId;
        Code = code;
        CertificateId = certificateId;
        FileName = fileName;
        Image = image;
    }

    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Code { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public double? DefaultDiscount { get; set; }
    public int? BranchId { get; set; }
    public int? CertificateId { get; set; }

    public string? FileName { get; set; }
    public string? Image { get; set; }
}