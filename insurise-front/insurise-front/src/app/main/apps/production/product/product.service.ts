import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders, HttpResponse} from '@angular/common/http';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';

import { BehaviorSubject, Observable } from 'rxjs';
import {IProduct} from "./model/product";
import {ApplicationConfigService} from "../../config/application-config.service";
import {createRequestOption} from "../../core/request/request-util";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  observe: 'response' as 'response'
};
const headers= new HttpHeaders()
    .set('content-type', 'application/json')
    .set('Access-Control-Allow-Origin', '*').append( "Access-Control-Expose-Headers", "X-Total-Count") ;
export type EntityResponseType = HttpResponse<IProduct>;
export type EntityArrayResponseType = HttpResponse<IProduct[]>;
@Injectable({
  providedIn: 'root' // just before your class
})
export class ProductService  {
  protected productsUrl =this.applicationConfigService.getEndpointFor("/product");


  /**
   * Constructor
   *
   * @param {HttpClient} _httpClient
   */
  constructor(private _httpClient: HttpClient,
              protected applicationConfigService: ApplicationConfigService
  ) {}

  query(req?: any): Observable<EntityArrayResponseType> {
    const options = createRequestOption(req);

    return this._httpClient.get<IProduct[]>(this.productsUrl, {
      params: options,
      observe: "response",
    });

  }

  find(id: number): Observable<EntityResponseType> {
    return this._httpClient.get<IProduct>(`${this.productsUrl}/${id}`, {
      observe: "response",
    });
  }

  delete(objectToDelete: any,deleteObjectType:string): Observable<HttpResponse<{}>> {
    let id=0;
    let  url='' ;
    switch(deleteObjectType) {
      case 'p': {
        id=objectToDelete.productId;
        url=`${this.productsUrl}/${id}`;
        break;
      }
      case 'pw': {
        id=objectToDelete.id;
        url = `${this.productsUrl}/DeleteProductWarrantyById/${id}/${objectToDelete.productId}`;
        break;
      }
      case 'pf': {
        id=objectToDelete.id;
        url = `${this.productsUrl}/DeleteProductFeeById/${id}/${objectToDelete.productId}`;
        break;
      }
      case 'pshop': {
        id=objectToDelete.id;
        url = `${this.productsUrl}/DeleteProductShopById/${id}`;
        break;
      }
      case 'pd': {
        id=objectToDelete.id;
        url = `${this.productsUrl}/DeleteProductDuration/${id}`;
        break;
      }

      default: {
        id=objectToDelete.productId;
        url=`${this.productsUrl}/${id}`;
        break;
      }
    }
    return this._httpClient.delete(url, {
      observe: "response",
    });
  }
}
