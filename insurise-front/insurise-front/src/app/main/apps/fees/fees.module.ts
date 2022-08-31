import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeesUpdateComponent } from './fees-update/fees-update.component';
import { FeesAddComponent } from './fees-add/fees-add.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FeesComponent } from './fees.component';
import { TranslateModule } from '@ngx-translate/core';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';


const routes: Routes = [
  {
    path: 'list',
    component: FeesComponent,
    data: { animation: 'Fees' }
  },
  {
    path: 'add',
    component : FeesAddComponent,
    data: {animation: 'FeesAddComponent'}
  },
  {
    path: 'update/:id',
    component : FeesUpdateComponent,
    data: {animation: 'FeesUpdateComponent'}
  }
]


@NgModule({
  declarations: [
    FeesComponent,
    FeesUpdateComponent,
    FeesAddComponent
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
export class FeesModule { }
