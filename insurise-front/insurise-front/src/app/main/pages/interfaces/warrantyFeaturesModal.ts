export interface IWarrantyFeaturesModal {

    warrantyId: number;
    warrantyFeatures?: number[];
}

export class WarrantyFeaturesModal implements IWarrantyFeaturesModal {

    constructor(
        public warrantyId: number | 0,
        public warrantyFeatures?:  number[] | null
    ) {
    }


}