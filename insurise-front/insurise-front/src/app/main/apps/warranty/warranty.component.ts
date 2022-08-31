



import { Component, OnInit, ViewChild } from '@angular/core';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { IWarranty } from 'app/main/pages/interfaces/warranty';
import { WarrantyService } from './warranty.service';
import { locale as English } from './i18n/en';
import { locale as Francais } from './i18n/fr';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-warranty',
  templateUrl: './warranty.component.html',
  styleUrls: ['./warranty.component.scss']
})
export class WarrantyComponent implements OnInit {
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
   public exportCSVData;
   readonly headerHeight = 50;
   readonly rowHeight = 50;
   readonly pageLimit = 10;
   readonly footerHeight = 50;
   pageTitle = 'Warranty List';
   public temp = [];
   public searchValue = '';
   ShowHide: boolean = false;
   warranties?: IWarranty[];

   columns = [
    {name :"Id", prop : 'warrantyId'},
    {name :"Title", prop : 'title'},
    // {name : "ArabTitle",prop :'arabTitle'},
    // {name : "Symbol",prop :'symbole'},
    {name : "Description",prop :'description'},
    {name : "CreatedDate",prop :'createdDate'},
    {name : "StartDate",prop :'startDate'},
    {name : "EndDate",prop :'endDate'},
    // {name : "AlterendDateable",prop :'EndDate'},
    // {name : "defaultPeriod",prop :'DefaultPeriod'},
    // {name : "Rate",prop :'isCommercialRate'},
    // {name : "Tarif",prop :'typeTarif'},
    {name : "Actions",prop : 'warrantyId'}
  ]
   
   @ViewChild(DatatableComponent) table: DatatableComponent;


  constructor(private warrantyService :WarrantyService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }

  ngOnInit(): void {
    this.warrantyService.loadWarranties().subscribe({next:(result) => {
      console.log(result);
      this.kitchenSinkRows = result;
      this.tempData = result;
    },
    error: (err) => {
      console.log(err);
  }})
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
                name: 'List',
                isLink: false
            }
        ]
    }
};
  }
  onDelete(value:number){
    this.warrantyService.deleteWarranty(value).subscribe(()=>{
      this.warrantyService.loadWarranties().subscribe({next:(result) => {
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
      return d.title.toLowerCase().indexOf(val.toLowerCase()) !== -1 || !val.toLowerCase();
  });
  }


  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }

}
