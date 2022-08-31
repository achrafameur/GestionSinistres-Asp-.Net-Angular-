using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuriseDTO.Production.Feature
{
    public class FeatureItemDto
    {
        public FeatureItemDto(int id,int rank, int featureId, int itemId, string? feature, string? item)
        {
           Rank = rank;
            ItemId = itemId;
            Item = item;
            FeatureId = featureId;
            Feature = feature;
        }

        public int Id { get; set; }
        public int Rank { get; set; }
        public int ItemId { get; set; }
        public string? Item { get; set; }
        public int FeatureId { get; set; }
        public string? Feature { get; set; }
    }
}
