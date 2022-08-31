import {Component, OnDestroy, OnInit, Output, ViewChild, ViewEncapsulation} from '@angular/core';
import {Router} from '@angular/router';

import {BehaviorSubject, Subject} from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { UserViewService } from 'app/main/apps/user/user-view/user-view.service';
import {ProductViewService} from "./product-view.service";
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import {locale as german} from "../i18n/de";
import {locale as portuguese} from "../i18n/pt";
import {CoreTranslationService} from "../../../../../../@core/services/translation.service";
import Stepper from "bs-stepper";
import {IProduct} from "../model/product";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ProductDeleteDialogComponent} from "../product-delete/product-delete-dialog.component";
import {CdkDragDrop, moveItemInArray} from "@angular/cdk/drag-drop";
import {ProductWarrantiesModal} from "../model/productWarrantiesModal";
import {IProductWarranties, ProductWarranties} from "../model/productwarranties";
import {HttpResponse} from "@angular/common/http";
import {ProductShopModalComponent} from "./product-shop-modal/product-shop-modal.component";
import {ProductShopService} from "./product-shop-modal/product-shop.service";
import {ProductDurationModalComponent} from "./product-duration-modal/product-duration-modal.component";
import {ProductDurationService} from "./product-duration-modal/product-duration.service";
import {ProductFees} from "../model/productFees";


