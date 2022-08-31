import { DatePipe } from '@angular/common';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { AverageCostService } from './average-cost.service';
import { CoreTranslationService } from '@core/services/translation.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-average-cost',
  templateUrl: './average-cost.component.html',
  styleUrls: ['./average-cost.component.scss']
})
export class AverageCostComponent implements OnInit {

  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public tempData: any;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  public contentHeader : object ; 

  columns = [ 
    {name: 'Id', prop: 'avgCostId'},
    {name: 'average Cost', prop: 'averageCost'},
    {name: 'Start Date', prop: 'startDate'},
    {name: 'End Date', prop: 'endDate'},
    {name: 'Sinister Nature Id', prop: 'sinisterNature'},
    {name: 'Actions', prop: 'avgCostId'} 
  ];

  // decorator
  @ViewChild(DatatableComponent) table: DatatableComponent;
  constructor(private averageCostService : AverageCostService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.averageCostService.getAverageCosts().subscribe(
      (data)=>
        {
          this.kitchenSinkRows=data;
          this.tempData=this.kitchenSinkRows
          console.log(this.tempData)
        }
    )

    this.contentHeader = {
      headerTitle: 'SinisterNatureAverageCost',
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
                  name: 'SinisterNatureAverageCost',
                  isLink: true,
                  link: '/apps/average-cost/list'
              },
              {
                  name: 'List',
                  isLink: false
              }
          ]
      }
  };
  }

  delete(value){
    this.averageCostService.DeleteAverageCost(value).subscribe(()=>{
      this.averageCostService.getAverageCosts().subscribe(
        (data)=>
          {
            // window.location.reload();
            this.kitchenSinkRows=data;
          }
      )
    })  
    }

     
  filterUpdate(event){
    const val = event.target.value.toLowerCase();
    this.kitchenSinkRows = this.tempData.filter(function (d) {
      return d.sinisterNature.toLowerCase().indexOf(val) !== -1 || !val;
  });
  }

  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }
}
