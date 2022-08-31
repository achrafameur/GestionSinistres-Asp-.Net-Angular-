import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/SinisterNature';
const FEATURE_URL = 'https://localhost:7228/api/Feature';
const MANDATORY_DOCUMENT_URL = 'https://localhost:7228/api/MandatoryDocument';
@Injectable({
  providedIn: 'root'
})
export class SinisterNatureService {

  constructor(private http: HttpClient) { }

  
  getSinisterNatures(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addSinisterNature(SinNat): Observable<any> {
    return this.http.post(API_URL,{
      title:SinNat.title,
      code:SinNat.code,
      branchId:SinNat.branchId,
      idaEnabled:SinNat.idaEnabled,
      transactionEnabled:SinNat.transactionEnabled,
      thirdPartyEnabled:SinNat.thirdPartyEnabled,
      victimEnabled:SinNat.victimEnabled,
      respEnabled:SinNat.respEnabled,
      respAutoEnabled:SinNat.respAutoEnabled,
      affaireEnabled:SinNat.affaireEnabled,
      expertiseEnabled:SinNat.expertiseEnabled,
      evalInterneEnabled:SinNat.evalInterneEnabled,
      evalInterneCorpEnabled:SinNat.evalInterneCorpEnabled,
      regExpertEnabled:SinNat.regExpertEnabled
    }, httpOptions);
  }

  DeleteSinisterNature(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getSinisterNatureById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateSinisterNature(SinNat,id): Observable<any>{
    return this.http.put(API_URL,{
      sinisterNatureId:id,
      title:SinNat.title,
      code:SinNat.code,
      branchId:SinNat.branchId,
      idaEnabled:SinNat.idaEnabled,
      transactionEnabled:SinNat.transactionEnabled,
      thirdPartyEnabled:SinNat.thirdPartyEnabled,
      victimEnabled:SinNat.victimEnabled,
      formulaEvaluationId:SinNat.formulaEvaluationId,
      formulaFeesId:SinNat.formulaFeesId,
      respEnabled:SinNat.respEnabled,
      respAutoEnabled:SinNat.respAutoEnabled,
      affaireEnabled:SinNat.affaireEnabled,
      expertiseEnabled:SinNat.expertiseEnabled,
      evalInterneEnabled:SinNat.evalInterneEnabled,
      evalInterneCorpEnabled:SinNat.evalInterneCorpEnabled,
      regExpertEnabled:SinNat.regExpertEnabled,
    }, httpOptions);
  }


  getSinisterNatureSpecialities(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/getSpecialities/'+id)
  }
  setSinisterNatureSpecialities(SpecialitiesToSet: any , id ):Observable<any>{
    return this.http.post(API_URL + '/setSpecialities',{
      sinisterNatureId:id,
      sinisterNatureSpecialities : SpecialitiesToSet
    })
  }



  getSinisterNatureFeatures(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/getFeatures/'+id)
  }
  getFeatures(): Observable<any> {
    return this.http.get(FEATURE_URL+'/all');
  }
  getFeatureById(id:any): Observable<any> {
    return this.http.get(FEATURE_URL+'/'+id);
  }
  setFeatures(FeaturesToSet: any , id):Observable<any>{
    return this.http.post(API_URL + '/setSinisterNatureFeatures',{
      sinisterNatureId:id,
      sinisterNatureFeatures : FeaturesToSet
    })
  }


  getAllMandatoryDocuments(): Observable<any> {
    return this.http.get(MANDATORY_DOCUMENT_URL+'/all');
  }
  setSinisterNatureMandatoryDocuments(MandatoryDocumentsToSet:any,id:number):Observable<any>{
    return this.http.post(API_URL + '/setMandatoryDocuments',{
      sinisterNatureId:id,
      sinisterNatureMandatoryDocuments : MandatoryDocumentsToSet
    })
  }
  getSinisterNatureMandatoryDocuments(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/getMandatoryDocuments/'+id)
  }

}
