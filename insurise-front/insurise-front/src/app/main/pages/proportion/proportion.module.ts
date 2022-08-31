import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProportionComponent } from './proportion.component';
import { AddProportionComponent } from './add-proportion/add-proportion.component';
import { UpdateProportionComponent } from './update-proportion/update-proportion.component';
import { DetailProportionComponent } from './detail-proportion/detail-proportion.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
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
    component: ProportionComponent,
    data: { animation: 'ProportionComponent' }
  },
  {
    path: 'add',
    component : AddProportionComponent,
    data: {animation: 'AddProportionComponent'}
  },
  {
    path: 'update/:id',
    component : UpdateProportionComponent,
    data: {animation: 'UpdateProportionComponent'}
  },
  {
    path: 'detail/:id',
    component : DetailProportionComponent,
    data: {animation: 'NatureDetailComponent'}
  }

  
];

@NgModule({
  declarations: [
    ProportionComponent,
    AddProportionComponent,
    UpdateProportionComponent,
    DetailProportionComponent
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
export class ProportionModule { }
