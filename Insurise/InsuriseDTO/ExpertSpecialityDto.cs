using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO
{
    public class ExpertSpecialityDto
    {
        public ExpertSpecialityDto(bool mandatory,int chainElementId)
        {
            Mandatory = mandatory;
            ChainElementId = chainElementId;
        }

        public bool Mandatory { get; set; }
        public int ChainElementId { get; set; }
    }
}
