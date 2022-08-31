import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/Tax';
@Injectable({
  providedIn: 'root'
})
export class TaxService {

   
  constructor(private http: HttpClient) { }

  getTaxes(): Observable<any> {
    return this.http.get(API_URL+'/all');
  }

  addTax(Tax): Observable<any> {
    return this.http.post(API_URL,{
      title:Tax.title,
      description:Tax.description,
      coefficient:Tax.coefficient,
      constant:Tax.constant,
    }, httpOptions);
  }

  DeleteTax(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getTaxById(id:any) : Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateTax(Tax,id): Observable<any>{
    return this.http.put(API_URL,{
      taxId:id,
      title:Tax.title,
      description:Tax.description,
      coefficient:Tax.coefficient,
      constant:Tax.constant,
    }, httpOptions);
  }
}
