import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IQuotation } from 'app/main/pages/interfaces/quotation';
import { IQuotationWarranties } from 'app/main/pages/interfaces/QuotationWarranties';
import { IWarranty } from 'app/main/pages/interfaces/warranty';
import { BranchService } from '../../branch/branch.service';
import { IBranch } from '../../branch/model/IBranch';
import { IProduct } from '../../production/product/model/product';
import { QuotationService } from '../quotation.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-quotation-detail',
  templateUrl: './quotation-detail.component.html',
  styleUrls: ['./quotation-detail.component.scss']
})
export class QuotationDetailComponent implements OnInit {
  public contentHeader : object ; 
  public id:any;
  public warrantyId:any ;
  public warrantyIds:any ;
  public QWarranties = [] ;
public selectedQuotation : IQuotation ;
public branchList : IBranch[];
public productList :IProduct[];
public filtredProductList : IProduct[];
public durationList :any[];
public warrantyList : IWarranty[];
public quotationWarranties : IQuotationWarranties[];
  constructor(private router : Router , private ar : ActivatedRoute,private quotationService : QuotationService, private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.quotationService.loadQuotationById(this.id).subscribe((data)=>{
      this.selectedQuotation = data;
      console.log(this.selectedQuotation)

    })
    this.quotationService.loadBranches().subscribe((data)=>{
      this.branchList = data;
      console.log(this.branchList)
    })
    this.quotationService.loadProducts().subscribe((data)=>{
      this.productList = data;
      console.log(this.productList)
    })
    this.quotationService.getDurations().subscribe((data)=>{
      this.durationList = data;
      console.log(this.durationList)
    })
    this.quotationService.loadWarranties().subscribe((data)=>{
      this.warrantyList = data;
      console.log(this.durationList)
    })
    this.quotationService.getWarrantiesByQuotationId(this.id).subscribe((data)=>{
      this.quotationWarranties = data;
      console.log(this.quotationWarranties)

    });
    
    
    this.contentHeader = {
      headerTitle: 'Quotation',
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
                  name: 'Quotation',
                  isLink: true,
                  link: '/apps/quotation/list'
              },
              {
                  name: 'details',
                  isLink: false
              }
          ]
      }
    };
  }
  attachWarranties(QuotationWarranty:NgForm){
    this.warrantyId=this.warrantyList.filter(x=>x.isChecked==true).map(x=>x.warrantyId).toString();
    console.log(this.warrantyId)
    this.warrantyIds=this.warrantyId.split(',');
    console.log(this.warrantyIds)
   
    this.quotationService.setQuotationWarranty(this.warrantyIds,this.id).subscribe(()=>{
      window.location.reload();
    })
  }

 

  modalOpenProductForm(modalForm) {
    this.modalService.open(modalForm);
  }
  modalOpenDurationForm(modalForm) {
    this.modalService.open(modalForm);
  }

  modalOpenWarrantiesForm(modalForm) {
    this.modalService.open(modalForm);
  }
  attachStartDateAndDuration (quotation1:NgForm){
    this.quotationService.updateQuotation(quotation1.value,this.selectedQuotation.quotationId).subscribe({ 
      next:() => {
        console.log(quotation1)
        window.location.reload();

    },
  error:(error) => {
    console.log(error); 
  }}); }
  attachBranchAndProduct (quotation:NgForm){
    this.quotationService.updateQuotation(quotation.value,this.selectedQuotation.quotationId).subscribe({ 
      next:() => {
        console.log(quotation)
        window.location.reload();

    },
  error:(error) => {
    console.log(error); 
  }}); }

  modalBranchAndProductOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }
  onChangeWarranty(){
    console.log(this.warrantyList)
  }
  selected(){
    console.log(this.selectedQuotation.branchId);
    this.filtredProductList = this.productList.filter(x=>x.branchId ==this.selectedQuotation.branchId);
    console.log(this.filtredProductList)
  }
  
}
