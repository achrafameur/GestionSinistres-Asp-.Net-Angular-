using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
 
namespace InsuriseDTO;
    public class ExpertSinisterNatureDto
{
    public ExpertSinisterNatureDto(int sinisterNatureId)
    {
        SinisterNatureId = sinisterNatureId;
    }

    public int SinisterNatureId { get; set; }
}
   
