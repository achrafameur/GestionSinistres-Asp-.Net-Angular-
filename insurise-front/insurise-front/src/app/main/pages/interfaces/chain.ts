import {  ChainElement } from "./chainElement";

export interface ChainDto {
    chainId:number;
    title : string;
    elements :  ChainElement[]
}
export class chain implements ChainDto{
    chainId: number;
    title: string;
    elements: ChainElement[] |[];
}