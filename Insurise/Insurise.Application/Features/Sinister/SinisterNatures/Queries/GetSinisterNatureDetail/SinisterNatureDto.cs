namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureDetail;

public class SinisterNatureDto
{
    public SinisterNatureDto(
        int sinisterNatureId,
        string title, string code, int branchId, string branch, bool idaEnabled
        , bool transactionEnabled, bool thirdPartyEnabled, bool victimEnabled
        , string? formulaEvaluationId, string? formulaFeesId
        , bool respEnabled, bool respAutoEnabled, bool affaireEnabled, bool expertiseEnabled, bool evalInterneEnabled
        , bool evalInterneCorpEnabled, bool regExpertEnabled, bool isChecked)
    {
        SinisterNatureId = sinisterNatureId;
        Title = title;
        Code = code;
        BranchId = branchId;
        Branch = branch;
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

    public int SinisterNatureId { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }
    public int BranchId { get; set; }
    public string Branch { get; set; }
    public bool IdaEnabled { get; set; }
    public bool TransactionEnabled { get; set; }
    public bool ThirdPartyEnabled { get; set; }
    public bool VictimEnabled { get; set; }
    public string FormulaEvaluationId { get; set; }
    public string FormulaFeesId { get; set; }
    public bool RespEnabled { get; set; }
    public bool RespAutoEnabled { get; set; }
    public bool AffaireEnabled { get; set; }
    public bool ExpertiseEnabled { get; set; }
    public bool EvalInterneEnabled { get; set; }
    public bool EvalInterneCorpEnabled { get; set; }
    public bool RegExpertEnabled { get; set; }
    public bool IsChecked { get; set; }
}