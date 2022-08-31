import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { ICommission } from 'app/main/pages/interfaces/commission';
import { apiUrl } from 'app/main/pages/interfaces/config';
import { FeatureDto } from 'app/main/pages/interfaces/feature';
import { ITax } from 'app/main/pages/interfaces/tax';
import { IWarranty, Warranty } from 'app/main/pages/interfaces/warranty';
import { IWarrantyCommissions, IWarrantyCommissionsUpdate } from 'app/main/pages/interfaces/warrantyCommissions';
import { IWarrantyCommissionsModal, WarrantyCommissionsModal } from 'app/main/pages/interfaces/warrantyCommissionsModal';
import { IWarrantyFeatures, IWarrantyFeatureUpdate, WarrantyFeaturesModal } from 'app/main/pages/interfaces/warrantyFeatures';
import { IWarrantyProducts } from 'app/main/pages/interfaces/warrantyProducts';
import { IWarrantyTaxes, IWarrantyTaxesUpdate } from 'app/main/pages/interfaces/warrantyTaxes';
import { WarrantyTaxesModal } from 'app/main/pages/interfaces/warrantyTaxesModal';
import { Feature } from 'app/main/ui/sinister-nature/models/Feature';
import { BehaviorSubject, Observable } from 'rxjs';
import { ApplicationConfigService } from '../config/application-config.service';
import { IProductWarranties } from '../production/product/model/productwarranties';

export type EntityResponseType = HttpResponse<IWarranty>;




@Injectable({
  providedIn: 'root'
})
export class WarrantyService implements Resolve<any> {
  protected warrantiesUrl =this.applicationConfigService.getEndpointFor("/warranty");
  public rows: any;
  public onWarrantyViewChanged: BehaviorSubject<any>;
  
  public rowsFeatures: any;
  public rowsProducts: any;

  public onWarrantyFeaturesViewChanged: BehaviorSubject<any>;
  public onWarrantyProductsViewChanged: BehaviorSubject<any>;

  public rowsTaxes: any;
  public rowsCommissions:any;
  public onWarrantyTaxesViewChanged: BehaviorSubject<any>;
  public onWarrantyCommissionsViewChanged: BehaviorSubject<any>;

  public id;

  /**
   * Constructor
   *
   * @param {HttpClient} _httpClient
   */
  constructor(private _httpClient: HttpClient,private http : HttpClient,protected applicationConfigService: ApplicationConfigService) {
    this.onWarrantyViewChanged = new BehaviorSubject({});
    this.onWarrantyFeaturesViewChanged = new BehaviorSubject({});
    this.onWarrantyTaxesViewChanged = new BehaviorSubject({});
    this.onWarrantyCommissionsViewChanged=new BehaviorSubject({})
    this.onWarrantyProductsViewChanged=new BehaviorSubject({})

   }
    /**
   * Resolver
   *
   * @param {ActivatedRouteSnapshot} route
   * @param {RouterStateSnapshot} state
   * @returns {Observable<any> | Promise<any> | any}
   */
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any  {
    let currentId = Number(route.paramMap.get('id'));
    return new Promise<void>((resolve, reject) => {
      Promise.all([
        this.getApiData(currentId),
        this.getWarrantyFeaturesRows(currentId)
        ,this.getWarrantyTaxesRows(currentId),
        this.getWarrantyCommissionsRows(currentId),
        this.getWarrantyProductsRows(currentId)
      ]).then(() => {
        resolve();
      }, reject);
    });
  }
  getWarrantyFeaturesRows(id: number): Promise<any[]> {
    const url = `https://localhost:7228/api/Warranty/GetFeaturesByWarrantyId${id}`;
     //const url = this.productsUrl+ '/GetWarrantiesByProductId/'+id;
     return new Promise((resolve, reject) => {
       this.http.get<IWarrantyFeatures[]>(url).subscribe((response: any) => {
         this.rowsFeatures = response;
         this.onWarrantyFeaturesViewChanged.next(this.rowsFeatures);
         resolve(this.rowsFeatures);
       }, reject);
     });
   }
   getWarrantyTaxesRows(id: number): Promise<any[]> {
    const url = `${apiUrl}/Warranty/GetTaxesByWarrantyId/${id}`;
    
    return new Promise((resolve, reject) => {
      this._httpClient.get<IWarrantyTaxes[]>(url).subscribe((response: any) => {
        this.rowsTaxes = response;
        this.onWarrantyTaxesViewChanged.next(this.rowsTaxes);
        resolve(this.rowsTaxes);
      }, reject);
    });
  }

  getWarrantyCommissionsRows(id: number): Promise<any[]> {
    const url = `${apiUrl}/Warranty/GetCommissionsByWarrantyId/${id}`;
    
    return new Promise((resolve, reject) => {
      this._httpClient.get<IWarrantyCommissions[]>(url).subscribe((response: any) => {
        this.rowsCommissions = response;
        this.onWarrantyCommissionsViewChanged.next(this.rowsCommissions);
        resolve(this.rowsCommissions);
      }, reject);
    });
  }
  getWarrantyProductsRows(id: number): Promise<any[]> {
    const url = `${apiUrl}/Warranty/GetProductsByWarrantyId/${id}`;
    
    return new Promise((resolve, reject) => {
      this._httpClient.get<IWarrantyProducts[]>(url).subscribe((response: any) => {
        this.rowsProducts = response;
        this.onWarrantyProductsViewChanged.next(this.rowsProducts);
        resolve(this.rowsProducts);
      }, reject);
    });
  }
   getApiData(id: number): Promise<any[]> {
    //const url = `${this.productsUrl}/${id}`;
    const url = `${apiUrl}/Warranty/${id}`;
    console.log(url);
    return new Promise((resolve, reject) => {
      this.http.get<IWarranty>(url).subscribe((response: any) => {
        this.rows = response;
        this.onWarrantyViewChanged.next(this.rows);
        resolve(this.rows);
      }, reject);
    });
  }
 




