import {Component, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { BranchService } from './branch.service';
import {locale as english} from "./i18n/en";
import {locale as french} from "./i18n/fr";
import {locale as german} from "./i18n/de";
import {locale as portuguese} from "./i18n/pt";
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-branch',
    templateUrl: './branch.component.html',
    styleUrls: ['./branch.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class BranchComponent implements OnInit {

  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public tempData: any;
  public SelectionType = SelectionType;
  public selectedOption = 10;
  public contentHeader : object ; 

  columns = [ 
    {name: 'Id', prop: 'branchId'},
    {name: 'Title', prop: 'title'},
    {name: 'Description', prop: 'description'},
    {name: 'Parent Id', prop: 'branchParent'},
    {name: 'Actions', prop: 'branchId'} 
  ];


  // decorator
  @ViewChild(DatatableComponent) table: DatatableComponent;
  
  constructor(private branchService: BranchService,private modalService: NgbModal,private _coreTranslationService: CoreTranslationService ) 
  {
    this._coreTranslationService.translate(english, french, german, portuguese);
  }

  ngOnInit(): void {
    this.branchService.getBranches().subscribe(
      (data)=>
        {
          this.kitchenSinkRows=data;
          this.tempData=this.kitchenSinkRows
        }
    )
    this.contentHeader = {
      headerTitle: 'Branch',
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
                  name: 'Branch',
                  isLink: true,
                  link: '/apps/branch/list'
              },
              {
                  name: 'all',
                  isLink: false
              }
          ]
      }
  };
  }
  
  delete(id:number){
  this.branchService.deleteBranch(id).subscribe(()=>{
    this.branchService.getBranches().subscribe(
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
