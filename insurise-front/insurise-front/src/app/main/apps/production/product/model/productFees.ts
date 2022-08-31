/* Defines the product entity */

import {IProductWarrantiesModal} from "./productWarrantiesModal";

export interface IProductFees {
    id?: number;
    rank?:number;
    product?: string| null;
    productId?: number| 0;
    fees?: string| null;
    feesId?: number| 0;
}
export class  ProductFees  implements IProductFees {
    constructor(
        public id?: number | 0,
        public rank?: number | 0,
        public productId?: number | 0,
        public product?: string| null,
        public fees?: string| null,
        public feesId?: number | 0
    ) {}
}