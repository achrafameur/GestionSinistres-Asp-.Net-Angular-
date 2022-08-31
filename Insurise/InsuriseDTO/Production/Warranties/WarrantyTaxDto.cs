using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO.Production.Warranties
{
    public class WarrantyTaxDto
    {
        public WarrantyTaxDto(int id, int rank, string? description, int taxId, int warrantyId, string tax, string warranty)
        {
           
            Rank = rank;
            Description = description;
            WarrantyId = warrantyId;
            Warranty = warranty;
            TaxId = taxId;
            Tax = tax;
            IsChecked = true;
        }

        public int Id { get; set; }
        public int Rank { get; set; }
        public string? Description { get; set; }
        public int TaxId { get; set; }
        public int WarrantyId { get; set; }
        public string Warranty { get; set; }
       
        public string Tax { get; set; }
        public bool IsChecked { get; set; }
    }
}
