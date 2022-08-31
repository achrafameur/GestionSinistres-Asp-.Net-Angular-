import { IFeatureItems } from "./featureItems";

export interface Item {
    id:number;
    title:string;
    featureItems?:IFeatureItems[]| null;
    isChecked : boolean;
}
