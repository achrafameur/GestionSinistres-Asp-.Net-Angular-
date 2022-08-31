import { Component, OnInit } from '@angular/core';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ExpertService } from './expert.service';
import { CoreTranslationService } from '@core/services/translation.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-expert',
  templateUrl: './expert.component.html',
  styleUrls: ['./expert.component.scss']
})
export class ExpertComponent implements OnInit {
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public tempData: any;
  // public selectedOption = 10;
  public contentHeader : object ; 

  columns = [ 
    {name: 'Id', prop: 'expertId'},
    {name: 'Expert Type ', prop: 'typeExpert'},
    {name: 'Code', prop: 'code'},
    {name: 'First Name', prop: 'fName'},
    {name: 'Last Name', prop: 'lName'},
    {name: 'CIN', prop: 'cin'},
    {name: 'Email', prop: 'email'},
    {name: 'Birth Date', prop: 'birthDate'},
    {name: 'Sex', prop: 'sexId'},
    {name: 'Phone', prop: 'tel'},
    {name: 'Fixe', prop: 'fixe'},
    {name: 'Fax', prop: 'fax'},
    {name: 'Governorate', prop: 'gouvernerat'},
    {name: 'Adress', prop: 'adresse'},
    {name: 'Cancellation Date', prop: 'cancellationDate'},
    {name: 'Registration Date', prop: 'registrationDate'},
    {name: 'Taux', prop: 'taux'},
    {name: 'Actions', prop: 'expertId'} 
  ];
  constructor( private expertService : ExpertService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.expertService.getExperts().subscribe((data)=>{
      this.kitchenSinkRows=data
      this.tempData=this.kitchenSinkRows
    })

    this.contentHeader = {
      headerTitle: 'Expert',
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
                  name: 'Expert',
                  isLink: true,
                  link: '/apps/expert/list'
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
    this.expertService.DeleteExpert(value).subscribe(()=>{
      this.expertService.getExperts().subscribe((data)=>{
        // window.location.reload();
        this.kitchenSinkRows=data
        
      })
    })
  }

  filterUpdate(event){
    const val = event.target.value.toLowerCase();
    this.kitchenSinkRows = this.tempData.filter(function (d) {
      return d.fName.toLowerCase().indexOf(val.toLowerCase()) !== -1 || !val ;
  });
  }


  modalOpenForm(modalForm) {
    this.modalService.open(modalForm);
  }
}
