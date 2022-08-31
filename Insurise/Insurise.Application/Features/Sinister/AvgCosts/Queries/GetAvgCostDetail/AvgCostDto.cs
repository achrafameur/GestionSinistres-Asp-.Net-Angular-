namespace Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostDetail;

public class AvgCostDto
{
    public AvgCostDto(int avgCostId, int sinNatureId, string sinisterNature, decimal averageCost, DateTime startDate, DateTime endDate)
    {
        AvgCostId = avgCostId;
        SinisterNatureId = sinNatureId;
        SinisterNature = sinisterNature;
        AverageCost = averageCost;
        StartDate = startDate;
        EndDate = endDate;
    }

    public int AvgCostId { get; set; }
    public int SinisterNatureId { get; set; }
    public string SinisterNature { get; set; }
    public decimal AverageCost { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}