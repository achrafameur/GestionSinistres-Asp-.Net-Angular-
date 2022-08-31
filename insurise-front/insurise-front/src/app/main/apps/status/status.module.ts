import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StatusAddComponent } from './status-add/status-add.component';
import { RouterModule, Routes } from '@angular/router';
import { StatusComponent } from './status.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { StatusUpdateComponent } from './status-update/status-update.component';
import { TranslateModule } from '@ngx-translate/core';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';

const routes: Routes = [
  {
    path: 'list',
    component: StatusComponent,
    // resolve: {
    //   data: CalendarService
    // },
    data: { animation: 'status' }
  },
  {
    path: 'add',
    component : StatusAddComponent,
    data: {animation: 'StatusAddComponent'}
  },
  {
    path: 'update/:id',
    component : StatusUpdateComponent,
    data: {animation: 'StatusUpdateComponent'}
  }
]

@NgModule({
  declarations: [
    StatusComponent,
    StatusAddComponent,
    StatusUpdateComponent
  ],
  imports: [
    CommonModule,
    NgxDatatableModule,
    CoreCommonModule,
    HttpClientModule,
    RouterModule.forChild(routes),
    TranslateModule,
    ContentHeaderModule
  ]
})
export class StatusModule { }
