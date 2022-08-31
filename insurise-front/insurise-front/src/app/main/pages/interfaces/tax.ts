export interface ITax {
    taxId?:number;
    title?:string| null;
    description?:string| null;
    coefficient:number;
    constant:number;
    isChecked : boolean;
}

export class Tax implements ITax{
    taxId?: number;
    title?: string;
    description?: string;
    coefficient: number;
    constant: number;
    isChecked : boolean;
}