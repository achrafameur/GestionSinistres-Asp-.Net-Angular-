import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { TaxService } from './tax.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-tax',
  templateUrl: './tax.component.html',
  styleUrls: ['./tax.component.scss']
})
export class TaxComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public tempData: any;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  public contentHeader : object ;
  columns = [ 
    {name: 'Id', prop: 'taxId'},
    {name: 'Title', prop: 'title'},
    {name: 'Coefficient', prop: 'coefficient'},
    {name: 'Constant', prop: 'constant'},
    {name: 'Actions', prop: 'taxId'} 
  ];
  @ViewChild(DatatableComponent) table: DatatableComponent;
  constructor(private taxService : TaxService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.taxService.getTaxes().subscribe((data)=>{
      this.kitchenSinkRows=data
      this.tempData=this.kitchenSinkRows
    })
    this.contentHeader = {
      headerTitle: 'Tax',
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
                  name: 'Tax',
                  isLink: true,
                  link: '/apps/tax/list'
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
    this.taxService.DeleteTax(value).subscribe(()=>{
      this.taxService.getTaxes().subscribe((data)=>{
        window.location.reload();
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
