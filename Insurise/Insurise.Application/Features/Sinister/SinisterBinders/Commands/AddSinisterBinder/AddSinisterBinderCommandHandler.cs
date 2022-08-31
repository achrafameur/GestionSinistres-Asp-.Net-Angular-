using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Commands.AddSinisterBinder;

public class AddSinisterBinderCommandHandler : IRequestHandler<AddSinisterBinderCommand, int>
{
    private readonly IRepository<SinisterBinder> _SinisterBinderRepository;
    private readonly IMapper _mapper;

    public AddSinisterBinderCommandHandler(IMapper mapper, IRepository<SinisterBinder> SinisterBinderRepository)
    {
        _mapper = mapper;
        _SinisterBinderRepository = SinisterBinderRepository;
    }

    public async Task<int> Handle(AddSinisterBinderCommand request, CancellationToken cancellationToken)
    {
        var sinisterBinder = _mapper.Map<SinisterBinder>(request);
        sinisterBinder = await _SinisterBinderRepository.AddAsync(sinisterBinder, cancellationToken);

        return sinisterBinder.Id;
    }
}