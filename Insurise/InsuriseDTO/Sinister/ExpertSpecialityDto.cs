namespace InsuriseDTO.Sinister;

public class ExpertSpecialityDto
{
    public ExpertSpecialityDto(bool mandatory, int expertId, int chainId)
    {
        Mandatory = mandatory;
        ExpertId = expertId;
        ChainId = chainId;
    }

    public bool Mandatory { get; set; }
    public int ExpertId { get; set; }
    public int ChainId { get; set; }
}