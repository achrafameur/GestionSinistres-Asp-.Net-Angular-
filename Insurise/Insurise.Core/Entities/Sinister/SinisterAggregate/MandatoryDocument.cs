using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class MandatoryDocument : BaseEntity<int>
{
    private readonly List<SinisterNatureMandatoryDocument> _sinisterNaturesMandatoryDocuments;

    public MandatoryDocument(string title)
    {
        Title = title;
        _sinisterNaturesMandatoryDocuments = new List<SinisterNatureMandatoryDocument>();
    }

    public string Title { get; private set; }

    public IEnumerable<SinisterNatureMandatoryDocument> SinisterNaturesMandatoryDocuments => _sinisterNaturesMandatoryDocuments.AsReadOnly();
}