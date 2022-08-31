using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureFeatures;

public class GetSinisterNatureFeaturesDto
{
    public GetSinisterNatureFeaturesDto
        (int featureId, string feature, int sinisterNatureId, string sinisterNature)
    {
        FeatureId = featureId;
        Feature = feature;
        SinisterNatureId = sinisterNatureId;
        SinisterNature = sinisterNature;
    }

    public int FeatureId { get; set; }
    public string Feature { get; set; }
    public int SinisterNatureId { get; set; }
    public string SinisterNature { get; set; }
}