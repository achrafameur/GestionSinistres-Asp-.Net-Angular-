export interface IWarrantyCommissionsModal {

    warrantyId: number;
    warrantyCommissions?: number[];
}

export class WarrantyCommissionsModal implements IWarrantyCommissionsModal {

    constructor(
        public warrantyId: number | 0,
        public warrantyCommissions?:  number[] | null
    ) {
    }


}