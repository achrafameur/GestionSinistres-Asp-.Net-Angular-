namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertNatures;

public class GetExpertNaturesDto
{
    public GetExpertNaturesDto(int natureId)
    {
        NatureId = natureId;
    }

    public int NatureId { get; set; }
}