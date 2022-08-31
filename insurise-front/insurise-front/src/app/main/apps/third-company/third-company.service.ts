import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/TiersCompany';
@Injectable({
  providedIn: 'root'
})
export class ThirdCompanyService {

  constructor(private http: HttpClient) { }

  getThirdPartyCompanies(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addThirdPartyCompany(ThirdPartyCompany): Observable<any> {
    return this.http.post(API_URL,{
      label:ThirdPartyCompany.label,
      description:ThirdPartyCompany.description,
      taxRegistrationNumber:ThirdPartyCompany.taxRegistrationNumber,
      phone:ThirdPartyCompany.phone,
      fax:ThirdPartyCompany.fax,
      email:ThirdPartyCompany.email,
      address:ThirdPartyCompany.address,
    }, httpOptions);
  }

  DeleteThirdPartyCompany(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getThirdPartyCompanyById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateThirdPartyCompany(ThirdPartyCompany,id): Observable<any> {
    return this.http.put(API_URL,{
      tiersCompanyId:id,
      label:ThirdPartyCompany.label,
      description:ThirdPartyCompany.description,
      taxRegistrationNumber:ThirdPartyCompany.taxRegistrationNumber,
      phone:ThirdPartyCompany.phone,
      fax:ThirdPartyCompany.fax,
      email:ThirdPartyCompany.email,
      address:ThirdPartyCompany.address,
    }, httpOptions);
  }
}
