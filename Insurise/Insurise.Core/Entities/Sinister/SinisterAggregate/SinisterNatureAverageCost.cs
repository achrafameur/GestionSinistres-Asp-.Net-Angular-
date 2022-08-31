using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class SinisterNatureAverageCost : BaseEntity<int>
{
    public SinisterNatureAverageCost(decimal averageCost, DateTime dateStart, DateTime dateEnd)
    {
        AverageCost = averageCost;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }

    public decimal AverageCost { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public int SinisterNatureId { get; set; }

    public virtual SinisterNature? SinisterNature { get; set; }
}