import { IFeatureItems } from "./featureItems";

export interface FeatureDto{

    featureId: number,
    title: string,
    description?: string,
    symbol?: string,
    fixed?: number,
    minimum?: number,
    maximum?: number,
     alterable: boolean,
    isPrincipal: boolean,
    rankShow?: number,
    nature: string,
    chain?:string,
    natureId: number,
    chainId?: number,
    featureItems?:IFeatureItems[]| null;
    isChecked : boolean;
  
    
   
}