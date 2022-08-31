import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiUrl } from '../interfaces/config';
import { Proportion } from '../interfaces/proportion';

@Injectable({
  providedIn: 'root'
})
export class ProportionService {

  constructor(private http : HttpClient) { }
  loadProportions(){
    return this.http.get<Proportion[]>(`${apiUrl}/Proportion/all`); 
  }
  createProportion(data:Proportion):Observable<Proportion>{
    return this.http.post<Proportion>(`${apiUrl}/Proportion`,data);
  }
   updateProportion(proportion,id):Observable<Proportion>{
    return this.http.put<Proportion>(`${apiUrl}/Proportion`,{
      proportionId:id,
      title:proportion.title,
      occurence:proportion.occurence,
      additionalCosts:Number(proportion.additionalCosts)
    } );
  }
  deleteProportion (id:number){
    return this.http.delete(`${apiUrl}/Proportion/${id}`); 
  }
  loadProportionById (id : number):Observable<Proportion> {
 return this.http.get<Proportion>(`${apiUrl}/Proportion/${id}`)
  }
}
