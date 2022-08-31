import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticleComponent } from './article.component';
import { ArticleAddComponent } from './article-add/article-add.component';
import { RouterModule, Routes } from '@angular/router';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { ArticleService } from './article.service';
import { ArticleUpdateComponent } from './article-update/article-update.component';
import { ArticleDetailComponent } from './article-detail/article-detail.component';
import { NgbDropdownModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { Ng2FlatpickrModule } from 'ng2-flatpickr';
import { CorePipesModule } from '@core/pipes/pipes.module';
import { CoreDirectivesModule } from '@core/directives/directives';
import { CoreSidebarModule } from '@core/components';
import { TranslateModule } from '@ngx-translate/core';

// routing
const routes: Routes = [
  {
    path: 'list',
    component: ArticleComponent,
    // resolve: {
    //   data: CalendarService
    // },
    data: { animation: 'article' }
  },
  {
    path: 'add',
    component : ArticleAddComponent,
    data: {animation: 'ArticleAddComponent'}
  },
  {
    path: 'update/:id',
    component : ArticleUpdateComponent,
    data: {animation: 'ArticleUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : ArticleDetailComponent,
    data: {animation: 'ArticleDetailComponent'}
  }
];

@NgModule({
  declarations: [
    ArticleComponent,
    ArticleAddComponent,
    ArticleUpdateComponent,
    ArticleDetailComponent
  ],
  imports: [
    CommonModule,
    NgxDatatableModule,
    CoreCommonModule,
    RouterModule.forChild(routes),
    HttpClientModule ,
    NgbDropdownModule,
    ContentHeaderModule,
    CardSnippetModule,
    NgSelectModule,
    FormsModule,
    NgbModule,
    Ng2FlatpickrModule,
    CorePipesModule,
    CoreDirectivesModule,
    CoreSidebarModule,
    TranslateModule,

  ], 
})
export class ArticleModule { }
