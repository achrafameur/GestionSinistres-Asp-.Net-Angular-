import {Component, ViewChild, ViewEncapsulation} from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import {ColumnMode, DatatableComponent, SelectionType} from '@swimlane/ngx-datatable';
import {ProductShopService} from "./product-shop.service";
import {ITEMS_PER_PAGE} from "../../../../config/pagination.constants";
import {Router} from "@angular/router";


@Component({
  selector: 'product-shop-modal',
  templateUrl: './product-shop-modal.component.html',
  styleUrls: ['./product-shop-modal.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ProductShopModalComponent {

  editingReduction = {};
  dataProductShops: any;
  tempData = [];
  dataProductShopsSelected: any;
  ColumnMode = ColumnMode;
  SelectionType = SelectionType;
  itemsPerPage = ITEMS_PER_PAGE;
  productId: number;
  @ViewChild(DatatableComponent) table: DatatableComponent;
  editing: any;
  constructor(private router: Router,
              protected _productAgencyService: ProductShopService,
    protected activeModal: NgbActiveModal
  ) {
  }

  cancel(): void {
    this.activeModal.dismiss();
  }

  confirm(productId : number,dataProductShopsSelected:any): void {
    this._productAgencyService.updateProductShops(productId,dataProductShopsSelected).subscribe(() => {
      this.activeModal.close("updateProductShops");
    });
  }

  onSelect({ selected }) {
    if(selected!=undefined){
    this.dataProductShopsSelected.splice(0, this.dataProductShopsSelected.length);
    this.dataProductShopsSelected.push(...selected);
    }
  }

  onActivate(event) {
    //console.log('Activate Event', event);
  }


  filterUpdate(event) {

    const val = event.target.value.toLowerCase();
    // filter our data
    // update the rows
    this.dataProductShops = this.tempData.filter(function (d) {
      return d.shop.toLowerCase().indexOf(val) !== -1 || !val;
    });
    // Whenever the filter changes, always go back to the first page
    this.table.offset = 0;
  }

  /**
   * Inline editing Age
   *
   * @param event
   * @param cell
   * @param rowIndex
   */
  inlineEditingUpdateReduction(event, cell, rowIndex) {
    this.editingReduction[rowIndex + '-' + cell] = false;
    this.dataProductShops[rowIndex][cell] = event.target.value;
    //this.dataProductShops = [...this.dataProductShops];
  }

  gotoShopDetails(id) {
    this.activeModal.close("updateProductShops");
    const url = `'/apps/Shop/Shop-view/${id}`;
    this.router.navigate([url]);
  }
}
