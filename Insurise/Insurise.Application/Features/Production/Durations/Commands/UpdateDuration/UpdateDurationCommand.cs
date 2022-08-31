using MediatR;

namespace Insurise.Application.Features.Production.Durations.Commands.UpdateDuration;

public class UpdateDurationCommand : IRequest
{
    public UpdateDurationCommand(int durationId, string title, string type, int value, double coefficient,
        DateTime startDate, DateTime endDate, bool renewable)
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
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Renewable { get; set; }
}