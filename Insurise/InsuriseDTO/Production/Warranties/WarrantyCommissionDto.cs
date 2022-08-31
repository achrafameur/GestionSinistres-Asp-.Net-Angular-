using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO.Production.Warranties
{
    public class WarrantyCommissionDto
    {
        public WarrantyCommissionDto(int id,int rank, string? description, int? codeAgence, string? libelleAgence, int commissionId, int warrantyId, decimal commission, string warranty)
        {
           
            Description = description;
            Rank = rank;
            CodeAgence = codeAgence;
            LibelleAgence = libelleAgence;
            CommissionId = commissionId;
             Commission = commission;
            WarrantyId = warrantyId;
            Warranty = warranty;
            IsChecked = true;
        }

        public int Id { get; set; }
        public int Rank { get; set; }
        public string? Description { get; set; }
        public int? CodeAgence { get; set; }
        public string? LibelleAgence { get; set; }
        public int CommissionId { get; set; }
        public decimal Commission { get; set; }
        public int WarrantyId { get; set; }
        public string Warranty { get; set; }
        public bool IsChecked { get; set; }
    }
}
