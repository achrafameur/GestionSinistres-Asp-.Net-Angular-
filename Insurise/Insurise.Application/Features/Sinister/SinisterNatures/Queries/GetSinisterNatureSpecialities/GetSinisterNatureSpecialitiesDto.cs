using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureSpecialities;

public class GetSinisterNatureSpecialitiesDto
{
    public GetSinisterNatureSpecialitiesDto(int chainElementId, string chainElement, int sinisterNatureId,
        string sinisterNature)
    {
        ChainElementId = chainElementId;
        ChainElement = chainElement;
        SinisterNatureId = sinisterNatureId;
        SinisterNature = sinisterNature;
    }

    public int ChainElementId { get; set; }
    public string ChainElement { get; set; }
    public int SinisterNatureId { get; set; }
    public string SinisterNature { get; set; }
}