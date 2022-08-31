using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetSpecialities;

public class SetSinisterNatureSpecialitiesCommandHandler : IRequestHandler<SetSinisterNatureSpecialitiesCommand>
{
    private readonly IRepository<SinisterNature> _SinisterNatureRepository;
    private readonly IMapper _mapper;

    public SetSinisterNatureSpecialitiesCommandHandler(IMapper mapper,
        IRepository<SinisterNature> SinisterNatureRepository)
    {
        _mapper = mapper;
        _SinisterNatureRepository = SinisterNatureRepository;
    }

    public async Task<Unit> Handle(SetSinisterNatureSpecialitiesCommand request, CancellationToken cancellationToken)
    {
        if (request.SinisterNatureSpecialities != null && request.SinisterNatureSpecialities.Count > 0)
        {
            var SpecialitiestoAdd = new List<SinisterNatureSpeciality>();
            var SinistreNatureToUpdate =
                await _SinisterNatureRepository.GetByIdAsync(request.SinisterNatureId, cancellationToken);
            foreach (var pw in request.SinisterNatureSpecialities)
            {
                var sinisterNatureSpeciality = _mapper.Map<SinisterNatureSpeciality>(pw);
                SpecialitiestoAdd.Add(sinisterNatureSpeciality);
            }

            SinistreNatureToUpdate.AddSinisterNatureSpecialities(SpecialitiestoAdd);
            await _SinisterNatureRepository.UpdateAsync(SinistreNatureToUpdate, cancellationToken);
        }

        return Unit.Value;
    }
}