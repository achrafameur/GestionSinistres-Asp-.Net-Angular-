import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/Expert';
const CHAIN_URL = 'https://localhost:7228/api/Chain';
const CHAIN_ELEMENT_URL = 'https://localhost:7228/api/ChainElement';
@Injectable({
  providedIn: 'root'
})

export class ExpertService {

  constructor(private http: HttpClient) { }

  getExperts(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addExpert(Expert): Observable<any> {
    return this.http.post(API_URL,{
      typeExpert:Expert.typeExpert,
      code:Expert.code,
      fName:Expert.fName,
      lName:Expert.lName,
      cin:Expert.cin,
      email:Expert.email,
      birthDate:Expert.birthDate,
      sexId:Expert.sexId,
      tel:Expert.tel,
      fixe:Expert.fixe,
      fax:Expert.fax,
      governorate:Expert.governorate,
      address:Expert.address,
      cancellationDate:Expert.cancellationDate,
      registrationDate:Expert.registrationDate,
    }, httpOptions);
  }

  DeleteExpert(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getExpertById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateExpert(Expert,id): Observable<any>{
    return this.http.put(API_URL,{
      expertId:id,
      typeExpert:Expert.typeExpert,
      code:Expert.code,
      fName:Expert.fName,
      lName:Expert.lName,
      cin:Expert.cin,
      email:Expert.email,
      birthDate:Expert.birthDate,
      sexId:Expert.sexId,
      tel:Expert.tel,
      fixe:Expert.fixe,
      fax:Expert.fax,
      governorate:Expert.governorate,
      address:Expert.address,
      cancellationDate:Expert.cancellationDate,
      registrationDate:Expert.registrationDate,
    }, httpOptions);
  }

  
  setSinisterNatures(SinisterNaturesToSet: any , id:number ):Observable<any>{
    return this.http.post(API_URL + '/setSinisterNatures',{
      expertId : id,
      expertSinisterNatures : SinisterNaturesToSet
    })
  }
  getExpertSinisterNatures(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/getSinisterNatures/'+id)
  }
  
  
  getChains(): Observable<any> {
    return this.http.get(CHAIN_URL + '/all');
  }
  getChainById(id:any):  Observable<any>{
    return this.http.get(CHAIN_URL+'/'+id)
  }
  getExpertSpecialities(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/getSpecialities/'+id)
  }
  setSpecialities(SpecialitiesToSet: any , id ):Observable<any>{
    return this.http.post(API_URL + '/setSpecialities',{
      expertId:id,
      expertSpecialities : SpecialitiesToSet
    })
  }
  getChainsElements(): Observable<any> {
    return this.http.get(CHAIN_ELEMENT_URL + '/all');
  }
}
