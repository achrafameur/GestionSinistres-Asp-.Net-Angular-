import { Component, OnInit, ViewChild } from '@angular/core';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { IQuotation } from 'app/main/pages/interfaces/quotation';
import { QuotationService } from './quotation.service';
import { locale as English } from './i18n/en';
import { locale as Francais } from './i18n/fr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-quotation',
  templateUrl: './quotation.component.html',
  styleUrls: ['./quotation.component.scss']
})
export class QuotationComponent implements OnInit {

   // Private
   private tempData = [];
  
   // public
   public contentHeader: object;
   public rows: any;
   public selected = [];
   public kitchenSinkRows: any;
   public selectedOption = 10;
   public ColumnMode = ColumnMode;
   public SelectionType = SelectionType;
   readonly headerHeight = 50;
   readonly rowHeight = 50;
   readonly pageLimit = 10;
   readonly footerHeight = 50;
   pageTitle = 'Quotation List';
   public temp = [];
   public searchValue = '';
   ShowHide: boolean = false;
   warranties?: IQuotation[];

   columns = [
    {name :"Id", prop : 'quotationId'},
    {name :"Reference", prop : 'reference'},
     {name : "Validation Date",prop :'validationDate'},
     {name : "Shop",prop :'shop'},
    {name : "Product",prop :'product'},
    {name : "Client",prop :'client'},
    {name : "User",prop :'user'},
    // {name : "EndDate",prop :'endDate'},
    //  {name : "AlterendDateable",prop :'EndDate'},
    // {name : "defaultPeriod",prop :'DefaultPeriod'},
    //  {name : "Rate",prop :'isCommercialRate'},
    // {name : "Tarif",prop :'typeTarif'},
    {name : "Actions",prop : 'quotationId'}
  ]
   
   @ViewChild(DatatableComponent) table: DatatableComponent;


  constructor(private quotationService :QuotationService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    this.quotationService.loadQuotation().subscribe({next:(result) => {
      console.log(result);
      this.kitchenSinkRows = result;
      this.tempData = result;
    },
    error: (err) => {
      console.log(err);
  }})
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
                name: 'Warranty',
                isLink: true,
                link: '/apps/quotation/list'
            },
            {
                name: 'List',
                isLink: false
            }
        ]
    }
};
  }
  onDelete(value:number){
    this.quotationService.deleteQuotation(value).subscribe(()=>{
      this.quotationService.loadQuotation().subscribe({next:(result) => {
        this.kitchenSinkRows = result;
      },
      error: (err) => {
        console.log(err);
    }})
    }
    
    )
  }

  filterUpdate(event){
    const val = event.target.value;
    this.kitchenSinkRows = this.tempData.filter(function (d) {
      return d.reference.toLowerCase().indexOf(val.toLowerCase()) !== -1 || !val.toLowerCase();
  });
  }
  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }

}
