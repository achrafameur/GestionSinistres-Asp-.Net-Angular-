using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersDetail;

public class TiersDto
{
    public TiersDto(int tiersId, string title, string label, string description, string taxRegistrationNumber,
        long phone, long fax, string email, int tiersCompanyId, string tiersCompany)
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
        TiersCompany = tiersCompany;
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
    public string TiersCompany { get; set; }
}