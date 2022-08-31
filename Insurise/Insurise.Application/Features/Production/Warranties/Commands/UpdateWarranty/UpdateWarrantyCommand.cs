using Insurise.Core.Entities.Production.WarrantyAggregate;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarranty;

public class UpdateWarrantyCommand : IRequest
{
    public UpdateWarrantyCommand()
    {
    }

    public UpdateWarrantyCommand(int warrantyId, string title, string? symbole, string? description,
        DateTime startDate, DateTime endDate,
        int defaultPeriod, bool isCommercialRate, Warranty.payementType typeTarif)
    {
        WarrantyId = warrantyId;
        Title = title;
        Symbol = symbole;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        DefaultPeriod = defaultPeriod;
        TypeTarif = typeTarif;
    }

    public int WarrantyId { get; set; }
    public string Title { get; set; }
    public string? Symbol { get; set; }
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DefaultPeriod { get; set; }
    public bool IsCommercialRate { get; set; }
    public Warranty.payementType TypeTarif { get; set; }
}