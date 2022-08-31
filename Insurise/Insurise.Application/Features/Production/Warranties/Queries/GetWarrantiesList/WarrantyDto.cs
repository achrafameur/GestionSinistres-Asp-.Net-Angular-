using Insurise.Core.Entities.Production.WarrantyAggregate;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesList;

public class WarrantyDto
{
    public WarrantyDto(int warrantyId, string title, string? symbol, string? description,
        DateTime startDate, DateTime endDate,
        int defaultPeriod, bool isCommercialRate, Warranty.payementType typeTarif)
    {
        WarrantyId = warrantyId;
        Title = title;
        Symbol = symbol;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        DefaultPeriod = defaultPeriod;
        IsCommercialRate = isCommercialRate;
        TypeTarif = typeTarif;
    }

    public int WarrantyId { get; }
    public string Title { get; }
    public string? Symbol { get; }
    public string? Description { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public int DefaultPeriod { get; }
    public bool IsCommercialRate { get; }
    public Warranty.payementType TypeTarif { get; }
}