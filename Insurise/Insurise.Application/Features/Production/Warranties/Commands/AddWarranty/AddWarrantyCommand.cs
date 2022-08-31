using Insurise.Core.Entities.Production.WarrantyAggregate;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.AddWarranty;

public class AddWarrantyCommand : IRequest<int>
{
    public AddWarrantyCommand()
    {
    }

    public AddWarrantyCommand(string title, string? symbol, string? description,
        DateTime startDate, DateTime endDate,
        int defaultPeriod, bool isCommercialRate, Warranty.payementType typeTarif)
    {
        Title = title;
        Symbol = symbol;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        DefaultPeriod = defaultPeriod;
        IsCommercialRate = isCommercialRate;
        TypeTarif = typeTarif;
    }

    public string Title { get; set; }
    public string? Symbol { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DefaultPeriod { get; set; }
    public bool IsCommercialRate { get; set; }
    public Warranty.payementType TypeTarif { get; set; }
}