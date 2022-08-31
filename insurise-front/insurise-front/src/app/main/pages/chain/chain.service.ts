import { HttpClient } from '@angular/common/http';
import { Chain } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { id } from '@swimlane/ngx-datatable';
import { observable, Observable } from 'rxjs';
import { ChainDto } from '../interfaces/chain';

import { apiUrl } from '../interfaces/config';
import { Item } from '../interfaces/item';

@Injectable({
  providedIn: 'root'
})
export class ChainService {

  constructor(private http : HttpClient) { }

  loadChains(){
    return this.http.get<ChainDto[]>(`${apiUrl}/Chain/all`); 
  }

  loadChainById(id:number):Observable<ChainDto>{
    return this.http.get<ChainDto>(`${apiUrl}/Chain/${id}`);
  }
  
  addChain(data:ChainDto):Observable<ChainDto>{
    return this.http.post<ChainDto>(`${apiUrl}/Chain`,data)
  }
  deleteChain(id:number){
    return this.http.delete(`${apiUrl}/Chain/${id}`)
  }
  updateChain(chain:ChainDto):Observable<ChainDto>{
    return this.http.put<ChainDto>(`${apiUrl}/Chain`,chain); 
  }
 
}
