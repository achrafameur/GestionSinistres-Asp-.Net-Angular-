using MediatR;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Insurise.Application.Features.Sinister.Experts.Commands.SetSpecialities;

public class SetSpecialitiesCommandHandler : IRequestHandler<SetSpecialitiesCommand>
{
    private readonly IRepository<Expert> _ExpertRepository;
    private readonly IMapper _mapper;

    public SetSpecialitiesCommandHandler(IMapper mapper, IRepository<Expert> ExpertRepository)
    {
        _mapper = mapper;
        _ExpertRepository = ExpertRepository;
    }

    public async Task<Unit> Handle(SetSpecialitiesCommand request, CancellationToken cancellationToken)
    {
        if (request.ExpertSpecialities != null && request.ExpertSpecialities.Count > 0)
        {
            var SpecialitiestoAdd = new List<ExpertSpeciality>();
            var expertToUpdate = await _ExpertRepository.GetByIdAsync(request.ExpertId, cancellationToken);
            foreach (var pw in request.ExpertSpecialities)
            {
                var expertSpeciality = _mapper.Map<ExpertSpeciality>(pw);
                SpecialitiestoAdd.Add(expertSpeciality);
            }

            expertToUpdate.AddExpertSpecialities(SpecialitiestoAdd);
            await _ExpertRepository.UpdateAsync(expertToUpdate, cancellationToken);
        }

        return Unit.Value;
    }
}