using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO
{
    public class SinisterNatureMandatoryDocumentDto
    {
        public SinisterNatureMandatoryDocumentDto( int mandatoryDocumentId)
        {
            MandatoryDocumentId = mandatoryDocumentId;
        }
        public int MandatoryDocumentId { get; set; }
    }
}
