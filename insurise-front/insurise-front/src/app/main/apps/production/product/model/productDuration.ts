interface IDurationProportion {
    id: number;
    proportionId: number;
    proportion: string;
    durationId: number;
    duration: string;
    title: string;
    actif: boolean;
    isChecked?: boolean| false;
}

/* Defines the product entity */
export interface IProductDuration {
    id: number;
    productId: number;
    product: string;
    durationId: number;
    duration: string;
    rank:number;
    proportions:[IDurationProportion];
    isChecked?: boolean| false;

}
