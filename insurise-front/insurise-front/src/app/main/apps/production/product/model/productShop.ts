/* Defines the product entity */

import {IProductWarrantiesModal} from "./productWarrantiesModal";

export interface IProductShops {
    id?: number;
    reduction?:number|0;
    defaultProduct?:number;
    product?: string| null;
    productId?: number| 0;
    shop?: string| null;
    shopId?: number| 0;
    shopCode?: string| null;
    isChecked?: boolean| false;
}
export class  ProductShops  implements IProductShops {
    constructor(
        public id?: number | 0,
        public reduction?: number | 0,
        public defaultProduct?: number | 0,
        public productId?: number | 0,
        public product?: string| null,
        public shop ?: string| null,
        public shopId?: number | 0,
        public shopCode ?: string| null,
        public isChecked?: boolean |false
    ) {}
}