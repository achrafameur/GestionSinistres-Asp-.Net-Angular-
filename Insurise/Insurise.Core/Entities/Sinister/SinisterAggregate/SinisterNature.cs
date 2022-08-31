using Insurise.Core.Entities.Common;
using Insurise.Core.Events;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class SinisterNature : BaseEntity<int>
{
    public List<SinisterNatureSpeciality> sinisterNaturesSpecialities = new List<SinisterNatureSpeciality>();
    public virtual IEnumerable<SinisterNatureSpeciality> SinisterNaturesSpecialities => sinisterNaturesSpecialities.AsReadOnly();

    public List<SinisterNatureMandatoryDocument> sinisterNaturesMandatoryDocuments = new List<SinisterNatureMandatoryDocument>();
    public virtual IEnumerable<SinisterNatureMandatoryDocument> SinisterNaturesMandatoryDocuments => sinisterNaturesMandatoryDocuments.AsReadOnly();

    public List<SinisterNatureFeature> sinisterNaturesFeatures = new List<SinisterNatureFeature>();
    public virtual IEnumerable<SinisterNatureFeature> SinisterNaturesFeatures => sinisterNaturesFeatures.AsReadOnly();
    public SinisterNature() { }
    public SinisterNature(
        string title, string code, int branchId, bool idaEnabled
        , bool transactionEnabled, bool thirdPartyEnabled, bool victimEnabled, string formulaEvaluationId, string formulaFeesId
        , bool respEnabled, bool respAutoEnabled, bool affaireEnabled, bool expertiseEnabled, bool evalInterneEnabled
        , bool evalInterneCorpEnabled, bool regExpertEnabled, bool isChecked)
    {
        Title = title;
        Code = code;
        BranchId = branchId;
        IdaEnabled = idaEnabled;
        TransactionEnabled = transactionEnabled;
        ThirdPartyEnabled = thirdPartyEnabled;
        VictimEnabled = victimEnabled;
        FormulaEvaluationId = formulaEvaluationId;
        FormulaFeesId = formulaFeesId;
        RespEnabled = respEnabled;
        RespAutoEnabled = respAutoEnabled;
        AffaireEnabled = affaireEnabled;
        ExpertiseEnabled = expertiseEnabled;
        EvalInterneEnabled = evalInterneEnabled;
        EvalInterneCorpEnabled = evalInterneCorpEnabled;
        RegExpertEnabled = regExpertEnabled;
        IsChecked = isChecked;
    }

    public string Title { get; set; }
    public string Code { get; set; }
    public int BranchId { get; set; }
    public Branch Branch { get; set; }
    public bool IdaEnabled { get; set; }
    public bool TransactionEnabled { get; set; }
    public bool ThirdPartyEnabled { get; set; }
    public bool VictimEnabled { get; set; }
    public string? FormulaEvaluationId { get; set; }
    public string? FormulaFeesId { get; set; }
    public bool RespEnabled { get; set; }
    public bool RespAutoEnabled { get; set; }
    public bool AffaireEnabled { get; set; }
    public bool ExpertiseEnabled { get; set; }
    public bool EvalInterneEnabled { get; set; }
    public bool EvalInterneCorpEnabled { get; set; }
    public bool RegExpertEnabled { get; set; }
    public bool IsChecked { get; set; }

    public List<SinisterNatureAverageCost> SinisterNatureAvgerageCosts { get; set; }
    public List<SinisterNatureExpert> Experts { get; set; }


    public void AddSinisterNatureMandatoryDocuments(List<SinisterNatureMandatoryDocument> SinisterNatureMandatoryDocuments)
    {
        sinisterNaturesMandatoryDocuments.AddRange(SinisterNatureMandatoryDocuments);
        foreach (var sinisterNaturesMandatoryDocument in SinisterNatureMandatoryDocuments)
        {
            var newMandatoryDocumentAddedEvent = new SinisterNatureMandatoryDocumentsChoseEvent(this, sinisterNaturesMandatoryDocument.MandatoryDocument);
            Events.Add(newMandatoryDocumentAddedEvent);
        }
    }

    public void AddSinisterNatureFeatures(List<SinisterNatureFeature> sinisterNatureFeatures)
    {
        sinisterNaturesFeatures.AddRange(sinisterNatureFeatures);
        foreach (var sinisterNaturesFeature in sinisterNatureFeatures)
        {
            var newFeatureAddedEvent = new SinisterNatureFeaturesChoseEvent(this, sinisterNaturesFeature.Feature);
            Events.Add(newFeatureAddedEvent);
        }
    }

    public void AddSinisterNatureSpecialities(List<SinisterNatureSpeciality> sinisterNatureSpecialities)
    {
        sinisterNaturesSpecialities.AddRange(sinisterNatureSpecialities);
        foreach (var sinisterNatureSpeciality in sinisterNatureSpecialities)
        {
            var newSpecialityAddedEvent = new SinisterNatureSpecialitiesChoseEvent(this, sinisterNatureSpeciality.ChainElement);
            Events.Add(newSpecialityAddedEvent);
        }
    }
}
