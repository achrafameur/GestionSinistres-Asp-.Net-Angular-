namespace Insurise.Application.Features.Production.Tax.Queries.GetTaxList;

public class TaxDto
{
    public TaxDto(int taxId, string title, string description, double coefficient, double constant)
    {
        TaxId = taxId;
        Title = title;
        Description = description;
        Coefficient = coefficient;
        Constant = constant;
    }

    public int TaxId { get; }
    public string Title { get; }
    public string Description { get; set; }
    public double Coefficient { get; }
    public double Constant { get; }
}