using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters.Commun.items;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Production.Feature;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Items.Queries.GetFeaturesList
{
    public class GetFeaturesListQueryHandler : IRequestHandler<GetFeaturesListQuery, List<FeatureItemDto>>
    {


        private readonly IRepository<Item> _itemRepository;

        private readonly IMapper _mapper;

        public GetFeaturesListQueryHandler(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<FeatureItemDto>> Handle(GetFeaturesListQuery request, CancellationToken cancellationToken)
        {
            var filter = new ItemFilter
            {
                ItemId = request.ItemId,
                LoadChildren = true,
                Children = new List<string> { "FeatureItems", "FeatureItems.Feature" },
                IsPagingEnabled = false
            };
            var featuresByItemIdSpec = new ItemSpecSingleResult(filter);


            var featuresByItem = await _itemRepository.GetBySpecAsync(featuresByItemIdSpec);
            var mappedItem = _mapper.Map<List<FeatureItemDto>>(featuresByItem?.FeatureItems.OrderBy(x => x.Rank));
            return mappedItem;
        }
    }
}
