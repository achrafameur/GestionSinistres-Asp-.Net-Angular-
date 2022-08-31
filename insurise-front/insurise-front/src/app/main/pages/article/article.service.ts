import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiUrl } from 'app/main/pages/interfaces/config';
import { Item } from 'app/main/pages/interfaces/item';
import { Observable } from 'rxjs';
import { IFeatureItems } from '../interfaces/featureItems';


@Injectable({
  providedIn: 'root'
})


export class ArticleService {
  constructor(private http : HttpClient ) { 

  }

  loadItems (): Observable<Item[]> {
    return this.http.get<Item[]>(`${apiUrl}/Item`); 
  }

  createItem (data:Item): Observable<Item> {
return this.http.post<Item>(`${apiUrl}/Item`,data);
  }

  updateItem(item,id):Observable<Item>{
    return this.http.put<Item>(`${apiUrl}/Item`,{
      itemId:id,
      title:item.title
    });
  }
  deleteItem (id:number){
    return this.http.delete(`${apiUrl}/Item/${id}`); 
  }
  loadItemById (id : number):Observable<Item> {
 return this.http.get<Item>(`${apiUrl}/Item/${id}`);
  }
  getFeaturesByItemId(id:number){
    return this.http.get<IFeatureItems[]>(`${apiUrl}/Item/GetFeaturesByItemId/${id}`)
  }
  


}