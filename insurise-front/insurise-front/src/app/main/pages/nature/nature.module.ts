import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NatureComponent } from './nature.component';
import { NatureAddComponent } from './nature-add/nature-add.component';
import { RouterModule, Routes } from '@angular/router';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { NatureUpdateComponent } from './nature-update/nature-update.component';
import { NatureDetailComponent } from './nature-detail/nature-detail.component';
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
    component: NatureComponent,
    // resolve: {
    //   data: CalendarService
    // },
    data: { animation: 'nature' }
  },
  {
    path: 'add',
    component : NatureAddComponent,
    data: {animation: 'NatureAddComponent'}
  },
  {
    path: 'update/:id',
    component : NatureUpdateComponent,
    data: {animation: 'NatureUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : NatureDetailComponent,
    data: {animation: 'NatureDetailComponent'}
  }

  
];

@NgModule({
  declarations: [
    NatureComponent,
    NatureAddComponent,
    NatureUpdateComponent,
    NatureDetailComponent
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
export class NatureModule { }
