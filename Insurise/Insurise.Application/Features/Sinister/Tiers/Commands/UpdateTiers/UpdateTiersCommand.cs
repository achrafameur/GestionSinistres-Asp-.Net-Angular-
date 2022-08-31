using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Commands.UpdateTiers;

public class UpdateTiersCommand : IRequest
{
    public UpdateTiersCommand()
    {
            
    }
    public UpdateTiersCommand(int tiersId, string title, string label, string description, string taxRegistrationNumber,
        long phone, long fax, string email, int tiersCompanyId)
    {
        TiersId = tiersId;
        Title = title;
        Label = label;
        Description = description;
        TaxRegistrationNumber = taxRegistrationNumber;
        Phone = phone;
        Fax = fax;
        Email = email;
        TiersCompanyId = tiersCompanyId;
    }

    public int TiersId { get; set; }
    public string Title { get; set; }
    public string Label { get; set; }
    public string Description { get; set; }
    public string TaxRegistrationNumber { get; set; }
    public long Phone { get; set; }
    public long Fax { get; set; }
    public string Email { get; set; }
    public int TiersCompanyId { get; set; }
}