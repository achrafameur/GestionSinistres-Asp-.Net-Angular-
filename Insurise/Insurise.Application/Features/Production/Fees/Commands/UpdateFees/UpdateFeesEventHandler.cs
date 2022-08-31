using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Production.Fees.Commands.UpdateFees;

public class UpdateFeesEventHandler : IRequestHandler<UpdateFeesCommand>
{
    private readonly IRepository<Fee> _feesRepository;
    private readonly IMapper _mapper;

    public UpdateFeesEventHandler(IMapper mapper, IRepository<Fee> feesRepository)
    {
        _mapper = mapper;
        _feesRepository = feesRepository;
    }

    public async Task<Unit> Handle(UpdateFeesCommand request, CancellationToken cancellationToken)
    {
        var feeToUpdate = await _feesRepository.GetByIdAsync(request.FeesId, cancellationToken);

        if (feeToUpdate == null) throw new FeeNotFoundException(request.FeesId);

        _mapper.Map(request, feeToUpdate, typeof(UpdateFeesCommand), typeof(Fee));

        await _feesRepository.UpdateAsync(feeToUpdate, cancellationToken);

        return Unit.Value;
    }
}