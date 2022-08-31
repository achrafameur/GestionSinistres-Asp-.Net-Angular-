using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.UpdateProduct;

public class UpdateProductCommand : IRequest
{
    public UpdateProductCommand(int productId, string title, string? description, string? code, DateTime? startDate,
        DateTime? expirationDate, double? defaultDiscount, int? branchId, int? certificateId, string? fileName,
        string? image)
    {
        ProductId = productId;
        Title = title;
        Description = description;
        Code = code;
        StartDate = startDate;
        ExpirationDate = expirationDate;
        DefaultDiscount = defaultDiscount;
        BranchId = branchId;
        CertificateId = certificateId;
        FileName = fileName;
        Image = image;
    }

    public int ProductId { get; set; }
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