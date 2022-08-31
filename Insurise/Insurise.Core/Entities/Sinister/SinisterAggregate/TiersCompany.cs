using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class TiersCompany : BaseEntity<int>
{
    private readonly List<Tiers> _tiers;

    public TiersCompany(string taxRegistrationNumber, string label, string description, string phone, string fax, string email, string address)
    {
        TaxRegistrationNumber = taxRegistrationNumber;
        Label = label;
        Description = description;
        Phone = phone;
        Fax = fax;
        Email = email;
        Address = address;
        _tiers = new List<Tiers>();
    }

    public string TaxRegistrationNumber { get; set; }
    public string Label { get; set; }

    public string Description { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public IReadOnlyCollection<Tiers> Tiers => _tiers.AsReadOnly();
}
