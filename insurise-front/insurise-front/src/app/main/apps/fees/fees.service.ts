import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/Fee';
@Injectable({
  providedIn: 'root'
})
export class FeesService {

     
  constructor(private http: HttpClient) { }

  getFees(): Observable<any> {
    return this.http.get(API_URL+ '/all');
  }

  addFee(Fee): Observable<any> {
    return this.http.post(API_URL,{
      title:Fee.title,
      symbol:Fee.symbol,
      description:Fee.description,
      equation:Fee.equation,
      type:Fee.type,
    }, httpOptions);
  }

  DeleteFee(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getFeeById(id:any) : Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateFee(Fee,id): Observable<any>{
    return this.http.put(API_URL,{
      feesId:id, 
      title:Fee.title,
      symbol:Fee.symbol,
      description:Fee.description,
      equation:Fee.equation,
      type:Fee.type,
    }, httpOptions);
  }
}
