import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiUrl } from 'app/main/pages/interfaces/config';
import { Nature } from 'app/main/pages/interfaces/nature';

import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NatureService {

  constructor(private http : HttpClient) { }
  loadNatures () {
    return this.http.get<Nature[]>(`${apiUrl}/Nature/all`); 
  }

  createNature (data:Nature): Observable<Nature> {
return this.http.post<Nature>(`${apiUrl}/Nature`,data);
  }

  updateNature(nature,id):Observable<Nature>{
    return this.http.put<Nature>(`${apiUrl}/Nature`,{
      natureId:id,
      title:nature.title,
      isList:nature.isList
    } );
  }
  deleteNature (id:number){
    return this.http.delete(`${apiUrl}/Nature/${id}`); 
  }
  loadNatureById (id : number):Observable<Nature> {
 return this.http.get<Nature>(`${apiUrl}/Nature/${id}`)
  }
}
