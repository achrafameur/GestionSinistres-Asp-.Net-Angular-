using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBinderDetail;

public class SinisterBinderDto
{
    public SinisterBinderDto(int sinisterBinderId, DateTime sinisterDate, string sinisterTime, string sinisterPlace
        , string policyNumber, string insuredName, string insuredObject, string description
        , DateTime reclamationDate, DateTime createdDate)
    {
        SinisterBinderId = sinisterBinderId;
        SinisterDate = sinisterDate;
        SinisterTime = sinisterTime;
        SinisterPlace = sinisterPlace;
        PolicyNumber = policyNumber;
        InsuredName = insuredName;
        InsuredObject = insuredObject;
        Description = description;
        ReclamationDate = reclamationDate;
        CreatedDate = createdDate;
    }

    public int SinisterBinderId { get; set; }
    public DateTime SinisterDate { get; set; }
    public string SinisterTime { get; set; }
    public string? SinisterPlace { get; set; }
    public string? PolicyNumber { get; set; }
    public string? InsuredName { get; set; }
    public string? InsuredObject { get; set; }
    public string? Description { get; set; }
    public DateTime ReclamationDate { get; set; }
    public DateTime CreatedDate { get; set; }
}