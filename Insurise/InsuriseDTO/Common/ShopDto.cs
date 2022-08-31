namespace InsuriseDTO.Common;
 

public class ShopDto
    {

    public ShopDto(int id, string title, int type, string code, string description, int? departmentId )
    {
        Id = id;
        Title = title;
        Type = type;
        Code = code;
        Description = description;
        DepartmentId = departmentId; 
    }
    public int Id { get; set; }
    public string Title { get; set; } 
    public int  Type { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public int? DepartmentId { get; set; } 
   
    public List<int?> ListProduct { get; set; }
}
