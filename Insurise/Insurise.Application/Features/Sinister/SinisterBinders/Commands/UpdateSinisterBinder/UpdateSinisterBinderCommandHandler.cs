using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Commands.UpdateSinisterBinder;

public class UpdateSinisterBinderCommandHandler : IRequestHandler<UpdateSinisterBinderCommand>
{
    private readonly IRepository<SinisterBinder> _sinisterBinderRepository;
    private readonly IMapper _mapper;

    public UpdateSinisterBinderCommandHandler(IMapper mapper, IRepository<SinisterBinder> sinisterBinderRepository)
    {
        _mapper = mapper;
        _sinisterBinderRepository = sinisterBinderRepository;
    }

    public async Task<Unit> Handle(UpdateSinisterBinderCommand request, CancellationToken cancellationToken)
    {
        var sinisterBinderToUpdate =
            await _sinisterBinderRepository.GetByIdAsync(request.SinisterBinderId, cancellationToken);

        // if (SinisterBinderToUpdate == null) throw new NotFoundException("Sinister Binder", request.SinisterBinderId);

        _mapper.Map(request, sinisterBinderToUpdate, typeof(UpdateSinisterBinderCommand), typeof(MandatoryDocument));

        await _sinisterBinderRepository.UpdateAsync(sinisterBinderToUpdate, cancellationToken);

        return Unit.Value;
    }
}