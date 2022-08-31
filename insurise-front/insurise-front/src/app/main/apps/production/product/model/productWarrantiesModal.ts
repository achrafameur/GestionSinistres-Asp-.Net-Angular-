
export interface IProductWarrantiesModal {

    productId: number;
    productWarranties?: number[];
}

export class ProductWarrantiesModal implements IProductWarrantiesModal {

    constructor(
        public productId: number | 0,
        public productWarranties?:  number[] | null
    ) {
    }


}