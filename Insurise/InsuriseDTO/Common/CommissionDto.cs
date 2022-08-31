using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO.Common
{
    public class CommissionDto
    {
        public CommissionDto(int commissionId, decimal value)
        {
            CommissionId = commissionId;
            Value = value;
        }

        public int CommissionId { get; set; }
        public decimal Value { get; set; }
    }
}
