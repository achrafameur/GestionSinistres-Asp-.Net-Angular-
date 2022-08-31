import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiUrl } from 'app/main/pages/interfaces/config';
import { FeatureDto} from 'app/main/pages/interfaces/feature';
import { IFeatureItems } from 'app/main/pages/interfaces/featureItems';
import { Nature } from 'app/main/pages/interfaces/nature';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FeatureService {

  constructor(private http : HttpClient) { }

  loadFeatures(){
    return this.http.get<FeatureDto[]>(`${apiUrl}/Feature/all`); 
  }
  loadFeatureById(id:number):Observable<FeatureDto>{
    return this.http.get<FeatureDto>(`${apiUrl}/Feature/${id}`);
  }
  addFeature(data:FeatureDto):Observable<FeatureDto>{
    return this.http.post<FeatureDto>(`${apiUrl}/Feature`,data)
  }
  deleteFeature(id:number){
    return this.http.delete(`${apiUrl}/Feature/${id}`)
  }
  updateFeature(feature,id):Observable<any>{
    return this.http.put(`${apiUrl}/Feature`,{
      featureId: id,
    title: feature.title,
    description: feature.description,
    symbol: feature.symbol,
    fixed: feature.fixed,
    minimum: feature.minimum,
    maximum: feature.maximum,
    alterable: feature.alterable,
    isPrincipal: feature.isPrincipal,
    rankShow:feature.rankShow,
    natureId: feature.natureId,
    chainId: feature.chainId,
    });

  }
  loadNatureById (id : number):Observable<Nature> {
    return this.http.get<Nature>(`${apiUrl}/Nature/${id}`)
     }
     setFeatureItems(id:number, items:number[]){
       return this.http.post(`${apiUrl}/Feature/setItems`,{
        featureId : id,
        featureItems : items
       })
     }
     getItemsByFeatureId(id:number){
      return this.http.get<IFeatureItems[]>(`${apiUrl}/Feature/GetItemsByFeatureId/${id}`)
    }
}
