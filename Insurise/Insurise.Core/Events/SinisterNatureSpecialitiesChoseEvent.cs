using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

 
    public class SinisterNatureSpecialitiesChoseEvent : BaseDomainEvent
    {
        public ChainElement SpecialityChosen { get; set; }
        public SinisterNature SinisterNature { get; set; }

        public SinisterNatureSpecialitiesChoseEvent(SinisterNature sinisterNature,
        ChainElement specialityChosen)
        {
            SinisterNature = sinisterNature;
            SpecialityChosen = specialityChosen;
        }
 
}