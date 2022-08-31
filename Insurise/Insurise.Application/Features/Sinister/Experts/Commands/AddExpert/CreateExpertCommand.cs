using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.AddExpert;

public class CreateExpertCommand : IRequest<int>
{
    public CreateExpertCommand(string typeExpert, int code, string fName, string lName, long cin, string email,
        DateTime birthDate, string sexId, long tel, long fixe, int fax, string governorate, string address,
        DateTime cancellationDate, DateTime registrationDate)
    {
        TypeExpert = typeExpert;
        Code = code;
        FName = fName;
        LName = lName;
        CIN = cin;
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

    public string TypeExpert { get; set; }
    public int Code { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public long CIN { get; set; }
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