import { EnumType } from "typescript";
import { IWarrantyCommissions } from "./warrantyCommissions";
import { IWarrantyFeatures } from "./warrantyFeatures";
import { IWarrantyTaxes } from "./warrantyTaxes";


 export enum TypeTarif{
    Prorata,
    Totale
}
export interface IWarranty{
    warrantyId?: number;
    title?: string| null;
    symbol?:string;
    description?: string| null;
    createdDate?:Date;
    startDate?: string | null;
    endDate?:string| null;
    defaultPeriod?:number| null;
    isCommercialRate?:Boolean;
    typeTarif?:TypeTarif;
    warrantyFeatures?:IWarrantyFeatures[]| null;
    warrantyTaxes?:IWarrantyTaxes[]|null;
    warrantyCommissions?:IWarrantyCommissions[]|null;



}

export class Warranty implements IWarranty {
    warrantyId?: number;
    title?: string;
    arabTitle?: string;
    symbol: string;
    description?: string;
    createdDate?: Date;
    endDate?: string;
    startDate?: string;
    defaultPeriod?: number;
    isCommercialRate?: Boolean;
    typeTarif?: TypeTarif;
    warrantyFeatures?: IWarrantyFeatures[];
    warrantyTaxes?:IWarrantyTaxes[];
    warrantyCommissions?:IWarrantyCommissions[];
    }



