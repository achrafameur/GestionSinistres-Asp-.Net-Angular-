import { Component, OnInit } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { Proportion } from '../interfaces/proportion';
import { ProportionService } from './proportion.service';
import { locale as English } from './i18n/en';
import { locale as Francais } from './i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-proportion',
  templateUrl: './proportion.component.html',
  styleUrls: ['./proportion.component.scss']
})
export class ProportionComponent implements OnInit {
 public proportions : Proportion[];
 public contentHeader: object;

 public ColumnMode = ColumnMode;
 public kitchenSinkRows: any;
 public basicSelectedOption: number = 10;
 public SelectionType = SelectionType;
 readonly headerHeight = 50;
 readonly rowHeight = 50;
 readonly pageLimit = 10;
 readonly footerHeight = 50;
 public selectedOption = 10;
 public rows: any;
 public tempData : any;

 columns = [
   {name :"Id", prop : 'proportionId'},
   {name :"Title", prop : 'title'},
   {name :"Occurence", prop : 'occurence'},
   {name :"AdditionalCosts", prop : 'additionalCosts'},
   {name : "Actions",prop : 'proportionId'}
 ]
  constructor(private proportionService:ProportionService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    this.proportionService.loadProportions().subscribe({next:(result) => {
      this.kitchenSinkRows = result;
      this.tempData = result;
      
    },
    error: (err) => {
      console.log(err);
  }})
  this.contentHeader = {
    headerTitle: 'Proportion',
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
                name: 'Proportion',
                isLink: true,
                link: '/apps/proportion/list'
            },
            {
                name: 'List',
                isLink: false
            }
        ]
    }
};
  }

  onDelete (value){
    this.proportionService.deleteProportion(value).subscribe(()=>{
      this.proportionService.loadProportions().subscribe({next:(result) => {
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
