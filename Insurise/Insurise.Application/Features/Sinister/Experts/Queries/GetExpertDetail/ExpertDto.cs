namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertDetail;

public class ExpertDto
{
    public ExpertDto(int expertId, string typeExpert, int code, string fName, string lName, string cin, string email,
        DateTime birthDate, string sexId, long tel, long fixe, int fax, string governorate, string address,
        DateTime cancellationDate, DateTime registrationDate)
    {
        ExpertId = expertId;
        TypeExpert = typeExpert;
        Code = code;
        FName = fName;
        LName = lName;
        Cin = cin;
        Email = email;
        BirthDate = birthDate;
        SexId = sexId;
        Tel = tel;
        Fixe = fixe;
        Fax = fax;
        Governorate = governorate;
        Address = address;
        CancellationDate = cancellationDate;
        RegistrationDate = registrationDate;
    }

    public int ExpertId { get; set; }
    public string TypeExpert { get; set; }
    public int Code { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Cin { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public string SexId { get; set; }
    public long Tel { get; set; }
    public long Fixe { get; set; }
    public int Fax { get; set; }
    public string Governorate { get; set; }
    public string Address { get; set; }
    public DateTime CancellationDate { get; set; }
    public DateTime RegistrationDate { get; set; }
}