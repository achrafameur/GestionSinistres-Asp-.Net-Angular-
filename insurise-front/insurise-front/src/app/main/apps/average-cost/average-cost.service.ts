import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/SinisterNatureAverageCost';
const SINISTERNATURE_URL = 'https://localhost:7228/api/SinisterNature/all';
@Injectable({
  providedIn: 'root'
})
export class AverageCostService {

  constructor(private http: HttpClient) { }

  getAverageCosts(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addAverageCost(AvgCost): Observable<any> {
    return this.http.post(API_URL,{
      sinisterNatureId:AvgCost.sinisterNatureId,
      averageCost:AvgCost.averageCost,
      dateStart:AvgCost.dateStart,
      dateEnd:AvgCost.dateEnd
    }, httpOptions);
  }

  DeleteAverageCost(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getAverageCostById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateAverageCost(AvgCost,id): Observable<any> {
    return this.http.put(API_URL,{
      avgCostId:id,
      sinisterNatureId:AvgCost.sinisterNatureId,
      averageCost:AvgCost.averageCost,
      dateStart:AvgCost.dateStart,
      dateEnd:AvgCost.dateEnd
    }, httpOptions);
  }


  getSinisterNatures(): Observable<any> {
    return this.http.get(SINISTERNATURE_URL);
  }
}
