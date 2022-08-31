using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Commands.AddTiers;

public class CreateTiersCommand : IRequest<int>
{
    public CreateTiersCommand(string title, string label, string description, string taxRegistrationNumber, long phone,
        long fax, string email, int tiersCompanyId)
    {
        Title = title;
        Label = label;
        Description = description;
        TaxRegistrationNumber = taxRegistrationNumber;
        Phone = phone;
        Fax = fax;
        Email = email;
        CreationDate = DateTime.Now;
        TiersCompanyId = tiersCompanyId;
    }

    public string Title { get; set; }
    public string Label { get; set; }
    public string Description { get; set; }
    public string TaxRegistrationNumber { get; set; }
    public long Phone { get; set; }
    public long Fax { get; set; }
    public DateTime CreationDate { get; set; }
    public string Email { get; set; }
    public int TiersCompanyId { get; set; }
}