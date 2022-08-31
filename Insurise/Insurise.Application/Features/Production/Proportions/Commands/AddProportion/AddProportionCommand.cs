using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Commands.AddProportion;

public class AddProportionCommand : IRequest<int>
{
    public AddProportionCommand(string title, int occurence, float additionalCosts)
    {
        Title = title;
        Occurence = occurence;
        AdditionalCosts = additionalCosts;
    }

    public string Title { get; set; }
    public int Occurence { get; set; }
    public float AdditionalCosts { get; set; }

    public override string ToString()
    {
        return
            $"Proportion name: {Title}; Created on:{DateTime.Now};has {Occurence} occurence ; with additional costs {AdditionalCosts}";
    }
}