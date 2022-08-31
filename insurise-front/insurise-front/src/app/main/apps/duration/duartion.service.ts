import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/Duration';
@Injectable({
  providedIn: 'root'
})
export class DuartionService {

   
  constructor(private http: HttpClient) { }

  getDurations(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addDuration(Duration): Observable<any> {
    return this.http.post(API_URL,{
      title:Duration.title,
      type:Duration.type,
      value:Duration.value,
      coefficient:Duration.coefficient,
      startDate:Duration.startDate,
      endDate:Duration.endDate,
      renewable:Duration.renewable,
    }, httpOptions);
  }

  DeleteDuration(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getDurationById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateDuration(Duration,id): Observable<any>{
    return this.http.put(API_URL,{
      durationId:id,
      title:Duration.title,
      type:Duration.type,
      value:Duration.value,
      coefficient:Duration.coefficient,
      startDate:Duration.startDate,
      endDate:Duration.endDate,
      renewable:Duration.renewable,
    }, httpOptions);
  }
}
