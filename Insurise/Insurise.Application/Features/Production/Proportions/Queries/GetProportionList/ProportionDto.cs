namespace Insurise.Application.Features.Production.Proportions.Queries.GetProportionList;

public class ProportionDto
{
    public ProportionDto(int proportionId, string title, int occurence, float additionalCcosts)
    {
        ProportionId = proportionId;
        Title = title;
        Occurence = occurence;
        AdditionalCosts = additionalCcosts;
    }

    public int ProportionId { get; }
    public string Title { get; }
    public int Occurence { get; }
    public float AdditionalCosts { get; }
}