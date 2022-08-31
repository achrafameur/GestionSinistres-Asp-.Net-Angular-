using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Natures.Commands.UpdateNature;

public class UpdateNatureCommandHandler : IRequestHandler<UpdateNatureCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Nature> _natureRepository;

    public UpdateNatureCommandHandler(IMapper mapper, IRepository<Nature> natureRepository)
    {
        _mapper = mapper;
        _natureRepository = natureRepository;
    }

    public async Task<Unit> Handle(UpdateNatureCommand request, CancellationToken cancellationToken)
    {
        var natureToUpdate = await _natureRepository.GetByIdAsync(request.natureId, cancellationToken);
        if (natureToUpdate == null) throw new NatureNotFoundException(request.natureId);
        _mapper.Map(request, natureToUpdate, typeof(UpdateNatureCommand), typeof(Nature));
        await _natureRepository.UpdateAsync(natureToUpdate, cancellationToken);
        return Unit.Value;
    }
}