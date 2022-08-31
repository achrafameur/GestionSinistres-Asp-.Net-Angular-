namespace Insurise.Application.Features.Sinister.MandatoryDocuments.Queries.GetMandatoryDocumentList;

public class MandatoryDocumentDto
{
    public MandatoryDocumentDto(int mandatoryDocumentId, string title)
    {
        MandatoryDocumentId = mandatoryDocumentId;
        Title = title;
    }

    public int MandatoryDocumentId { get; set; }
    public string Title { get; set; }
}