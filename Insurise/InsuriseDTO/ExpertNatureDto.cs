using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO
{
    public class ExpertNatureDto
    {
        public ExpertNatureDto(bool mandatory, int expertId,string nature, int natureId)
        {
            Mandatory = mandatory;
            ExpertId = expertId;
            Nature = nature;
            NatureId = natureId;
        }

        public bool Mandatory { get; set; }
        public int ExpertId { get; set; }
        public string Nature { get; set; }
        public int NatureId { get; set; }
    }
}
