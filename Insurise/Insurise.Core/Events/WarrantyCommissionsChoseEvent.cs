using Insurise.Core.Entities.Production.WarrantyAggregate; 
using Insurise.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Events
{
    public class WarrantyCommissionsChoseEvent : BaseDomainEvent
    {
        public WarrantyCommissionsChoseEvent(Commission commission,Warranty warranty)
        {
            CommissionChosen = commission;
            Warranty = warranty;

        }
        public Commission CommissionChosen { get; set; }
        public Warranty Warranty { get; set; }
    }
}
