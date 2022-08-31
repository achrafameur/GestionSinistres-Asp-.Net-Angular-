import {HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from '@angular/router';

import {BehaviorSubject, Observable, throwError} from 'rxjs';
import {IProduct} from '../model/product';
import {ApplicationConfigService} from '../../../config/application-config.service';

export type EntityResponseType = HttpResponse<IProduct>;
export type EntityArrayResponseType = HttpResponse<IProduct[]>;

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable({
    providedIn: 'root' // just before your class
})
export class ProductUpdateService implements Resolve<any> {
    // Public
    apiData: any;
    public onProductAddChanged: BehaviorSubject<any>;
    public rowsBranch: any;
    public onProductBranchViewChanged: BehaviorSubject<any>;
    protected productsUrl = this.applicationConfigService.getEndpointFor('/product');
    protected branchUrl = this.applicationConfigService.getEndpointFor('/branch');

    /**
     * Constructor
     *
     * @param {HttpClient} _httpClient
     */
    constructor(private _httpClient: HttpClient, protected applicationConfigService: ApplicationConfigService) {
        // Set the defaults
        this.onProductAddChanged = new BehaviorSubject({});
        this.onProductBranchViewChanged = new BehaviorSubject({});
    }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<any> | Promise<any> | any {
        return new Promise<void>((resolve, reject) => {
            Promise.all([this.getProductBranchRows()]).then(() => {
                resolve();
            }, reject);
        });
    }


    addProduct(product: IProduct): Observable<EntityResponseType> {

        return this._httpClient.post<IProduct>(this.productsUrl, product, {
            observe: 'response',
        });
    }

    updateProduct(product: IProduct): Observable<EntityResponseType> {
        // const url = `${this.productsUrl}/Update/${getProductIdentifier(product) as number}`;
        const url = `${this.productsUrl}/Update`;
        return this._httpClient.put<IProduct>(
            this.productsUrl,
            product,
            {observe: 'response'}
        );
    }

    /**
     * Get  Product Warranties Rows
     */
    getProductBranchRows(): Promise<any[]> {
        const url = `${this.branchUrl}/all`;
        this.productsUrl;
        return new Promise((resolve, reject) => {
            this._httpClient.get(url).subscribe((response: any) => {
                this.rowsBranch = response;
                this.onProductBranchViewChanged.next(this.rowsBranch);
                resolve(this.rowsBranch);
            }, reject);
        });
    }

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
    }
}
