import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IClient } from 'app/main/pages/interfaces/client';
import { apiUrl } from 'app/main/pages/interfaces/config';
import { IQuotation } from 'app/main/pages/interfaces/quotation';
import { IQuotationWarranties, QuotationWarrantiesModal } from 'app/main/pages/interfaces/QuotationWarranties';
import { IShop } from 'app/main/pages/interfaces/shop';
import { IWarranty } from 'app/main/pages/interfaces/warranty';
import { Observable } from 'rxjs';
import { IProduct } from '../production/product/model/product';

@Injectable({
  providedIn: 'root'
})
export class QuotationService {

  constructor(private http : HttpClient) { }
  loadQuotation(){
    return this.http.get<IQuotation[]>(`${apiUrl}/Quotation/all`); 
  }
  loadQuotationById(id:number):Observable<IQuotation>{
    return this.http.get<IQuotation>(`${apiUrl}/Quotation/${id}`);
  }
  addQuotation(data:IQuotation):Observable<IQuotation>{
    return this.http.post<IQuotation>(`${apiUrl}/Quotation`,data)
  }
  deleteQuotation(id:number){
    return this.http.delete(`${apiUrl}/Quotation/${id}`)
  }
  updateQuotation(quotation,id):Observable<any>{
    return this.http.put(`${apiUrl}/Quotation`,{
      quotationId: id,
      startDate: quotation.startDate,
      endDate: quotation.endDate,
      isValid: quotation.isValid,
      shopId: quotation.shopId,
      productId: quotation.productId,
      branchId: quotation.branchId,
      durationId: quotation.durationId,
      clientId: quotation.clientId,
      statusId:quotation.statusId,
      inscription: quotation.inscription,
      validationDate: quotation.validationDate,
      userId:quotation.userId,
    });

  }
  setQuotationWarranty(quotationWarranties:any, id ){
    return this.http.post(`${apiUrl}/Quotation/setWarranties`,{
      quotationId : id,
      quotationWarranties : quotationWarranties
    })
  }
  loadClientById(id:number):Observable<IClient>{
    return this.http.get<IClient>(`${apiUrl}/Client/${id}`);
  }
  addClient(data:IQuotation):Observable<IClient>{
    return this.http.post<IClient>(`${apiUrl}/Client`,data)
  }
  loadClients(){
    return this.http.get<IClient[]>(`${apiUrl}/Client/all`); 
  }
  loadShops(){
    return this.http.get<IShop[]>(`${apiUrl}/Shop/all`); 
  }
  loadShopById(id:number):Observable<IShop>{
    return this.http.get<IShop>(`${apiUrl}/Shop/${id}`);
  }
 loadBranches(): Observable<any> {
    return this.http.get(`${apiUrl}/Branch/all`);
  }
  loadProducts(){
    return this.http.get<IProduct[]>(`${apiUrl}/Product`); 
  }
  getDurations(): Observable<any> {
    return this.http.get(`${apiUrl}/Duration/all`);
  }
  loadWarranties(): Observable<any>{
    return this.http.get<IWarranty[]>(`${apiUrl}/Warranty/all`);
  }
  getWarrantiesByQuotationId(id:number){
    return this.http.get<IQuotationWarranties[]>(`${apiUrl}/Quotation/GetWarrantiesByQuotationId/${id}`)
  }

}
