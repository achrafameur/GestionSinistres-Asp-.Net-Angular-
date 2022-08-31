import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json' })
};

const API_URL = 'https://localhost:7228/api/Branch';
@Injectable({
  providedIn: 'root'
})
export class BranchService {

  constructor(private http: HttpClient) { }

  getBranches(): Observable<any> {
    return this.http.get(API_URL + '/all');
  }

  addBranch(branch): Observable<any> {
    return this.http.post(API_URL,{
      title:branch.title,
      description:branch.description,
      parentId:branch.parentId
    }, httpOptions);
  }

  deleteBranch(id : any): Observable<void>{
    return this.http.delete<void>(API_URL+'/'+id)
  } 

  getBranchById(id:any) :  Observable<any>{
    return this.http.get(API_URL+'/'+id)
  }

  updateBranch(branch,id): Observable<any> {
    return this.http.put(API_URL,{
      branchId:id,
      title:branch.title,
      description:branch.description,
      parentId:branch.parentId
    }, httpOptions);
  }

}
