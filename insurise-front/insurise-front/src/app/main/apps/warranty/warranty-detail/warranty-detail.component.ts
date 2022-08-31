



import { Component, OnDestroy, OnInit, ViewEncapsulation } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';

import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

import { UserViewService } from 'app/main/apps/user/user-view/user-view.service';
import { locale as english  } from '../i18n/en';
import { locale as frensh } from '../i18n/fr';


import { CoreTranslationService } from '@core/services/translation.service';
import Stepper from "bs-stepper";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import { ProductDeleteDialogComponent } from '../../production/product/product-delete/product-delete-dialog.component';
import { IWarranty, Warranty } from 'app/main/pages/interfaces/warranty';
import { WarrantyService } from '../warranty.service';
import { IWarrantyProducts } from 'app/main/pages/interfaces/warrantyProducts';
import { IWarrantyFeatures, WarrantyFeatures, WarrantyFeaturesModal } from 'app/main/pages/interfaces/warrantyFeatures';
import { IWarrantyTaxes, WarrantyTaxes } from 'app/main/pages/interfaces/warrantyTaxes';
import { CdkDragDrop } from '@angular/cdk/drag-drop/drag-events';
import { moveItemInArray } from '@angular/cdk/drag-drop';
import { IWarrantyCommissions, WarrantyCommissions } from 'app/main/pages/interfaces/warrantyCommissions';
import { WarrantyTaxesModal } from 'app/main/pages/interfaces/warrantyTaxesModal';
import { WarrantyCommissionsModal } from 'app/main/pages/interfaces/warrantyCommissionsModal';
@Component({
  selector: 'app-warranty-detail',
 templateUrl: './warranty-detail.component.html',
   styleUrls: ['./warranty-detail.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class WarrantyDetailComponent implements OnInit, OnDestroy {
  // public
  isEdit = false;
  titleEditBtn="HEADER.EDIT";
  public url = this.router.url;
  public lastValue;
  public warranty :IWarranty | null = null;
  dataWarrantyFeatures :any;
  dataWarrantyTaxes :any;
  dataWarrantyCommissions :any;
  dataWarrantyProducts :any;


  public productsList : IWarrantyProducts[];
  public featureList :IWarrantyFeatures[];
  public taxeList : IWarrantyTaxes[];
  public commissionList:IWarrantyCommissions[];
  
  public avatar =  'assets/images/product/vehiculeAffaire.png';
  public contentHeader: object;
  private modernVerticalWizardStepper: Stepper;
  private bsStepper;


  
  // private
  private _unsubscribeAll: Subject<any>;
  private _unsubscribeAllWarrantyFeatures: Subject<any>;
  private _unsubscribeAllWarrantyTaxes: Subject<any>;
  private _unsubscribeAllWarrantyCommissions: Subject<any>;
  private _unsubscribeAllWarrantyProducts: Subject<any>;

  public selectWarrantyProducts = [];
  public selectWarrantyProductsSelected = [];
  public selectWarrantyFeatures = [];
  public selectWarrantyFeaturesSelected = [];
  public selectWarrantyTaxes = [];
  public selectWarrantyTaxesSelected = [];
  public selectWarrantyCommissions = [];
  public selectWarrantyCommissionsSelected = [];
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
   * Modern Vertical Wizard Stepper Previous
   */
  loadProportions(id) {
alert(id);
  }
  /**
   * Constructor
   *
   * @param {Router} router
   * @param {UserViewService} _productViewService
   */
  constructor(private router: Router, private _warrantyService: WarrantyService, private _coreTranslationService: CoreTranslationService
 , protected modalService: NgbModal ,private activatedroute: ActivatedRoute,) {
    this._unsubscribeAll = new Subject();
    this._unsubscribeAllWarrantyFeatures = new Subject();
    this._unsubscribeAllWarrantyTaxes = new Subject();
    this._unsubscribeAllWarrantyCommissions=new Subject();
    this._unsubscribeAllWarrantyProducts=new Subject();
    this.lastValue = this.url.substr(this.url.lastIndexOf('/') + 1);
    this._coreTranslationService.translate(english, frensh);
  }
  

  // Lifecycle Hooks
  // -----------------------------------------------------------------------------------------------------
  /**
   * On init
   */
  ngOnInit(): void {
    /* this.activatedRoute.data.subscribe(({ product }) => {
      this.product = product;
    });*/
    const id = this.activatedroute.snapshot.params.id;
     
    this._warrantyService.loadWarrantyById(id).subscribe((data) => {
            this.warranty = data;
            console.log(data);
          });
          this._warrantyService.getFeaturesByWarrantyId(id).subscribe((data)=>{
            this.featureList= data;
            console.log(this.featureList);
          })
          this._warrantyService.getTaxesByWarrantyId(id).subscribe((data)=>{
            this.taxeList= data;
            console.log(this.taxeList);
          })
          this._warrantyService.getCommissionsByWarrantyId(id).subscribe((data)=>{
            this.commissionList= data;
            console.log(this.commissionList);
          })
          this._warrantyService.getProductsByWarrantyId(id).subscribe({next:(data)=>{
            this.productsList=data;
            console.log(this.productsList);
          },
          error: (err) => {
           console.log(err);
         }})
   this._warrantyService.onWarrantyViewChanged.pipe(takeUntil(this._unsubscribeAll)).subscribe(response => {
      this.warranty = response;
      console.log( this.warranty)
    });
    this._warrantyService.onWarrantyFeaturesViewChanged.pipe(takeUntil(this._unsubscribeAllWarrantyFeatures)).subscribe(responseFeatures => {
      this.dataWarrantyFeatures  = responseFeatures;
      console.log( this.dataWarrantyFeatures)
    });
     this._warrantyService.onWarrantyTaxesViewChanged.pipe(takeUntil(this._unsubscribeAllWarrantyTaxes)).subscribe(responseTaxes => {
      this.dataWarrantyTaxes  = responseTaxes;
      console.log(this.dataWarrantyTaxes)
    });

    this._warrantyService.onWarrantyCommissionsViewChanged.pipe(takeUntil(this._unsubscribeAllWarrantyCommissions)).subscribe(responseCommissions => {
      this.dataWarrantyCommissions  = responseCommissions;
      console.log(this.dataWarrantyCommissions)
    });
    this._warrantyService.onWarrantyProductsViewChanged.pipe(takeUntil(this._unsubscribeAllWarrantyProducts)).subscribe(responseProducts => {
      this.dataWarrantyProducts  = responseProducts;
      console.log(this.dataWarrantyProducts)
    });
    this.modernVerticalWizardStepper = new Stepper(document.querySelector('#stepper4'), {
      linear: false,
      animation: true
    });
    this.bsStepper = document.querySelectorAll('.bs-stepper');
    this.contentHeader = {
      headerTitle: 'Warranty',
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
            name: 'Warranty',
            isLink: true,
            link: '/apps/warranty/list'
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
    this._unsubscribeAllWarrantyFeatures.next();
    this._unsubscribeAllWarrantyFeatures.complete();
    this._unsubscribeAllWarrantyCommissions.next();
    this._unsubscribeAllWarrantyCommissions.complete();
    this._unsubscribeAllWarrantyTaxes.next();
    this._unsubscribeAllWarrantyTaxes.complete();
    this._unsubscribeAllWarrantyProducts.next();
    this._unsubscribeAllWarrantyProducts.complete();
  }
  onDelete(value:number){
    this._warrantyService.deleteWarranty(value).subscribe(()=>{
      this.router.navigate(["/apps/warranty/list"])
    }
    )
  }
  
 
  delete(objectToDelete: any, deleteObjectType:string): void {
    const modalRef = this.modalService.open(ProductDeleteDialogComponent, {
      size: "lg",
      backdrop: "static",
    });
    modalRef.componentInstance.objectToDelete = objectToDelete;
  modalRef.componentInstance.deleteObjectType = deleteObjectType;
    modalRef.closed.subscribe((reason) => {
      if (reason === "deleted") {
        switch(deleteObjectType) {
          case 'p': {
            this.router.navigate(['/apps/warranty']);
            break;
          }
          case 'wf': {
            this._warrantyService
                .getFeaturesByWarrantyId(this.warranty.warrantyId)
                .subscribe({
                  next: (res) => {
                    this.featureList  = res;
                  },
                  error: () => {

                  },
                });
            break;
          }
          case 'wt': {
            this._warrantyService
                .getTaxesByWarrantyId(this.warranty.warrantyId)
                .subscribe({
                  next: (res) => {
                    this.taxeList  = res;
                  },
                  error: () => {

                  },
                });
            break;
          }
          case 'wc': {
            this._warrantyService
                .getCommissionsByWarrantyId(this.warranty.warrantyId)
                .subscribe({
                  next: (res) => {
                    this.commissionList  = res;
                  },
                  error: () => {

                  },
                });
            break;
          }
       
          default: {
            this.router.navigate(['/apps/warranty']);
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
  modalOpenForm(modalForm) {
    this.selectWarrantyFeaturesData();
    this.modalService.open(modalForm);
  }
  // selectbasic
  private selectWarrantyFeaturesData() {
    this._warrantyService.loadFeatures().subscribe(items => {
      this.selectWarrantyFeatures = items;
      this.selectWarrantyFeaturesSelected =  this.featureList.map(x => x.featureId);
    });
  }
  // onDrop(event: CdkDragDrop<any[]>) {
  //   moveItemInArray(this.featureList, event.previousIndex, event.currentIndex);
  //   this.featureList.forEach((feature, idx) => {
  //     feature.rank = idx + 1;
  //     let warrantyFeatures = new WarrantyFeatures(feature.id, feature.mandatory, feature.rank);
  //     this._warrantyService.updateWarrantyFeature(warrantyFeatures).subscribe(responseWarranties => {
  //     });
  //   });
  // }
  addFeaturesModal() {
    let warrantyFeatures = new WarrantyFeaturesModal(this.warranty.warrantyId,this.selectWarrantyFeaturesSelected);
    this._warrantyService.setWarrantyFeatures(warrantyFeatures).subscribe(responseWarranties => {
      this._warrantyService
          .getFeaturesByWarrantyId(this.warranty.warrantyId)
          .subscribe({
            next: (res) => {
              this.featureList  = res;
            },
            error: () => {

            },
          });
    });

  }
  onNgModelChange(obj: any, isChecked: boolean){
   let warrantyFeatures = new WarrantyFeatures(obj.id, obj.mandatory, obj.rank);
    if(isChecked)
    warrantyFeatures.mandatory=true;
    else warrantyFeatures.mandatory=false;
    this._warrantyService.updateWarrantyFeature(warrantyFeatures).subscribe(responseWarranties => {
    });
  }
  warrantyFeaturesSelectAll() {
    this.selectWarrantyFeaturesSelected = this.selectWarrantyFeatures.map(x => x.warrantyId);
  }
  warrantyFeaturesUnselectAll() {
    this.selectWarrantyFeaturesSelected = [];
  }
  //#region feature-end

  modalOpenFormTaxes(modalForm) {
    this.selectWarrantyTaxesData();
    this.modalService.open(modalForm);
  }
  private selectWarrantyTaxesData() {
    this._warrantyService.loadTaxes().subscribe(items => {
      this.selectWarrantyTaxes = items;
      this.selectWarrantyTaxesSelected =  this.taxeList.map(x => x.taxId);
    });
  }

  addTaxesModal() {
    let warrantyTaxes = new WarrantyTaxesModal(this.warranty.warrantyId,this.selectWarrantyTaxesSelected);
    this._warrantyService.setWarrantyTaxes(warrantyTaxes).subscribe(responseWarranties => {
      this._warrantyService
          .getTaxesByWarrantyId(this.warranty.warrantyId)
          .subscribe({
            next: (res) => {
              this.taxeList  = res;
              console.log(this.taxeList)
            },
            error: () => {

            },
          });
    });

  }
  WarrantyTaxesSelectAll() {
    this.selectWarrantyTaxesSelected = this.selectWarrantyTaxes.map(x => x.taxId);
  }
  WarrantyTaxesUnselectAll() {
    this.selectWarrantyTaxesSelected = [];
  }

  TaxesLoad() {
    this._warrantyService.onWarrantyTaxesViewChanged.pipe(takeUntil(this._unsubscribeAllWarrantyTaxes)).subscribe(responseTaxes => {
      this.dataWarrantyTaxes  = responseTaxes;
    });
  }
  onDropTaxes(event: CdkDragDrop<any[]>) {
    moveItemInArray(this.dataWarrantyTaxes, event.previousIndex, event.currentIndex);
    this.dataWarrantyTaxes.forEach((tax, idx) => {
      tax.rank = idx + 1;
      let warrantyTaxes = new WarrantyTaxes(tax.id, tax.description, tax.rank);
      warrantyTaxes.description=tax.description;
      this._warrantyService.updateWarrantytaxes(warrantyTaxes).subscribe(responseWarranties => {
      });
    });
  }

  //#region  commissions
  modalOpenFormCommissions(modalForm) {
    this.selectWarrantyCommissionsData();
    this.modalService.open(modalForm);
  }
 
  private selectWarrantyCommissionsData() {
    this._warrantyService.loadCommissions().subscribe(items => {
      this.selectWarrantyCommissions = items;
      this.selectWarrantyCommissionsSelected =  this.commissionList.map(x => x.commissionId);
    });
  }
  onDropCommissions(event: CdkDragDrop<any[]>) {
    moveItemInArray(this.dataWarrantyCommissions, event.previousIndex, event.currentIndex);
    this.dataWarrantyCommissions.forEach((commission, idx) => {
    commission.rank =idx +1;
      let warrantyCommissions = new WarrantyCommissions(commission.id, commission.codeAgence, commission.libelleAgence,commission.description);
      this._warrantyService.updateWarrantyCommissions(warrantyCommissions).subscribe(responseWarranties => {
      });
    });
  }
  addCommissionsModal() {
    let warrantyCommissions = new WarrantyCommissionsModal(this.warranty.warrantyId,this.selectWarrantyCommissionsSelected);
    this._warrantyService.setWarrantyCommissions(warrantyCommissions).subscribe(responseWarranties => {
      this._warrantyService
          .getCommissionsByWarrantyId(this.warranty.warrantyId)
          .subscribe({
            next: (res) => {
              this.commissionList  = res;
              console.log(this.commissionList);
            },
            error: () => {

            },
          });
    });

  }
  // onNgModelChangeCommissions(obj: any,value1,value2){
  //  let warrantyCommissions = new WarrantyCommissions(obj.id, obj.codeAgence, obj.libelleAgence);
  

  //  warrantyCommissions.codeAgence=value1;
  //  warrantyCommissions.libelleAgence=value2;
  //   this._warrantyService.updateWarrantyCommissions(warrantyCommissions).subscribe(responseWarranties => {
  //   });
  // }
  WarrantyCommissionsSelectAll() {
    this.selectWarrantyCommissionsSelected = this.selectWarrantyCommissions.map(x => x.warrantyId);
  }
  WarrantyCommissionsUnselectAll() {
    this.selectWarrantyCommissionsSelected = [];
  }

 }

 


// import { Component, OnInit } from '@angular/core';
// import { ActivatedRoute } from '@angular/router';
// import { IWarranty } from 'app/main/pages/interfaces/warranty';
// import { WarrantyService } from '../warranty.service';
// import { locale as English } from '../i18n/en';
// import { locale as Francais } from '../i18n/fr';
// import { CoreTranslationService } from '@core/services/translation.service';
// import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
// import { IWarrantyProducts } from 'app/main/pages/interfaces/warrantyProducts';

// @Component({
//   selector: 'app-warranty-detail',
//   templateUrl: './warranty-detail.component.html',
//   styleUrls: ['./warranty-detail.component.scss'],
// })
// export class WarrantyDetailComponent implements OnInit {
//   warranty: IWarranty;
//   public contentHeader: object;
//   public productsList : IWarrantyProducts[];

//   constructor(
//     private warrantyService: WarrantyService,
//     private activatedroute: ActivatedRoute,
//     private _coreTranslationService: CoreTranslationService,
//     private modalService: NgbModal
//   ) {
//     this._coreTranslationService.translate(English,Francais)
//   }

//   ngOnInit(): void {
//     const id = this.activatedroute.snapshot.params.id;
//    this.warrantyService.getProductsByWarrantyId(id).subscribe({next:(data)=>{
//      this.productsList=data;
//      console.log(this.productsList);
//    },
//    error: (err) => {
//     console.log(err);
//   }})
//     this.warrantyService.loadWarrantyById(id).subscribe((data) => {
//       this.warrantyService.getFeaturesByWarrantyId(id).subscribe((data) => {
//         this.warranty.warrantyFeatures = data;
//         console.log(data);
//         this.warrantyService.getTaxesByWarrantyId(id).subscribe((data)=>{
//           this.warranty.warrantyTaxes=data;
//           console.log(this.warranty.warrantyTaxes);
       
//         })
        
//       });
//       this.warranty = data;
//       console.log(data);
//     });
    

//     this.contentHeader = {
//       headerTitle: 'Warranty',
//       actionButton: false,
//       breadcrumb: {
//         type: '',
//         links: [
//           {
//             name: 'Home',
//             isLink: true,
//             link: '/',
//           },
//           {
//             name: 'Warranty',
//             isLink: true,
//             link: '/apps/warranty/list',
//           },
//           {
//             name: 'Detail',
//             isLink: false,
//           },
//         ],
//       },
//     };
//   }
//   // modal Basic
//   modalOpen(modalBasic) {
//     this.modalService.open(modalBasic);
//   }
// }
