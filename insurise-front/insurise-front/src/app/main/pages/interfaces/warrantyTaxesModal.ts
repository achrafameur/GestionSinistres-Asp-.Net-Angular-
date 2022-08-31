export interface IWarrantyTaxesModal {

    warrantyId: number;
    warrantyTaxes?: number[];
}

export class WarrantyTaxesModal implements IWarrantyTaxesModal {

    constructor(
        public warrantyId: number | 0,
        public warrantyTaxes?:  number[] | null
    ) {
    }


}