import { Component, OnInit, ViewChild } from '@angular/core';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { FeesService } from './fees.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";

@Component({
  selector: 'app-fees',
  templateUrl: './fees.component.html',
  styleUrls: ['./fees.component.scss']
})
export class FeesComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public tempData: any;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  public contentHeader : object ;
  columns = [ 
    {name: 'Id', prop: 'feesId'},
    {name: 'Title', prop: 'title'},
    {name: 'Symbol', prop: 'symbol'},
    {name: 'Equation', prop: 'equation'},
    {name: 'description', prop: 'description'},
    {name: 'Type', prop: 'type'},
    {name: 'Creation Date', prop: 'created_date'},
    {name: 'Actions', prop: 'feesId'} 
  ];
  @ViewChild(DatatableComponent) table: DatatableComponent;

  constructor(private FeesService : FeesService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  {
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.FeesService.getFees().subscribe((data)=>{
      this.kitchenSinkRows=data
      this.tempData=this.kitchenSinkRows
    })
    this.contentHeader = {
      headerTitle: 'Fee',
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
                  name: 'Fee',
                  isLink: true,
                  link: '/apps/fees/list'
              },
              {
                  name: 'list',
                  isLink: false
              }
          ]
      }
  };
  }

  delete(value){
    this.FeesService.DeleteFee(value).subscribe(()=>{
      this.FeesService.getFees().subscribe((data)=>{
        // window.location.reload();
        this.kitchenSinkRows=data
        
      })
    })
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
