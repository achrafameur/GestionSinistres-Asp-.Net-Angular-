using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO
{
    public class SinisterNatureFeatureDto
    {
        public SinisterNatureFeatureDto(int featureId)
        {
            FeatureId = featureId;
        }

        public int FeatureId { get; set; }
    }
}
