export interface IQuotationWarranties {
    id?: number;
    mandatory?: boolean;
    rank?:number;
    quotationId?: number;
    quotation?: string;
    warrantyId?: number;
    warranty?: string;
    isChecked? : boolean;
}
export class QuotationWarranties implements IQuotationWarranties{
    constructor(
        public   id?: number|0,
 public  mandatory?: boolean|false,
 public  rank?: number|0,
 public  quotationId?: number|0,
 public  quotation?: string|null,
 public  warrantyId?: number|0,
 public  warranty?: string|null,
 public  isChecked?: boolean|false
    ){}
}
export class QuotationWarrantiesModal {
    constructor(
        public quotationId : number|0,
        public quotationWarranties?: number[]|null
    ){}
}
