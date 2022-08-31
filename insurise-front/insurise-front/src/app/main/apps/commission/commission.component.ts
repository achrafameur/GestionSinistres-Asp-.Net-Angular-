import { Component, OnInit } from '@angular/core';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ICommission } from 'app/main/pages/interfaces/commission';
import { CommissionService } from './commission.service';
import { locale as English } from './i18n/en';
import { locale as Francais } from './i18n/fr';

@Component({
  selector: 'app-commission',
  templateUrl: './commission.component.html',
  styleUrls: ['./commission.component.scss']
})
export class CommissionComponent implements OnInit {
  public contentHeader: object;
  public commissions:ICommission[]; 
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
    {name :"Id", prop : 'commissionId'},
    {name :"Value", prop : 'value'},
    {name : "Actions",prop : 'commissionId'}
  ]
  constructor(private commissionService:CommissionService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }
  ngOnInit(): void {
    this.commissionService.loadCommissions().subscribe({next:(result) => {
      this.kitchenSinkRows = result;
      this.tempData = result;
    },
    error: (err) => {
      console.log(err);
  }})
  this.contentHeader = {
    headerTitle: 'Commission',
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
                name: 'Commission',
                isLink: true,
                link: '/apps/commission/list'
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
    this.commissionService.deleteCommission(value).subscribe(()=>{
      this.commissionService.loadCommissions().subscribe({next:(result) => {
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
    console.log(this.tempData)
    this.kitchenSinkRows = this.tempData.filter(function (d) {
      return d.value.indexOf(val) !== -1 || !val;
  });
  }
  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }

}
