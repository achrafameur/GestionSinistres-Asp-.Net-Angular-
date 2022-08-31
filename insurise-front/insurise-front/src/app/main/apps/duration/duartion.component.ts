import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { DuartionService } from './duartion.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-duartion',
  templateUrl: './duartion.component.html',
  styleUrls: ['./duartion.component.scss']
})
export class DuartionComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public tempData: any;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  public contentHeader : object ;
  columns = [ 
    {name: 'Id', prop: 'durationId'},
    {name: 'Title', prop: 'title'},
    {name: 'Type', prop: 'type'},
    {name: 'Value', prop: 'value'},
    {name: 'Coefficient', prop: 'coefficient'},
    {name: 'Start Date', prop: 'startDate'},
    {name: 'End Date', prop: 'endDate'},
    {name: 'Renewable', prop: 'renewable'},
    {name: 'Actions', prop: 'durationId'} 
  ];
  // decorator
  @ViewChild(DatatableComponent) table: DatatableComponent;
  constructor(private durationService : DuartionService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService)
  {
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.durationService.getDurations().subscribe((data)=>{
      this.kitchenSinkRows=data
      this.tempData=this.kitchenSinkRows
    })
    this.contentHeader = {
      headerTitle: 'Duration',
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
                  name: 'Duration',
                  isLink: true,
                  link: '/apps/duration/list'
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
    this.durationService.DeleteDuration(value).subscribe(()=>{
      this.durationService.getDurations().subscribe((data)=>{
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
