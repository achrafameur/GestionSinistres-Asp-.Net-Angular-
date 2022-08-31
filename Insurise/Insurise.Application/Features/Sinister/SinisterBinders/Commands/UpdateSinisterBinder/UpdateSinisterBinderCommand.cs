using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Commands.UpdateSinisterBinder;

public class UpdateSinisterBinderCommand : IRequest
{
    public UpdateSinisterBinderCommand(int sinisterBinderId, DateTime sinisterDate, string sinisterTime,
        string sinisterPlace
        , string policyNumber, string insuredName, string insuredObject, string description
        , DateTime reclamationDate)
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
}