using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO
{
    public class GetExpertSpecialityDto
    {
        public GetExpertSpecialityDto(int chainElementId, string chainElement, int expertId, string expert)
        {
            ChainElementId = chainElementId;
            ChainElement = chainElement;
            ExpertId = expertId;
            Expert = expert;
        }

        public int ChainElementId { get; set; }
        public string ChainElement { get; set; }
        public int ExpertId { get; set; }
        public string Expert { get; set; }
    }
}