@Component({
  selector: 'app-product-view',
  templateUrl: './product-view.component.html',
  styleUrls: ['./product-view.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class ProductViewComponent implements OnInit, OnDestroy {

  // public
  isEdit = false;
   titleEditBtn="HEADER.EDIT";
  public url = this.router.url;
  public lastValue;
  public product :IProduct | null = null;
  dataProductWarranties :any;
  dataProductFees :any;
  dataProductDurations :any;
  dataProductShops :any;
  public avatar =  'assets/images/product/vehiculeAffaire.png';
  public contentHeader: object;
  private modernVerticalWizardStepper: Stepper;
  private bsStepper;
  // private
  private _unsubscribeAll: Subject<any>;
  private _unsubscribeAllProductWarranties: Subject<any>;
  private _unsubscribeAllProductDurations: Subject<any>;
  private _unsubscribeAllProductFees: Subject<any>;
  private _unsubscribeAllProductShops: Subject<any>;

  // Select Custom header footer template
  public selectProductWarranties = [];
  public selectProductWarrantiesSelected = [];
  public selectProductFees = [];
  public selectProductFeesSelected = [];



  /**
   * Modern Vertical Wizard Stepper Next
   */
  modernVerticalNext() {
    this.modernVerticalWizardStepper.next();
  }
  /**
   * Modern Vertical Wizard Stepper Previous
   */
  modernVerticalPrevious() {
    this.modernVerticalWizardStepper.previous();
  }

  /**
   * Constructor
   *
   * @param {Router} router
   * @param {UserViewService} _productViewService
   */
  constructor(private router: Router, private _productViewService: ProductViewService, private _coreTranslationService: CoreTranslationService
 , protected modalService: NgbModal ,  private _productAgencyService: ProductShopService ,  private _productDurationService: ProductDurationService) {
    this._unsubscribeAll = new Subject();
    this._unsubscribeAllProductWarranties = new Subject();
    this._unsubscribeAllProductDurations = new Subject();
    this._unsubscribeAllProductFees = new Subject();
    this._unsubscribeAllProductShops = new Subject();

    this.lastValue = this.url.substr(this.url.lastIndexOf('/') + 1);
    this._coreTranslationService.translate(english, french, german, portuguese);
  }

  // Lifecycle Hooks
  // -----------------------------------------------------------------------------------------------------
  /**
   * On init
   */
  ngOnInit(): void {

   this._productViewService.onProductViewChanged.pipe(takeUntil(this._unsubscribeAll)).subscribe(response => {
      this.product = response;
    });
    this._productViewService.onProductWarrantiesViewChanged.pipe(takeUntil(this._unsubscribeAllProductWarranties)).subscribe(responseWarranties => {
      this.dataProductWarranties  = responseWarranties;
    });
     this._productViewService.onProductDurationsViewChanged.pipe(takeUntil(this._unsubscribeAllProductDurations)).subscribe(responseDurations => {
      this.dataProductDurations  = responseDurations;
    });
    this._productViewService.onProductFeesViewChanged.pipe(takeUntil(this._unsubscribeAllProductFees)).subscribe(responseFees => {
      this.dataProductFees  = responseFees;
    });
    this._productViewService.onProductShopsViewChanged.pipe(takeUntil(this._unsubscribeAllProductShops)).subscribe(responseShops => {
      this.dataProductShops  = responseShops;
    });

    this.modernVerticalWizardStepper = new Stepper(document.querySelector('#stepper4'), {
      linear: false,
      animation: true
    });
    this.bsStepper = document.querySelectorAll('.bs-stepper');
    this.contentHeader = {
      headerTitle: 'Product',
      actionButton: false,
      breadcrumb: {
        type: '',
        links: [
          {
            name: 'Home',
            isLink: true,
            link: '/'
          },
          {
            name: 'Product',
            isLink: true,
            link: '/apps/product'
          },
          {
            name: 'Details',
            isLink: false
          }
        ]
      }
    };
  }


  /**
   * On destroy
   */
  ngOnDestroy(): void {
    // Unsubscribe from all subscriptions
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
    this._unsubscribeAllProductWarranties.next();
    this._unsubscribeAllProductWarranties.complete();
    this._unsubscribeAllProductDurations.next();
    this._unsubscribeAllProductDurations.complete();
  }

  delete(objectToDelete: any, deleteObjectType:string): void {
    const modalRef = this.modalService.open(ProductDeleteDialogComponent, {
      size: "lg",
      backdrop: "static",
    });
    modalRef.componentInstance.objectToDelete = objectToDelete;
  modalRef.componentInstance.deleteObjectType = deleteObjectType;
    // unsubscribe not needed because closed completes on modal close
    modalRef.closed.subscribe((reason) => {
      if (reason === "deleted") {
        switch(deleteObjectType) {
          case 'p': {
            this.router.navigate(['/apps/product']);
            break;
          }
          case 'pw': {
            this._productViewService
                .queryProductWarranties(this.product.productId)
                .subscribe({
                  next: (res) => {
                    this.dataProductWarranties  = res;
                  },
                  error: () => {

                  },
                });
            break;
          }
          case 'pf': {
            this._productViewService
                .queryProductFees(this.product.productId)
                .subscribe({
                  next: (res) => {
                    this.dataProductFees  = res;
                  },
                  error: () => {

                  },
                });
            break;
          }
          case 'pshop': {
            this._productViewService
                .queryProductShops(this.product.productId)
                .subscribe({
                  next: (res) => {
                    this.dataProductShops  = res;
                  },
                  error: () => {

                  },
                });
            break;
          }
          case 'pd': {
            this._productViewService
                .queryProductDurations(this.product.productId)
                .subscribe({
                  next: (res) => {
                    this.dataProductDurations  = res;
                  },
                  error: () => {

                  },
                });
            break;
          }
          default: {
            this.router.navigate(['/apps/product']);
            break;
          }
        }
      }
    });
  }
  allowUpdate() {
    if(!this.isEdit){
      this.titleEditBtn="HEADER.SHOW";
      this.isEdit=true;
    }

    else{
      this.titleEditBtn="HEADER.EDIT";
    this.isEdit=false;
    }
  }

  // #region Product warranties

  modalOpenForm(modalForm) {
    this.selectProductWarrantiesData();
    this.modalService.open(modalForm);
  }
  private selectProductWarrantiesData() {
    this._productViewService.getWarranties().subscribe(items => {
      this.selectProductWarranties = items;
      this.selectProductWarrantiesSelected =  this.dataProductWarranties.map(x => x.warrantyId);
    });
  }
  onDrop(event: CdkDragDrop<any[]>) {
    moveItemInArray(this.dataProductWarranties, event.previousIndex, event.currentIndex);
    this.dataProductWarranties.forEach((warranty, idx) => {
      warranty.rank = idx + 1;
      let productwarranties = new ProductWarranties(warranty.id, warranty.mandatory, warranty.rank);
      this._productViewService.updateProductWarrantyMandatory(productwarranties).subscribe(responseWarranties => {
      });
    });
  }
  addwarrantiesModal() {
    let productwarranties = new ProductWarrantiesModal(this.product.productId,this.selectProductWarrantiesSelected);
    this._productViewService.addProductWarranties(productwarranties).subscribe(responseWarranties => {
      this._productViewService
          .queryProductWarranties(this.product.productId)
          .subscribe({
            next: (res) => {
              this.dataProductWarranties  = res;
            },
            error: () => {

            },
          });
    });

  }
  onNgModelChange(obj: any, isChecked: boolean){
   let productwarranties = new ProductWarranties(obj.id, obj.mandatory, obj.rank);
    if(isChecked)
      productwarranties.mandatory=true;
    else productwarranties.mandatory=false;
    this._productViewService.updateProductWarrantyMandatory(productwarranties).subscribe(responseWarranties => {
    });
  }
  productWarrantiesSelectAll() {
    this.selectProductWarrantiesSelected = this.selectProductWarranties.map(x => x.warrantyId);
  }
  productWarrantiesUnselectAll() {
    this.selectProductWarrantiesSelected = [];
  }
  // #endregion

  // #region Product Fees

  modalOpenFormFees(modalForm) {
    this.selectFeesData();
    this.modalService.open(modalForm);
  }
  private selectFeesData() {
    this._productViewService.getFees().subscribe(items => {
      this.selectProductFees = items;
      this.selectProductFeesSelected =  this.dataProductFees.map(x => x.feesId);
    });
  }
  addFeesModal() {
    let productFees = { productId : this.product.productId, productFees : this.selectProductFeesSelected}

    this._productViewService.addProductFees(productFees).subscribe(responseFees => {
      this._productViewService
          .queryProductFees(this.product.productId)
          .subscribe({
            next: (res) => {
              this.dataProductFees  = res;
            },
            error: () => {
            },
          });
    });
  }
  ProductFeesSelectAll() {
    this.selectProductFeesSelected = this.selectProductFees.map(x => x.feesId);
  }
  ProductFeesUnselectAll() {
    this.selectProductFeesSelected = [];
  }
  feesLoad() {
    this._productViewService.onProductFeesViewChanged.pipe(takeUntil(this._unsubscribeAllProductFees)).subscribe(responseFees => {
      this.dataProductFees  = responseFees;
    });
  }
  onDropFee(event: CdkDragDrop<any[]>) {
    moveItemInArray(this.dataProductFees, event.previousIndex, event.currentIndex);
    this.dataProductFees.forEach((fee, idx) => {
        fee.rank = idx + 1;
      let productFees = new ProductFees(fee.id , fee.rank);
      this._productViewService.updateProductFeesRank(productFees).subscribe(responseWarranties => {
      });
    });
  }
  // #endregion


  

  // #region Product Shop
  modalOpenFormShops(product: IProduct): void {
    const modalRef = this.modalService.open(ProductShopModalComponent, {
      size: "lg",
      backdrop: "static",
    });
    modalRef.componentInstance.productId = product.productId;
    this._productAgencyService.getShops(product.productId).subscribe(items => {
      modalRef.componentInstance.dataProductShops = items.sort((a, b) => (a.isChecked? -1 : 1)) ;
      modalRef.componentInstance.dataProductShopsSelected =  modalRef.componentInstance.dataProductShops.filter(item=> item.isChecked);
      modalRef.componentInstance.tempData =   modalRef.componentInstance.dataProductShops;
    });

    // unsubscribe not needed because closed completes on modal close
    modalRef.closed.subscribe((reason) => {
      if (reason === "updateProductShops") {

        this._productViewService
            .queryProductShops(this.product.productId)
            .subscribe({
              next: (res) => {
                this.dataProductShops  = res;
              },
              error: () => {

              },
            });

      }
    });
  }

  // #endregion

  // #region Product Duration
  editProportion(productDuration: any) {
    alert('ok edit');
  }

    modalOpenFormDurations(product: IProduct,productDuration:any): void {
      const modalRef = this.modalService.open(ProductDurationModalComponent, {
        size: "lg",
        backdrop: "static",
      });
      modalRef.componentInstance.productId = product.productId;
      modalRef.componentInstance.productDurationId = productDuration?.id;
      this._productDurationService.getProductDurationById(productDuration?.id).subscribe(item => {
        modalRef.componentInstance.titleModal =item.duration;
        modalRef.componentInstance.dataProductDuration =item;
        modalRef.componentInstance.dataProductDurationsProportions = item.proportions.sort((a, b) => (a.isChecked? -1 : 1)) ;
        modalRef.componentInstance.dataProductDurationsProportionsSelected =  modalRef.componentInstance.dataProductDurationsProportions.filter(item=> item.isChecked);
        modalRef.componentInstance.tempData =   modalRef.componentInstance.dataProductDurationsProportions;
      });

      // unsubscribe not needed because closed completes on modal close
      modalRef.closed.subscribe((reason) => {
        if (reason === "updateProductDurations") {
          this._productViewService
              .queryProductDurations(this.product.productId)
              .subscribe({
                next: (res) => {
                  this.dataProductDurations  = res;
                },
                error: () => {

                },
              });

        }
      });
    }

  // #endregion
}
