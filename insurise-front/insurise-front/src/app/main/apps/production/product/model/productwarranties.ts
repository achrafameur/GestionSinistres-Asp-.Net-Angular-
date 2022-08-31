/* Defines the product entity */

import {IProductWarrantiesModal} from "./productWarrantiesModal";

export interface IProductWarranties {
    id?: number;
    mandatory?: boolean;
    rank?:number;
    product?: string| null;
    productId?: number| 0;
    warranty?: string| null;
    warrantyId?: number| 0;
}
export class ProductWarranties  implements IProductWarranties {

    constructor(
        public id?: number | 0,
        public mandatory?: boolean| false,
        public rank?: number | 0,
        public productId?: number | 0,
        public product?: string| null,
        public warranty?: string| null,
        public warrantyId?: number | 0
    ) {}
}
export class ProductWarrantiesModal   {

    constructor(
        public productId: number | 0,
        public productWarranties?:  number[] | null
    ) {
    }


}