using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetMandatoryDocuments;

public class SetMandatoryDocumentsCommandHandler : IRequestHandler<SetMandatoryDocumentsCommand>
{
    private readonly IRepository<SinisterNature> _SinisterNatureRepository;
    private readonly IMapper _mapper;

    public SetMandatoryDocumentsCommandHandler(IMapper mapper, IRepository<SinisterNature> SinisterNatureRepository)
    {
        _mapper = mapper;
        _SinisterNatureRepository = SinisterNatureRepository;
    }

    public async Task<Unit> Handle(SetMandatoryDocumentsCommand request, CancellationToken cancellationToken)
    {
        if (request.SinisterNatureMandatoryDocuments != null && request.SinisterNatureMandatoryDocuments.Count > 0)
        {
            var MandatoryDocumentstoAdd = new List<SinisterNatureMandatoryDocument>();
            var SinistreNatureToUpdate =
                await _SinisterNatureRepository.GetByIdAsync(request.SinisterNatureId, cancellationToken);
            foreach (var pw in request.SinisterNatureMandatoryDocuments)
            {
                var sinisterNatureMandatoryDocument = _mapper.Map<SinisterNatureMandatoryDocument>(pw);
                MandatoryDocumentstoAdd.Add(sinisterNatureMandatoryDocument);
            }

            SinistreNatureToUpdate.AddSinisterNatureMandatoryDocuments(MandatoryDocumentstoAdd);
            await _SinisterNatureRepository.UpdateAsync(SinistreNatureToUpdate, cancellationToken);
        }

        return Unit.Value;
    }
}