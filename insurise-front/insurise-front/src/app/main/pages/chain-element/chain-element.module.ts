import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { NgbDropdownModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { Ng2FlatpickrModule } from 'ng2-flatpickr';
import { CorePipesModule } from '@core/pipes/pipes.module';
import { CoreDirectivesModule } from '@core/directives/directives';
import { CoreSidebarModule } from '@core/components';
import { ElementAddComponent } from './element-add/element-add.component';
import { ElementDetailComponent } from './element-detail/element-detail.component';
import { ElementUpdateComponent } from './element-update/element-update.component';
import { ChainElementComponent } from './chain-element.component';
import { TranslateModule } from '@ngx-translate/core';


// routing
const routes: Routes = [
  {
    path: 'list',
    component: ChainElementComponent,
    // resolve: {
    //   data: CalendarService
    // },
    data: { animation: 'ChainElementComponent' }
  },
  {
    path: 'add',
    component : ElementAddComponent,
    data: {animation: 'ElementAddComponent'}
  },
  {
    path: 'update/:id',
    component : ElementUpdateComponent,
    data: {animation: 'ElementUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : ElementDetailComponent,
    data: {animation: 'ElementDetailComponent'}
  }
];

@NgModule({
  declarations: [
    ChainElementComponent,
    ElementAddComponent,
    ElementDetailComponent,
    ElementUpdateComponent
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
    TranslateModule
  ]
})
export class ChainElementModule { }
