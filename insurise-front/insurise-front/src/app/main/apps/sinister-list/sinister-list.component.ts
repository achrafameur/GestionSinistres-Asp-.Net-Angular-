import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { SinisterDeclarationService } from '../sinister-declaration/sinister-declaration.service';
import { CoreTranslationService } from '@core/services/translation.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-sinister-list',
  templateUrl: './sinister-list.component.html',
  styleUrls: ['./sinister-list.component.scss']
})
export class SinisterListComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public tempData: any;
  public selectedOption = 10;
  public contentHeader : object ; 

  columns = [
    {name: 'Sinister Binder Id', prop: 'sinisterBinderId'}, 
    {name: 'Sinister Date', prop: 'sinisterDate'},
    {name: 'Sinister Place', prop: 'sinisterPlace'},
    {name: 'Policy Number', prop: 'policyNumber'},
    {name: 'Insured Name', prop: 'insuredName'},
    {name: 'Insured Object', prop: 'insuredObject'},
    {name: 'Description', prop: 'description'},
    {name: 'Creation Date', prop: 'createdDate'},
    {name: 'Actions', prop: 'sinisterBinderId'} 
  ];
  // decorator
  @ViewChild(DatatableComponent) table: DatatableComponent;
  constructor(private SinisterDeclarationService : SinisterDeclarationService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.SinisterDeclarationService.getSinisterBinders().subscribe((data)=>{
      this.kitchenSinkRows=data
      this.tempData=this.kitchenSinkRows
    })
    this.contentHeader = {
      headerTitle: 'Sinister Binders',
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
                  name: 'Sinister Binders',
                  isLink: true,
                  link: '/apps/SinisterBinders/all'
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
    this.SinisterDeclarationService.DeleteSinisterBinder(value).subscribe(()=>{
      this.SinisterDeclarationService.getSinisterBinders().subscribe((data)=>{
        // window.location.reload();
        this.kitchenSinkRows=data
        
      })
    })
  }

  filterUpdate(event){
    const val = event.target.value.toLowerCase();
    this.kitchenSinkRows = this.tempData.filter(function (d) {
      return d.insuredName.toLowerCase().indexOf(val) !== -1 || !val;
    });
  }

  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }
}
