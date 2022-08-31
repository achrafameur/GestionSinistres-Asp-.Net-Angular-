import {IProduct} from "../../production/product/model/product";


export interface IBranch {
  id?: number;
  title?: string;
  description?: string | null;
  parentId?: number;
  products?: IProduct[] | null;
}

export class  Branch implements IBranch {
  constructor(
    public id?: number,
    public title?: string,
    public description?: string | null,
    public parentId?: number,
    public products?: IProduct[] | null
  ) {}
}

export function getBranchIdentifier(
    Branch: IBranch
): number | undefined {
  return Branch.id;
}
