/* Defines the product entity */
import {IProductWarranties} from './productwarranties';
import {IProductDuration} from "./productDuration";
import {IProductShops} from "./productShop";
import {IProductFees} from "./productFees";

export interface IProduct {
    productId?: number;
    title?: string | null;
    description?: string | null;
    branch?: string;
    branchId?: number;
    code?: string | null;
    startDate?: string | null;
    expirationDate?: string | null;
    creationDate?: Date;
    createdBy?: string | null;
    certificateId?: number;
    defaultDiscount?: number | 0;
    image?: string | null;
    fileName?: string | null;
    productWarranties?: IProductWarranties[] | null;
    productShops?: IProductShops[] | null;
    productFess?: IProductFees[] | null;
    productDurations?: IProductDuration[] | null;
}

export class Product implements IProduct {
    constructor(
        public title?: string | null,
        public description?: string | null,
        public branch?: string,
        public branchId?: number,
        public code?: string | null,
        public startDate?: string | null,
        public expirationDate?: string | null,
        public certificateId?: number | 0,
        public defaultDiscount?: number | 0,
        public image?: string | null,
        public fileName?: string | null,
        public productWarranties?: IProductWarranties[],
        public productShops?: IProductShops[],
        public productFess?: IProductFees[],
        public productDurations?: IProductDuration[],
    ) {
    }

}

