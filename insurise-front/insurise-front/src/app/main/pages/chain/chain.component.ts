import { Component, OnInit } from '@angular/core';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { Autoplay } from 'swiper';
import { ChainDto } from '../interfaces/chain';
import { ChainService } from './chain.service';
import { locale as English } from './i18n/en';
import { locale as Francais } from './i18n/fr';

@Component({
  selector: 'app-chain',
  templateUrl: './chain.component.html',
  styleUrls: ['./chain.component.scss']
})
export class ChainComponent implements OnInit {
  public chains:ChainDto[];
  public contentHeader: object;
public rows: any;
public selected = [];
public kitchenSinkRows: any;
public selectedOption = 10;
public ColumnMode = ColumnMode;
public expanded = {};
public editingName = {};
public editingStatus = {};
public editingAge = {};
public editingSalary = {};
public chkBoxSelected = [];
public SelectionType = SelectionType;
public exportCSVData;
public tempData : any;

readonly headerHeight = 50;
readonly rowHeight = Autoplay;
readonly pageLimit = 10;
readonly footerHeight = 50;


  columns = [
    {name :"Id", prop : 'chainId'},
    {name :"Title", prop : 'title'},
    {name : "Elements",prop :'elements'},
    {name : "Actions",prop : 'chainId'}
  ]
  constructor(private chainService: ChainService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
   
    this.chainService.loadChains().subscribe({next:(result) => {
      console.log(result);
      this.rows=result;
      this.tempData = result;
    },
    error: (err) => {
      console.log(err);
  }})
  this.contentHeader = {
    headerTitle: 'Chain',
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
                name: 'Chain',
                isLink: true,
                link: '/apps/chain/list'
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
    this.chainService.deleteChain(value).subscribe(()=>{
      this.chainService.loadChains().subscribe({next:(result) => {
        this.kitchenSinkRows = result;
        // window.location.reload()
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
