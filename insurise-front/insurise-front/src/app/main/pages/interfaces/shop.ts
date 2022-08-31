import { ProductShops } from "app/main/apps/production/product/model/productShop";

export enum ShopType{
    Succursale,
    Agent_Générale,
    Courtier
}
export interface IShop{

    id: number,
    title: string,
    type?: ShopType,
    Code?: string,
    Description?: string,
    DepartmentId?: number,
    listProduct?: ProductShops[],
}