import { Component, OnInit } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ThirdCompanyService } from './third-company.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-third-company',
  templateUrl: './third-company.component.html',
  styleUrls: ['./third-company.component.scss']
})
export class ThirdCompanyComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  tempData: any;
  public contentHeader : object ; 

  columns = [ 
    {name: 'Id', prop: 'tiersCompanyId'},
    {name: 'Libelle', prop: 'libele'},
    {name: 'Description', prop: 'description'},
    {name: 'Matricule Fiscale', prop: 'matriculeFiscale'},
    {name: 'Phone', prop: 'phone'},
    {name: 'Fax', prop: 'fax'},
    {name: 'Email', prop: 'email'},
    {name: 'Adress', prop: 'adress'},
    {name: 'Actions', prop: 'tiersCompanyId'} 
  ];
  constructor(private thirdCompanyService:ThirdCompanyService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.thirdCompanyService.getThirdPartyCompanies().subscribe((data)=>{
      this.kitchenSinkRows=data
      this.tempData=this.kitchenSinkRows
    })
    this.contentHeader = {
      headerTitle: 'ThirdCompany',
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
                  name: 'ThirdCompany',
                  isLink: true,
                  link: '/apps/third-company/list'
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
    this.thirdCompanyService.DeleteThirdPartyCompany(value).subscribe(()=>{
      this.thirdCompanyService.getThirdPartyCompanies().subscribe((data)=>{
        // window.location.reload();
        this.kitchenSinkRows=data
        
      })
    })
  }

  filterUpdate(event){
    const val = event.target.value;
    this.kitchenSinkRows = this.tempData.filter(function (d) {
      return d.label.toLowerCase().indexOf(val.toLowerCase()) !== -1 || !val.toLowerCase();
  });
  }

  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }

}
