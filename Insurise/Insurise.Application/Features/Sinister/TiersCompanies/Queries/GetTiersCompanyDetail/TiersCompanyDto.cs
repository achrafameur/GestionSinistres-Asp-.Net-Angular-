namespace Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompanyDetail;

public class TiersCompanyDto
{
    public TiersCompanyDto(int tiersCompanyId, string taxRegistrationNumber, string label, string description,
        string phone, string fax, string email, string address)
    {
        TiersCompanyId = tiersCompanyId;
        TaxRegistrationNumber = taxRegistrationNumber;
        Label = label;
        Description = description;
        Phone = phone;
        Fax = fax;
        Email = email;
        Address = address;
        CreationDate = DateTime.Now;
    }

    public int TiersCompanyId { get; set; }
    public string TaxRegistrationNumber { get; set; }
    public string Label { get; set; }
    public string Description { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public DateTime CreationDate { get; set; }
}