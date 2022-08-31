export interface IWarrantyTaxes {
    id?: number;
    Rank?:number;
    description?:string;
    warrantyId?:number;
    warranty?:string;
    taxId?:number;
    tax?:string;
    isChecked?:boolean;
}
export class WarrantyTaxes implements IWarrantyTaxes{
    constructor(
        public id?: number | 0,
        public rank?: number | 0,
        public description?: string| null,
        public warrantyId?: number | 0,
    public warranty?: string| null,
   
   public taxId?: number| 0,
   public tax?: string| null,
   public isChecked?: boolean| false,
    ) {}
   
}
export interface IWarrantyTaxesUpdate{
    id?:number;
    description?:string;
    rank?:number;
}