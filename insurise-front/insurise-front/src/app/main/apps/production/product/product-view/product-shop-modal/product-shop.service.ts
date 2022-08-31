import {HttpClient, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import {ApplicationConfigService} from "../../../../config/application-config.service";
import {IProductShops, ProductShops} from "../../model/productShop";
import {IProductWarranties} from "../../model/productwarranties";

@Injectable({
  providedIn: 'root' // just before your class
})
export class ProductShopService implements Resolve<any> {
  protected productsUrl =this.applicationConfigService.getEndpointFor("/product");
  protected shopsUrl =this.applicationConfigService.getEndpointFor("/shop/all");
  public onProductshopsViewChanged: BehaviorSubject<any>;
  public rowsProductshops: any;

  /**
   * Constructor
   *
   * @param {HttpClient} _httpClient
   */
  constructor(private _httpClient: HttpClient,
              protected applicationConfigService: ApplicationConfigService
  ) {
    // Set the defaults
    this.onProductshopsViewChanged = new BehaviorSubject({});
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
        this.rowsProductshops = response;
        this.onProductshopsViewChanged.next(this.rowsProductshops);
        resolve(this.rowsProductshops);
      }, reject);
    });
  }

  updateProductShops(productId: number, dataProductshopsSelected: any) {

    const url = `${this.productsUrl}/SetShops`;
    let modelProductShops  =  {productId :productId, productShops :dataProductshopsSelected };
    return this._httpClient.post(url, modelProductShops, {
      observe: 'response',
    });
  }

  getShops(productId: number= null): Observable<any[]> {
    let url = `${this.productsUrl}/GetProductShopsListByProductId/${productId}`;
    if(productId==null){
      url = `${this.shopsUrl} `;
      return this._httpClient.get<any>(url);
    }
    return this._httpClient.get<IProductShops[]>(url);
  }
}

