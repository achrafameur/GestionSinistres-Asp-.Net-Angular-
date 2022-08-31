using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Events
{
    public class ExpertSpecialitiesChoseEvent : BaseDomainEvent
    {
        public ChainElement SpecialityChosen { get; set; }
        public Expert Expert { get; set; }

        public ExpertSpecialitiesChoseEvent(Expert expert,
        ChainElement specialityChosen)
        {
            Expert = expert;
            SpecialityChosen = specialityChosen;
        }
    }
}
