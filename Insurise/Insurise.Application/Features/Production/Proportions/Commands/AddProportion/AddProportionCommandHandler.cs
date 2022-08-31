using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Commands.AddProportion;

public class AddProportionCommandHandler : IRequestHandler<AddProportionCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Proportion> _proportionRepository;

    public AddProportionCommandHandler(IMapper mapper, IRepository<Proportion> proportionRepository)
    {
        _mapper = mapper;
        _proportionRepository = proportionRepository;
    }

    public async Task<int> Handle(AddProportionCommand request, CancellationToken cancellationToken)
    {
        var proportion = _mapper.Map<Proportion>(request);
        proportion = await _proportionRepository.AddAsync(proportion, cancellationToken);
        return proportion.Id;
    }
}