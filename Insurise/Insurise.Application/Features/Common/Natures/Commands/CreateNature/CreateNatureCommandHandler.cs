using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Natures.Commands.CreateNature;

public class CreateNatureCommandHandler : IRequestHandler<CreateNatureCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Nature> _natureRepository;


    public CreateNatureCommandHandler(IMapper mapper, IRepository<Nature> natureRepository)
    {
        _mapper = mapper;
        _natureRepository = natureRepository;
    }

    public async Task<int> Handle(CreateNatureCommand request, CancellationToken cancellationToken)
    {
        var nature = _mapper.Map<Nature>(request);
        nature = await _natureRepository.AddAsync(nature, cancellationToken);
        return nature.Id;
    }
}