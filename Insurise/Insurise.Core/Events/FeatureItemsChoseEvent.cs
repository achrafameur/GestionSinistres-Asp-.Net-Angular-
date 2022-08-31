using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Events
{
    public class FeatureItemsChoseEvent : BaseDomainEvent
    {
        public Feature Feature { get; set; }
        public Item ItemChosen { get; set; }
        public FeatureItemsChoseEvent( Feature feature, Item itemChosen)
        {
            Feature = feature;
            ItemChosen = itemChosen;

        }
    }
}
