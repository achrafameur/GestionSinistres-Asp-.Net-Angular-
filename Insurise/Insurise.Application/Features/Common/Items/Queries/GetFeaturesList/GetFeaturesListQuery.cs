using InsuriseDTO.Production.Feature;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Items.Queries.GetFeaturesList
{
    public class GetFeaturesListQuery : IRequest<List<FeatureItemDto>>
    {
        public GetFeaturesListQuery(int itemId)
        {
            ItemId = itemId;
        }

        public int ItemId { get; set; }
    }
}
