using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO
{
    public class GetExpertSinisterNaturesDto
    {
        public GetExpertSinisterNaturesDto(int sinisterNatureId, string sinisterNature, int expertId, string expert)
        {
            SinisterNatureId = sinisterNatureId;
            SinisterNature = sinisterNature;
            ExpertId = expertId;
            Expert = expert;
        } 
        public int SinisterNatureId { get; set; }
        public string SinisterNature { get; set; }
        public int ExpertId { get; set; }
        public string Expert { get; set; } 
    }
}
