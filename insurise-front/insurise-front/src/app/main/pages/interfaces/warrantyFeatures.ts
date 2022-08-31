export interface IWarrantyFeatures {
    id?: number;
    mandatory?: boolean;
    rank?:number;
    featureId?: number;
    feature?: string;
    warrantyId?: number;
    warranty?: string;
    isChecked? : boolean;
}
export class WarrantyFeatures implements IWarrantyFeatures{
    constructor(
 public   id?: number|0,
 public  mandatory?: boolean|false,
 public  rank?: number|0,
 public  featureId?: number|0,
 public  feature?: string|null,
 public  warrantyId?: number|0,
 public  warranty?: string|null,
 public  isChecked?: boolean|false){}
}
export class WarrantyFeaturesModal {
    constructor(
        public WarrantyId : number|0,
        public warrantyFeatures?: number[]|null
    ){}
}
export interface IWarrantyFeatureUpdate{
    id?:number;
    mandatory?:boolean;
    rank?:number;
}