import { Component, OnInit, ViewChild } from '@angular/core';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { ThirdCompanyService } from '../third-company/third-company.service';
import { ThirdPartyService } from './third-party.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

@Component({
  selector: 'app-third-party',
  templateUrl: './third-party.component.html',
  styleUrls: ['./third-party.component.scss']
})
export class ThirdPartyComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  tempData: any;
  public contentHeader : object ; 

  columns = [ 
    {name: 'Id', prop: 'tiersId'},
    {name: 'Title', prop: 'title'},
    {name: 'Libelle', prop: 'libele'},
    {name: 'Description', prop: 'description'},
    {name: 'Matricule Fiscale', prop: 'matriculeFiscale'},
    {name: 'Phone', prop: 'phone'},
    {name: 'Fax', prop: 'fax'},
    {name: 'Email', prop: 'email'},
    {name: 'Company', prop: 'tiersCompany'},
    {name: 'Actions', prop: 'tiersId'} 
  ];
  // decorator
  @ViewChild(DatatableComponent) table: DatatableComponent;
  
  constructor(private router:Router,private thirdPartyService:ThirdPartyService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.thirdPartyService.getThirds().subscribe(
      (data)=>
        {
          this.kitchenSinkRows=data;
          this.tempData=this.kitchenSinkRows
        }
    )
    this.contentHeader = {
      headerTitle: 'ThirdParty',
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
                  name: 'ThirdParty',
                  isLink: true,
                  link: '/apps/third-party/list'
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
    this.thirdPartyService.DeleteThirdParty(value).subscribe(()=>{
      this.thirdPartyService.getThirds().subscribe(
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
