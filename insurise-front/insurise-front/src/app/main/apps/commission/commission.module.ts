import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CommissionComponent } from './commission.component';
import { CommissionAddComponent } from './commission-add/commission-add.component';
import { CommissionDetailComponent } from './commission-detail/commission-detail.component';
import { CommissionUpdateComponent } from './commission-update/commission-update.component';
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
    component: CommissionComponent,
    // resolve: {
    //   data: CalendarService
    // },
    data: { animation: 'commission' }
  },
  {
    path: 'add',
    component : CommissionAddComponent,
    data: {animation: 'CommissionAddComponent'}
  },
  {
    path: 'update/:id',
    component : CommissionUpdateComponent,
    data: {animation: 'CommissionUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : CommissionDetailComponent,
    data: {animation: 'CommissionDetailComponent'}
  }

  
];


@NgModule({
  declarations: [
    CommissionComponent,
    CommissionAddComponent,
    CommissionDetailComponent,
    CommissionUpdateComponent
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
export class CommissionModule { }
