using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Production.Proportions.Commands.UpdateProportion;

public class UpdateProportionCommandHandler : IRequestHandler<UpdateProportionCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Proportion> _proportionRepository;

    public UpdateProportionCommandHandler(IMapper mapper, IRepository<Proportion> proportionRepository)
    {
        _mapper = mapper;
        _proportionRepository = proportionRepository;
    }

    public async Task<Unit> Handle(UpdateProportionCommand request, CancellationToken cancellationToken)
    {
        var proportionToUpdate = await _proportionRepository.GetByIdAsync(request.ProportionId, cancellationToken);
        if (proportionToUpdate == null) throw new ProportionNotFoundException(request.ProportionId);
        _mapper.Map(request, proportionToUpdate, typeof(UpdateProportionCommand), typeof(Proportion));
        await _proportionRepository.UpdateAsync(proportionToUpdate, cancellationToken);
        return Unit.Value;
    }
}