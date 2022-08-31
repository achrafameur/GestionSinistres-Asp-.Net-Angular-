import {HttpClient, HttpResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { BehaviorSubject, Observable } from 'rxjs';
import {IProduct} from "../model/product";
import {IProductWarranties} from "../model/productwarranties";
import {ApplicationConfigService} from "../../../config/application-config.service";
import {EntityResponseType} from "../product-update/product-update.service";
import {IProductWarrantiesModal} from "../model/productWarrantiesModal";
import {createRequestOption} from "../../../core/request/request-util";
import {EntityArrayResponseType} from "../product.service";
import {IProductFees} from "../model/productFees";
import {IProductShops} from "../model/productShop";
import {IProductDuration} from "../model/productDuration";

@Injectable({
  providedIn: 'root' // just before your class
})
export class ProductViewService implements Resolve<any> {
  protected productsUrl =this.applicationConfigService.getEndpointFor("/product");
  protected warrantyUrl =this.applicationConfigService.getEndpointFor("/warranty/all");
  protected feeUrl =this.applicationConfigService.getEndpointFor("/fee/all");

  public rows: any;
  public onProductViewChanged: BehaviorSubject<any>;
  public onProductDurationsViewChanged: BehaviorSubject<any>;
  public onProductWarrantiesViewChanged: BehaviorSubject<any>;
  public onProductFeesViewChanged: BehaviorSubject<any>;
  public onProductShopsViewChanged: BehaviorSubject<any>;

  public rowsWarranties: any;
  public rowsDurations: any;
  public rowsFees: any;
  public rowsShops: any;
  public id;

  /**
   * Constructor
   *
   * @param {HttpClient} _httpClient
   */
  constructor(private _httpClient: HttpClient,
              protected applicationConfigService: ApplicationConfigService
  ) {
    // Set the defaults
    this.onProductViewChanged = new BehaviorSubject({});
    this.onProductWarrantiesViewChanged = new BehaviorSubject({});
    this.onProductDurationsViewChanged = new BehaviorSubject({});
    this.onProductFeesViewChanged = new BehaviorSubject({});
    this.onProductShopsViewChanged = new BehaviorSubject({});
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
        this.getApiData(currentId),
        this.getProductWarrantiesRows(currentId)
        ,this.getProductDurationsRows(currentId)
        ,this.getProductFeesRows(currentId)
        ,this.getProductShopsRows(currentId)
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
      this._httpClient.get<IProduct>(url).subscribe((response: any) => {
        this.rows = response;
        this.onProductViewChanged.next(this.rows);
        resolve(this.rows);
      }, reject);
    });
  }

  getProductsById(id: any): Observable<any> {
    return this._httpClient.get<IProduct>(`${this.productsUrl}/${id}`);
  }

  /**
   * Get  Product Warranties Rows
   */
  getProductWarrantiesRows(id: number): Promise<any[]> {
   const url = `${this.productsUrl}/GetWarrantiesByProductId/${id}`;
    return new Promise((resolve, reject) => {
      this._httpClient.get<IProductWarranties[]>(url).subscribe((response: any) => {
        this.rowsWarranties = response;
        this.onProductWarrantiesViewChanged.next(this.rowsWarranties);
        resolve(this.rowsWarranties);
      }, reject);
    });
  }
  /**
   * Get  Product durations Rows
   */
  getProductDurationsRows(id: number): Promise<any[]> {
    const url = `${this.productsUrl}/GetDurationsByProductId/${id}`;
    return new Promise((resolve, reject) => {
      this._httpClient.get<IProductDuration[]>(url).subscribe((response: any) => {
        this.rowsDurations = response;
        this.onProductDurationsViewChanged.next(this.rowsDurations);
        resolve(this.rowsDurations);
      }, reject);
    });
  }
  queryProductDurations(id?: any): Observable<any[]> {
    const url = `${this.productsUrl}/GetDurationsByProductId/${id}`;
    return this._httpClient.get<IProductDuration[]>(url);
  }

  /**
   * Get  Product Warranties Rows
   */


  getWarranties(term: string = null): Observable<any[]> {
    return this._httpClient.get<any>(`${this.warrantyUrl} `);
  }
  addProductWarranties(productWarranties: IProductWarrantiesModal): Observable<EntityResponseType> {
    const url = `${this.productsUrl}/setWarranties`;
    return this._httpClient.post<IProductWarranties>(url, productWarranties, {
      observe: 'response',
    });
  }
  updateProductWarrantyMandatory(productWarranties: IProductWarranties): Observable<EntityResponseType> {
    const url = `${this.productsUrl}/UpdateProductWarranty`;
    return this._httpClient.put<any>(
        url,
        productWarranties,
        {observe: 'response'}
    );
  }
  queryProductWarranties(id?: any): Observable<any[]> {
    const url = `${this.productsUrl}/GetWarrantiesByProductId/${id}`;
    return this._httpClient.get<IProductWarranties[]>(url);

  }
  deleteProductWarranty(id: number): Observable<HttpResponse<{}>> {
    const url = `${this.productsUrl}/DeleteProductWarrantyById/${id}`;
    return this._httpClient.delete(url, {
      observe: "response",
    });
  }
  /**
   * Get  Product Fees Rows
   */
  getProductFeesRows(id: number): Promise<any[]> {
    const url = `${this.productsUrl}/GetFeesByProductId/${id}`;
    return new Promise((resolve, reject) => {
      this._httpClient.get<IProductFees[]>(url).subscribe((response: any) => {
        this.rowsFees = response;
        this.onProductFeesViewChanged.next(this.rowsFees);
        resolve(this.rowsFees);
      }, reject);
    });
  }
  getFees(term: string = null): Observable<any[]> {
    return this._httpClient.get<any>(`${this.feeUrl} `);
  }
  addProductFees(productFees:any): Observable<EntityResponseType> {
    const url = `${this.productsUrl}/SetFees`;
    return this._httpClient.post<any>(url, productFees, {
      observe: 'response',
    });
  }
  queryProductFees(id?: any): Observable<any[]> {
    const url = `${this.productsUrl}/GetFeesByProductId/${id}`;
    return this._httpClient.get<IProductFees[]>(url);
  }
  updateProductFeesRank(productFees: IProductFees): Observable<EntityResponseType> {
    const url = `${this.productsUrl}/UpdateProductFee`;
    return this._httpClient.put<any>(
        url,
        productFees,
        {observe: 'response'}
    );
  }
  /**
   * Get  Product Shops Rows
   */
  getProductShopsRows(id: number): Promise<any[]> {
    const url = `${this.productsUrl}/GetShopsByProductId/${id}`;
    return new Promise((resolve, reject) => {
      this._httpClient.get<IProductShops[]>(url).subscribe((response: any) => {
        this.rowsShops = response;
        this.onProductShopsViewChanged.next(this.rowsShops);
        resolve(this.rowsShops);
      }, reject);
    });
  }
  queryProductShops(id?: any): Observable<any[]> {
    const url = `${this.productsUrl}/GetShopsByProductId/${id}`;
    return this._httpClient.get<IProductShops[]>(url);
  }

}

