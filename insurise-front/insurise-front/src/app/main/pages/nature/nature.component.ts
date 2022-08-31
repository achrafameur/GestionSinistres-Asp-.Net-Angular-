import { Component, OnInit } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { Nature } from 'app/main/pages/interfaces/nature';
import { NatureService } from './nature.service';
import { locale as English } from './i18n/en';
import { locale as Francais } from './i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-nature',
  templateUrl: './nature.component.html',
  styleUrls: ['./nature.component.scss']
})
export class NatureComponent implements OnInit {
  public contentHeader: object;
  public natures:Nature[]; 
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
    {name :"Id", prop : 'id'},
    {name :"Title", prop : 'title'},
    {name:"IsList",prop : 'isList'},
    {name : "Actions",prop : 'id'}
  ]
  constructor(private natureService:NatureService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }

  
  ngOnInit(): void {
    this.natureService.loadNatures().subscribe({next:(result) => {
      this.kitchenSinkRows = result;
      this.tempData = result;
    },
    error: (err) => {
      console.log(err);
  }})
  this.contentHeader = {
    headerTitle: 'Nature',
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
                name: 'Nature',
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
  onDelete (value){
    this.natureService.deleteNature(value).subscribe(()=>{
      this.natureService.loadNatures().subscribe({next:(result) => {
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
