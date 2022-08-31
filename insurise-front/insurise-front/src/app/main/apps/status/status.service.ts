import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/Status';
const ITEM_URL = 'https://localhost:7228/api/Item';
@Injectable({
  providedIn: 'root'
})
export class StatusService {

  
  constructor(private http: HttpClient) { }

  getStatus(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addStatus(Status): Observable<any> {
    return this.http.post(API_URL,{
      title:Status.title,
      symbol:Status.symbol,
      itemId:Status.itemId,
    }, httpOptions);
  }

  DeleteStatus(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getStatusById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateStatus(status,id): Observable<any>{
    return this.http.put(API_URL,{
      statusId:id,
      title:status.title,
      symbol:status.symbol,
      itemId:status.itemId,
    }, httpOptions);
  }


  getItems(): Observable<any> {
    return this.http.get(ITEM_URL);
  }
}
