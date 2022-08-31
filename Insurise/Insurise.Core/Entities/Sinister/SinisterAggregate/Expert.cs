using Insurise.Core.Events;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class Expert : BaseEntity<int>
{
    private readonly List<SinisterNatureExpert> _expertsinisterNatures = new();
    public virtual IEnumerable<SinisterNatureExpert> ExpertSinisterNatures => _expertsinisterNatures.AsReadOnly();

    private readonly List<ExpertSpeciality> _expertSpecialities = new();
    public virtual IEnumerable<ExpertSpeciality> ExpertSpecialities => _expertSpecialities.AsReadOnly();

    private readonly List<ExpertNature> _expertNatures = new();
    public virtual IEnumerable<ExpertNature> ExpertNatures => _expertNatures.AsReadOnly();


    public Expert(string typeExpert, int code, string fName, string lName, string cin, string email,
        DateTime birthDate, string sexId, long tel, long fixe, int fax, string governorate, string address,
        DateTime cancellationDate, DateTime registrationDate)
    {
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


    public void AddExpertSinisterNatures(List<SinisterNatureExpert> expertSinisterNatures)
    {
        _expertsinisterNatures.AddRange(expertSinisterNatures);
        foreach (var newSinisterNatureAddedEvent in expertSinisterNatures.Select(expertSinisterNature =>
                     new ExpertSinisterNaturesChoseEvent(this, expertSinisterNature.SinisterNature)))
            Events.Add(newSinisterNatureAddedEvent);
    }

    public void AddExpertNatures(List<ExpertNature> expertNatures)
    {
        _expertNatures.AddRange(expertNatures);
        foreach (var newNatureAddedEvent in expertNatures.Select(expertNature =>
                     new ExpertNaturesChoseEvent(this, expertNature.Nature))) Events.Add(newNatureAddedEvent);
    }

    public void AddExpertSpecialities(List<ExpertSpeciality> expertSpecialities)
    {
        _expertSpecialities.AddRange(expertSpecialities);
        foreach (var newSpecialityAddedEvent in expertSpecialities.Select(speciality =>
                     new ExpertSpecialitiesChoseEvent(this, speciality.ChainElement))) Events.Add(newSpecialityAddedEvent);


    }
}