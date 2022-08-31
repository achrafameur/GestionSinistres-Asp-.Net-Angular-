using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureMandatoryDocuments;

public class GetSinisterNatureMandatoryDocumentsDto
{
    public GetSinisterNatureMandatoryDocumentsDto(int mandatoryDocumentId, string mandatoryDocument,
        int sinisterNatureId, string sinisterNature)
    {
        MandatoryDocumentId = mandatoryDocumentId;
        MandatoryDocument = mandatoryDocument;
        SinisterNatureId = sinisterNatureId;
        SinisterNature = sinisterNature;
    }

    public int MandatoryDocumentId { get; set; }
    public string MandatoryDocument { get; set; }
    public int SinisterNatureId { get; set; }
    public string SinisterNature { get; set; }
}