namespace InsuriseDTO.Sinister;

public class NatureToAttachDto
{
    public NatureToAttachDto(int id, string title)
    {
        NatureToAttachId = id;
        Title = title;
    }

    public int NatureToAttachId { get; }
    public string Title { get; }
}