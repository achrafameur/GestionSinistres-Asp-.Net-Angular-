using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class SinisterNatureMandatoryDocument : BaseEntity<int>
{
    public int MandatoryDocumentId { get; set; }
    public MandatoryDocument? MandatoryDocument { get; set; }
    public int SinisterNatureId { get; set; }
    public SinisterNature? SinisterNature { get; set; }
}