import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ArticleService } from '../article.service';
import { Item } from '../../interfaces/item';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';

@Component({
  selector: 'app-article-detail',
  templateUrl: './article-detail.component.html',
  styleUrls: ['./article-detail.component.scss']
})
export class ArticleDetailComponent implements OnInit {

  item : Item;
 router : Router;
 public contentHeader: object;
  constructor(private articleService:ArticleService, private activatedroute :ActivatedRoute,private _coreTranslationService: CoreTranslationService ) { 
    this._coreTranslationService.translate(English,Francais);
  }

  ngOnInit(): void {
    const id = this.activatedroute.snapshot.params.id;
    this.articleService.loadItemById(id).subscribe((data) => {
      this.articleService.getFeaturesByItemId(id).subscribe(data=>{this.item.featureItems=data})
       this.item= data; console.log(data)})
   
    this.contentHeader = {
      headerTitle: 'Detail Article',
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
                  name: 'Detail',
                  isLink: false
              }
          ]
      }
  };
  }

}
