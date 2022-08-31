import { Chain } from '@angular/compiler';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { Autoplay } from 'swiper';
import { ArticleService } from '../article/article.service';
import { ChainService } from '../chain/chain.service';
import { ChainDto } from '../interfaces/chain';
import { ChainElementService } from './chain-element.service';
import { locale as English } from '../chain/i18n/en';
import { locale as Francais } from '../chain/i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import { ChainElement } from '../interfaces/chainElement';

@Component({
  selector: 'app-chain-element',
  templateUrl: './chain-element.component.html',
  styleUrls: ['./chain-element.component.scss']
})
export class ChainElementComponent implements OnInit {
  public elements:ChainElement[]; 
  // public chainList:ChainDto[];
  public contentHeader: object;
  public rows: any;
  public selected = [];
  public kitchenSinkRows: any;
  public selectedOption = 10;
  public ColumnMode = ColumnMode;
  public expanded = {};
  public editingName = {};
  public editingStatus = {};
  public editingAge = {};
  public editingSalary = {};
  public chkBoxSelected = [];
  public SelectionType = SelectionType;
  public exportCSVData;
  readonly headerHeight = 50;
  readonly rowHeight = 50;
  readonly pageLimit = 10;
  readonly footerHeight = 50;
  public pageAdvanced :any
  columns = [
    {name :"Id", prop : 'chainElementId'},
    {name :"Title", prop : 'title'},
    {name :"ChainId", prop : 'chainId'},
    {name : "Actions",prop : 'chainElementId'}
  ]
  @ViewChild(DatatableComponent) table: DatatableComponent;
  @ViewChild('tableRowDetails') tableRowDetails: any;

  constructor(private chainElementService:ChainElementService, private router: Router,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    this.chainElementService.loadChainElements().subscribe({next:(result)=>{
      console.log(result);
      this.rows=result;
    },
    error:(err)=>{
      console.log(err)
    }})
    // this.chainService.loadChains().subscribe({next:(result)=>{
    //   console.log(result);
    //   this.chainList=result
    // }})

    this.contentHeader = {
      headerTitle: 'Element',
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
                  name: 'Element',
                  isLink: true,
                  link: '/apps/chain-element/list'
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
    this.chainElementService.deleteChainElement(value).subscribe(()=>{
      this.chainElementService.loadChainElements().subscribe({next:(result)=>{
        console.log(result);
        this.rows=result;
      },
      error:(err)=>{
        console.log(err)
      }})
    }
    )
  }

}
