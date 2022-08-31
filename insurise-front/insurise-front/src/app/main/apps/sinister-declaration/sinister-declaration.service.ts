import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/SinisterBinder';
@Injectable({
  providedIn: 'root'
})
export class SinisterDeclarationService {

   
  constructor(private http: HttpClient) { }

  getSinisterBinders(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  adSinisterBinder(Sinister): Observable<any> {
    return this.http.post(API_URL,{
      sinisterDate:Sinister.sinisterDate,
      sinisterTime:Sinister.sinisterTime,
      sinisterPlace:Sinister.sinisterPlace,
      policyNumber:Sinister.policyNumber,
      insuredName:Sinister.insuredName,
      insuredObject:Sinister.insuredObject,
      description:Sinister.description,
      reclamationDate:Sinister.reclamationDate,
    }, httpOptions);
  }

  DeleteSinisterBinder(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getSinisterBinderById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateSinisterBinder(Sinister,id): Observable<any>{
    return this.http.put(API_URL,{
      sinisterBinderId:id,
      sinisterdate:Sinister.sinisterdate,
      sinisterTime:Sinister.sinisterTime,
      sinisterPlace:Sinister.sinisterPlace,
      policyNumber:Sinister.policyNumber,
      insuredName:Sinister.insuredName,
      insuredObject:Sinister.insuredObject,
      dsescription:Sinister.dsescription,
      reclamationDate:Sinister.reclamationDate,
    }, httpOptions);
  }
}
