using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class Tiers : BaseEntity<int>
{
    public Tiers(string title, string label, string description, string taxRegistrationNumber, long phone, long fax,
        string email, int tiersCompanyId)
    {
        Title = title;
        Label = label;
        Description = description;
        TaxRegistrationNumber = taxRegistrationNumber;
        Phone = phone;
        Fax = fax;
        Email = email;
        TiersCompanyId = tiersCompanyId;
    }

    public string Title { get; set; }

    public string Label { get; set; }

    public string Description { get; set; }

    public string TaxRegistrationNumber { get; set; }

    public long Phone { get; set; }

    public long Fax { get; set; }


    public string Email { get; set; }

    public int TiersCompanyId { get; set; }
    public TiersCompany TiersCompany { get; set; }
}