  // rod belk 

  loadWarranties(){
    return this.http.get<IWarranty[]>(`${apiUrl}/Warranty/all`); 
  }

  loadWarrantyById(id :number){
    return this.http.get<IWarranty>(`${apiUrl}/Warranty/${id}`)
  }
  addWarranty(warranty: IWarranty): Observable<IWarranty> {

    return this.http.post<IWarranty>(`${apiUrl}/Warranty`,warranty);
}
updateWarranty(warranty:IWarranty,id:number):Observable<any>{
  return this.http.put(`${apiUrl}/Warranty`,{
    warrantyId: id,
  title: warranty.title,
  description: warranty.description,
  
  symbol: warranty.symbol,
  createdDate: warranty.createdDate,
  startDate: warranty.startDate,
  endDate: warranty.endDate,
  defaultPeriod: warranty.defaultPeriod,
  isCommercialRate: warranty.isCommercialRate,
  typeTarif: Number(warranty.typeTarif),
 
  });

}
deleteWarranty(id:number){
  return this.http.delete(`${apiUrl}/Warranty/${id}`)
}

setWarrantyFeatures(warrantyFeatures:WarrantyFeaturesModal){
  return this.http.post<IWarrantyFeatures>(`${apiUrl}/Warranty/setFeatures`,warrantyFeatures)
}
updateWarrantyFeature(warrantyFeature:IWarrantyFeatureUpdate){
  return this.http.put(`${apiUrl}/Warranty/UpdateWarrantyFeature`,{
    id:warrantyFeature.id,
    mandatory:warrantyFeature.mandatory,
    rank:warrantyFeature.rank,
  })
}
deleteWarrantyFeature(id:number){
  return this.http.delete(`${apiUrl}/Warranty/DeleteWarrantyFeatureById/${id}`)
}
getFeaturesByWarrantyId(id:number){
  return this.http.get<IWarrantyFeatures[]>(`${apiUrl}/Warranty/GetFeaturesByWarrantyId/${id}`)
}
getProductsByWarrantyId(id:number){
  return this.http.get<IWarrantyProducts[]>(`${apiUrl}/Warranty/GetProductsByWarrantyId/${id}`)
}
setWarrantyTaxes(warrantyTaxes:WarrantyTaxesModal){
  return this.http.post<IWarrantyTaxes>(`${apiUrl}/Warranty/setTaxes`,warrantyTaxes)
}
getTaxesByWarrantyId(id:number){
  return this.http.get<IWarrantyTaxes[]>(`${apiUrl}/Warranty/GetTaxesByWarrantyId/${id}`)
}

updateWarrantytaxes(warrantyTax:IWarrantyTaxesUpdate){
  return this.http.put(`${apiUrl}/Warranty/UpdateWarrantyTax`,{
    id:warrantyTax.id,
    description:warrantyTax.description,
    rank:warrantyTax.rank,
  })
}
deleteWarrantyTax(id:number){
  return this.http.delete(`${apiUrl}/Warranty/DeleteWarrantyTaxById/${id}`)
}

loadTaxes(){
  return this.http.get<ITax[]>(`${apiUrl}/Tax/all`)
}
loadFeatures(){
  return this.http.get<FeatureDto[]>(`${apiUrl}/feature/all`)
}
loadCommissions(){
  return this.http.get<ICommission[]>(`${apiUrl}/Commission/all`)
}
getCommissionsByWarrantyId(id:number){
  return this.http.get<IWarrantyCommissions[]>(`${apiUrl}/Warranty/GetCommissionsByWarrantyId/${id}`)
}

updateWarrantyCommissions(warrantyCommission:IWarrantyCommissionsUpdate){
  return this.http.put(`${apiUrl}/Warranty/UpdateWarrantyCommission`,{
    id:warrantyCommission.id,
    codeAgence:Number(warrantyCommission.codeAgence),
    libelleAgence:warrantyCommission.libelleAgence, 
    rank:warrantyCommission.rank,
  })
}
setWarrantyCommissions(warrantyCommissions:WarrantyCommissionsModal){
  return this.http.post<IWarrantyCommissions>(`${apiUrl}/Warranty/setCommissions`,warrantyCommissions)
}
deleteWarrantyCommission(id:number){
  return this.http.delete(`${apiUrl}/Warranty/DeleteWarrantyCommissionById/${id}`)
}

delete(objectToDelete: any,deleteObjectType:string): Observable<HttpResponse<{}>> {
  let id=0;
  let  url='' ;
  switch(deleteObjectType) {
    case 'w': {
      id=objectToDelete.productId;
      url=`${apiUrl}/Warranty/${id}`;
      break;
    }
    case 'wf': {
      id=objectToDelete.id;
      url = `${apiUrl}/warranty/DeleteProductWarrantyById/${id}`;
      break;
    }
    case 'wt': {
      id=objectToDelete.id;
      url = `${apiUrl}/Warranty/DeleteWarrantyTaxById/${id}`;
      break;
    }
    case 'wc': {
      id=objectToDelete.id;
      url = `${apiUrl}/Warranty/DeleteWarrantyCommissionById/${id}`;
      break;
    }
    default: {
      id=objectToDelete.productId;
      url=`${apiUrl}/Warranty/${id}`;
      break;
    }
  }
  return this._httpClient.delete(url, {
    observe: "response",
  });
}
}
