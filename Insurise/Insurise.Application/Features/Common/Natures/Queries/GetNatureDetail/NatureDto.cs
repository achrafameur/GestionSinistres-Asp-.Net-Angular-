namespace Insurise.Application.Features.Common.Natures.Queries.GetNatureDetail;

public class NatureDto
{
    public NatureDto(int id, string title, bool isList)
    {
        Id = id;
        Title = title;
        IsList = isList;
    }

    public int Id { get; }
    public string Title { get; }
    public bool IsList { get; set; }
}