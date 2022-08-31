import { Component } from "@angular/core";
import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap"; 
import {ProductService} from "../product.service";



@Component({
  templateUrl: "./product-delete-dialog.component.html",
})
export class ProductDeleteDialogComponent {
  objectToDelete?: any;
  deleteObjectType?:string;
  constructor(
    protected productService: ProductService,
    protected activeModal: NgbActiveModal
  ) {}

  cancel(): void {
    this.activeModal.dismiss();
  }

  confirmDelete(objectToDelete : any,deleteObjectType:string): void {
    this.productService.delete(objectToDelete,deleteObjectType).subscribe(() => {
      this.activeModal.close("deleted");
    });
  }
}
