import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ColumnMode, DatatableComponent, SelectionType } from '@swimlane/ngx-datatable';
import { Item } from 'app/main/pages/interfaces/item';
import { ArticleService } from './article.service';
import { locale as English } from './i18n/en';
import { locale as Francais } from './i18n/fr';


@Component({
  selector: 'app-article',
  templateUrl: './article.component.html',
  styleUrls: ['./article.component.scss']
})

export class ArticleComponent implements OnInit {
  public articles:Item[]; 
  public contentHeader: object;

  public ColumnMode = ColumnMode;
  public kitchenSinkRows: any;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  readonly headerHeight = 50;
  readonly rowHeight = 50;
  readonly pageLimit = 10;
  readonly footerHeight = 50;
  public selectedOption = 10;
  public rows: any;
  public tempData : any;

  columns = [
    {name :"Id", prop : 'id'},
    {name :"Title", prop : 'title'},
    {name : "Actions",prop : 'id'}
  ]
  @ViewChild(DatatableComponent) table: DatatableComponent;
  @ViewChild('tableRowDetails') tableRowDetails: any;

  constructor(private articleService:ArticleService,private modalService: NgbModal, private router: Router,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }

  ngOnInit(): void {
    this.articleService.loadItems().subscribe({next:(result) => {
      this.kitchenSinkRows = result;
      this.tempData = result;

    },
  error: (err) => {
    console.log(err);
  }})

  this.contentHeader = {
    headerTitle: 'Article',
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
                name: 'Article',
                isLink: true,
                link: '/apps/article/list'
            },
            {
                name: 'List',
                isLink: false
            }
        ]
    }
};
  }
  onDelete (value){
    this.articleService.deleteItem(value).subscribe(()=>{
      this.articleService.loadItems().subscribe({next:(result) => {
        this.kitchenSinkRows = result;
      },
    error: (err) => {
      console.log(err);
    }})
    
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
