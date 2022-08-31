namespace Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;

public class DurationDetailDto
{
    public DurationDetailDto(int durationId, string title, string type, int value, double coefficient,
        string? startDate, string? endDate, bool renewable)
    {
        DurationId = durationId;
        Title = title;
        Type = type;
        Value = value;
        Coefficient = coefficient;
        StartDate = startDate;
        EndDate = endDate;
        Renewable = renewable;
    }

    public int DurationId { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    public double Coefficient { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool Renewable { get; set; }
}
