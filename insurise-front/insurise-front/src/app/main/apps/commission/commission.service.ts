import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICommission } from 'app/main/pages/interfaces/commission';
import { apiUrl } from 'app/main/pages/interfaces/config';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommissionService {

  constructor(private http : HttpClient) { }
  loadCommissions(){
    return this.http.get<ICommission[]>(`${apiUrl}/Commission/all`); 
  }
  CreateCommission (data:ICommission): Observable<ICommission>{
    return this.http.post<ICommission>(`${apiUrl}/Commission`,data);

  }
  updateCommission(commission,id):Observable<ICommission>{
    return this.http.put<ICommission>(`${apiUrl}/Commission`,{
      commissionId:id,
      value:commission.value,
    
    } );
  }
  deleteCommission (id:number){
    return this.http.delete(`${apiUrl}/Commission/${id}`); 
  }
  loadCommissionById (id : number):Observable<ICommission> {
 return this.http.get<ICommission>(`${apiUrl}/Commission/${id}`)
  }
}
