import { IQuotationWarranties } from "./QuotationWarranties";

export interface IQuotation {
    quotationId? : number;
    reference : string;
    startDate?: string | null;
    endDate?:string| null;
    isValid? : boolean;
    shopId?: number| null;
    shop?:string| null;
    productId?: number| null;
    product?:string| null;
    branchId?: number| null;
    branch?:string| null;
    durationId?: number| null;
    duration?:string| null;
    clientId?: number| null;
    client?:string| null;
    statusId?: number| null;
    status?:string| null;
    inscription?: string | null;
    validationDate?: string | null;
    userId?: number| null;
    user?:string| null;
    quotationWarranties? : IQuotationWarranties[]| null;
}
export class Quotation implements IQuotation{
    quotationId?: number;
    reference: string;
    startDate?: string;
    endDate?: string;
    isValid?: boolean;
    shopId?: number;
    shop?: string;
    productId?: number;
    product?: string;
    branchId?: number;
    branch?: string;
    durationId?: number;
    duration?: string;
    clientId?: number;
    client?: string;
    statusId?: number;
    status?: string;
    inscription?: string;
    validationDate?: string;
    userId?: number;
    user?: string;
    quotationWarranties?: IQuotationWarranties[];

}