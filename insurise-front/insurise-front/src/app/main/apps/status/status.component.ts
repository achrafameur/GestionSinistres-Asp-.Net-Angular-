import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { StatusService } from './status.service';
import { CoreTranslationService } from '@core/services/translation.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.scss']
})
export class StatusComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public tempData: any;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  public contentHeader : object ; 

  columns = [ 
    {name: 'Id', prop: 'statusId'},
    {name: 'Title', prop: 'title'},
    {name: 'Symbol', prop: 'symbol'},
    {name: 'Item Id', prop: 'item'},
    {name: 'Actions', prop: 'statusId'} 
  ];
  // decorator
  @ViewChild(DatatableComponent) table: DatatableComponent;
  constructor(private statusService : StatusService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.statusService.getStatus().subscribe(
      (data)=>
        {
          this.kitchenSinkRows=data;
          this.tempData=this.kitchenSinkRows
        }
    )
    this.contentHeader = {
      headerTitle: 'Status',
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
                  name: 'Status',
                  isLink: true,
                  link: '/apps/Status/list'
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
    this.statusService.DeleteStatus(value).subscribe(()=>{
      this.statusService.getStatus().subscribe(
        (data)=>
          {
            // window.location.reload();
            this.kitchenSinkRows=data;
            
          }
      )
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
