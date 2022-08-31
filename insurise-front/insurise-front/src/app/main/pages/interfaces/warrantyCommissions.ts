export interface IWarrantyCommissions{
    id?:number;
    description?:string;
    codeAgence?:number;
    libelleAgence?:string;
    commissionId?:number;
    commission?:number;
    warrantyId?:number;
    warranty?:string;
    isChecked?:boolean;
}
export class WarrantyCommissions implements IWarrantyCommissions{
    constructor(
     public id?:number| 0,
     public  description?:string| null,
     public codeAgence?:number| 0,
     public libelleAgence?:string| null,
     public commissionId?:number| 0,
     public  commission?:number| 0,
     public warrantyId?:number| 0,
     public warranty?:string| null,
     public  isChecked?:boolean| false,

    ){}
}

export interface IWarrantyCommissionsUpdate{
    id?:number;
    rank?:number;
    codeAgence?:number;
    libelleAgence?:string;
   
}