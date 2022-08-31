using Insurise.Core.Entities.Production.WarrantyAggregate;
 
using Insurise.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Events
{
    public class WarrantyTaxesChoseEvent : BaseDomainEvent
    {
        public WarrantyTaxesChoseEvent(Tax tax , Warranty warranty)
        {
            ChosenTax = tax;
            Warranty = warranty;

        }
        public Tax ChosenTax { get; set; }
        public Warranty Warranty { get; set; }
    }
    }
