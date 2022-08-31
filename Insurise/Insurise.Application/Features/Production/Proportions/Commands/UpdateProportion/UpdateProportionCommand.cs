using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Commands.UpdateProportion;

public class UpdateProportionCommand : IRequest
{
    public UpdateProportionCommand(int proportionId, string title, int occurence, float additionalCosts)
    {
        ProportionId = proportionId;
        Title = title;
        Occurence = occurence;
        AdditionalCosts = additionalCosts;
    }

    public int ProportionId { get; set; }
    public string Title { get; set; }
    public int Occurence { get; set; }
    public float AdditionalCosts { get; set; }
}