import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/Tiers';
const ThirdPartyCompany_URL = 'https://localhost:7228/api/TiersCompany/all';


@Injectable({
  providedIn: 'root'
})

export class ThirdPartyService {

  
  constructor(private http: HttpClient) { }

  getThirds(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addThirdParty(ThirdParty): Observable<any> {
    return this.http.post(API_URL,{
      title:ThirdParty.title,
      label:ThirdParty.label,
      description:ThirdParty.description,
      taxRegistrationNumber:ThirdParty.taxRegistrationNumber,
      phone:ThirdParty.phone,
      fax:ThirdParty.fax,
      email:ThirdParty.email,
      tiersCompanyId:ThirdParty.tiersCompanyId,
    }, httpOptions);
  }

  DeleteThirdParty(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getThirdPartyById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateThirdParty(ThirdParty,id): Observable<any> {
    return this.http.put(API_URL,{
      tiersId:id,
      title:ThirdParty.title,
      label:ThirdParty.label,
      description:ThirdParty.description,
      taxRegistrationNumber:ThirdParty.taxRegistrationNumber,
      phone:ThirdParty.phone,
      fax:ThirdParty.fax,
      email:ThirdParty.email,
      tiersCompanyId:ThirdParty.tiersCompanyId,
    }, httpOptions);
  }

  getThirdPartyCompanies(): Observable<any> {
    return this.http.get(ThirdPartyCompany_URL);
  }
}
