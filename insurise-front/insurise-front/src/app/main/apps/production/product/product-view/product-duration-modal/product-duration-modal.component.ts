import {Component, ViewChild, ViewEncapsulation} from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";
import {ColumnMode, DatatableComponent, SelectionType} from '@swimlane/ngx-datatable'; 
import {ITEMS_PER_PAGE} from "../../../../config/pagination.constants";
import {Router} from "@angular/router";
import {ProductDurationService} from "./product-duration.service";


@Component({
  selector: 'product-duration-modal',
  templateUrl: './product-duration-modal.component.html',
  styleUrls: ['./product-duration-modal.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ProductDurationModalComponent {

  editingReduction = {};
  dataProductDuration : any;
  tempData = [];
  dataProductDurationsProportions: any;
  dataProductDurationsProportionsSelected: any;
  ColumnMode = ColumnMode;
  SelectionType = SelectionType;
  itemsPerPage = ITEMS_PER_PAGE;
  productId: number;
  durationId: number;
  productDurationId: number;
  titleModal :string="";
  @ViewChild(DatatableComponent) table: DatatableComponent;
  editing: any;

  public selectDurations = [];
  public selectedDurations: any = [];
  isEdit = false;
  isAdd = false;
  isSaving = false;

  constructor(private router: Router,
              protected _productDurationService: ProductDurationService,
    protected activeModal: NgbActiveModal
  ) {
  }
  ngOnInit() {
    if(this.productDurationId==undefined){
      this.isEdit = false;
      this.isAdd = true;
      this._productDurationService.getExceptDurationByProductId(this.productId).subscribe((data)=>{
        this.selectDurations=data;
      })
    }else{
      this.isEdit = true;
      this.isAdd = false;
      this. isSaving = true;
    }

  }
  cancel(): void {
    this.activeModal.dismiss();
  }

  onSelect({ selected }) {
    if(selected!=undefined){
    this.dataProductDurationsProportionsSelected.splice(0, this.dataProductDurationsProportionsSelected.length);
    this.dataProductDurationsProportionsSelected.push(...selected);
    }
  }

  onActivate(event) {
    //console.log('Activate Event', event);
  }


  filterUpdate(event) {

    const val = event.target.value.toLowerCase();
    // filter our data
    // update the rows
    this.dataProductDurationsProportions = this.tempData.filter(function (d) {
      return d.proportion.toLowerCase().indexOf(val) !== -1 || !val;
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
    this.dataProductDurationsProportions[rowIndex][cell] = event.target.value;
  }

  gotoDurationDetails(id) {
    this.activeModal.close("updateProductDurations");
    const url = `'/apps/Duration/Duration-view/${id}`;
    this.router.navigate([url]);
  }

  confirm(dataProductDuration: any,dataProductDurationsProportionsSelected: any) {
    if(dataProductDuration.id==0){
      dataProductDuration.productId=this.productId;
      dataProductDuration.durationId=this.durationId;
    }
    this._productDurationService.updateProductDurations(dataProductDuration,dataProductDurationsProportionsSelected).subscribe(() => {
      this.activeModal.close("updateProductDurations");
    });
  }


  filterByDuration(event) {
    if(event!=undefined) {
      this.durationId = event.durationId;
      this.isSaving = true;
    }else {
      this.isSaving = false;
    }
  }
  
}
