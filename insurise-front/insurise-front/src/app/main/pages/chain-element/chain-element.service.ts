import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChainElement } from '../interfaces/chainElement';
import { apiUrl } from '../interfaces/config';

@Injectable({
  providedIn: 'root'
})
export class ChainElementService {

  constructor(private http : HttpClient) { 

  }
  loadChainElements(): Observable<ChainElement[]>{
    return this.http.get<ChainElement[]>(`${apiUrl}/ChainElement/all`); 
  }
  loadChainElementById(id:number):Observable<ChainElement>{
    return this.http.get<ChainElement>(`${apiUrl}/ChainElement/${id}`);
  }
  addChainElement(data:ChainElement):Observable<ChainElement>{
    return this.http.post<ChainElement>(`${apiUrl}/ChainElement`,data);
  }
  updateChainElement(element,id):Observable<ChainElement>{
    return this.http.put<ChainElement>(`${apiUrl}/ChainElement/${id}`,{
      chainElementId:id,
      title:element.title,
      chainId:element.chainId
    });}
    deleteChainElement(id:number){
      return this.http.delete(`${apiUrl}/ChainElement/${id}`)
    }

}
