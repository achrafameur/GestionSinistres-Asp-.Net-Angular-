import {HttpClient, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import {ApplicationConfigService} from "../../../../config/application-config.service";
import {IProductDuration} from "../../model/productDuration";

@Injectable({
  providedIn: 'root' // just before your class
})
export class ProductDurationService implements Resolve<any> {
  protected productsUrl =this.applicationConfigService.getEndpointFor("/product");
  protected DurationsUrl =this.applicationConfigService.getEndpointFor("/Duration");
  public onProductDurationsViewChanged: BehaviorSubject<any>;
  public rowsProductDurations: any;

  /**
   * Constructor
   *
   * @param {HttpClient} _httpClient
   */
  constructor(private _httpClient: HttpClient,
              protected applicationConfigService: ApplicationConfigService
  ) {
    // Set the defaults
    this.onProductDurationsViewChanged = new BehaviorSubject({});
  }

  /**
   * Resolver
   *
   * @param {ActivatedRouteSnapshot} route
   * @param {RouterStateSnapshot} state
   * @returns {Observable<any> | Promise<any> | any}
   */
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
    let currentId = Number(route.paramMap.get('id'));
    return new Promise<void>((resolve, reject) => {
      Promise.all([
        this.getApiData(currentId)
      ]).then(() => {
        resolve();
      }, reject);
    });
  }

  /**
   * Get rows
   */
  getApiData(id: number): Promise<any[]> {
    const url = `${this.productsUrl}/${id}`;
    return new Promise((resolve, reject) => {
      this._httpClient.get<any>(url).subscribe((response: any) => {
        this.rowsProductDurations = response;
        this.onProductDurationsViewChanged.next(this.rowsProductDurations);
        resolve(this.rowsProductDurations);
      }, reject);
    });
  }

  updateProductDurations(dataProductDuration: any, dataProductDurationsSelected: any) {

    const url = `${this.productsUrl}/SetDurations`;
    let modelProductDurations  =  {ProductDurationId :dataProductDuration.id,DurationId :dataProductDuration.productDurationId,productId :dataProductDuration.productId,
      durationId :dataProductDuration.durationId, proportions :dataProductDurationsSelected };
    return this._httpClient.post(url, modelProductDurations, {
      observe: 'response',
    });
  }

  getDurations(productId: number= null): Observable<any[]> {
    let url = `${this.productsUrl}/GetProductDurationsListByProductId/${productId}`;
    if(productId==null){
      url = `${this.DurationsUrl}/all `;
      return this._httpClient.get<any>(url);
    }
    return this._httpClient.get<IProductDuration[]>(url);
  }
  getExceptDurationByProductId(productId: number= null): Observable<any[]> {
    let url = `${this.DurationsUrl}/GetExceptDurationByProductId/${productId}`;
    return this._httpClient.get<any[]>(url);
  }


  getProductDurationById(id: number= null): Observable<any> {
    if (id==null)id=0;
    let url = `${this.productsUrl}/GetProductDurationById/${id}`;
    return this._httpClient.get<IProductDuration>(url);
  }
}

