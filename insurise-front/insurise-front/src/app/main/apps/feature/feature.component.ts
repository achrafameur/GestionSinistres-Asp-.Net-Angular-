import {Component, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { FeatureDto } from 'app/main/pages/interfaces/feature';
import { NatureService } from 'app/main/pages/nature/nature.service';
import { map } from 'rxjs/operators';
import { FeatureService } from './feature.service';
import {locale as English} from './i18n/en'
import { locale as Francais } from './i18n/fr';

@Component({
  selector: 'app-feature',
  templateUrl: './feature.component.html',
  styleUrls: ['./feature.component.scss']
})
export class FeatureComponent implements OnInit {
  public features : FeatureDto[];
  public contentHeader: object;

 public ColumnMode = ColumnMode;
 public kitchenSinkRows: any;
 public basicSelectedOption: number = 10;
 public SelectionType = SelectionType;
 readonly headerHeight = 50;
 readonly rowHeight = 50;
 readonly pageLimit = 10;
 readonly footerHeight = 50;
 public selectedOption = 5;
 public rows: any;
 public tempData : any;
  public featureNaturesList : any[];
  columns = [
    {name :"Id", prop : 'featureId'},
    {name :"Title", prop : 'title'},
    {name : "Description",prop :'description'},
    {name : "Symbol",prop :'symbol'},
    {name : "Nature",prop :'nature'},
    {name : "List",prop :'chain'},
    {name : "Fixed",prop :'fixed'},
    {name : "Alterable",prop :'alterable'},
    {name : "Principal",prop :'isPrincipal'},
    {name : "Actions",prop : 'characteristicId'}
  ]
  @ViewChild(DatatableComponent) table: DatatableComponent;
  constructor(private featureService :FeatureService,private modalService: NgbModal,private natureService:NatureService,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    this.natureService.loadNatures();
    this.featureService.loadFeatures().subscribe({next:(result) => {
      console.log(result);
      this.kitchenSinkRows = result;
      this.tempData = result;
    },
    error: (err) => {
      console.log(err);
  }})
  this.contentHeader = {
    headerTitle: 'Feature',
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
                name: 'Feature',
                isLink: true,
                link: '/apps/feature/list'
            },
            {
                name: 'List',
                isLink: false
            }
        ]
    }
};

  }
  
  onDelete(value:number){
    this.featureService.deleteFeature(value).subscribe(()=>{
      this.featureService.loadFeatures().subscribe({next:(result) => {
        // window.location.reload();
        this.kitchenSinkRows = result;
        
      },
      error: (err) => {
        console.log(err);
    }})
    }
    
    )
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
