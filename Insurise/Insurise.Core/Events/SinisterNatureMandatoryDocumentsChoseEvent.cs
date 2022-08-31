using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class SinisterNatureMandatoryDocumentsChoseEvent : BaseDomainEvent
{
    public MandatoryDocument MandatoryDocumentChosen { get; set; }
    public SinisterNature SinisterNature { get; set; }

    public SinisterNatureMandatoryDocumentsChoseEvent(SinisterNature sinisterNature,
        MandatoryDocument mandatoryDocumentChosen)
    {
        SinisterNature = sinisterNature;
        MandatoryDocumentChosen = mandatoryDocumentChosen;
    }
}