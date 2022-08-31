import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AverageCostAddComponent } from './average-cost-add/average-cost-add.component';
import { RouterModule, Routes } from '@angular/router';
import { AverageCostComponent } from './average-cost.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { AverageCostUpdateComponent } from './average-cost-update/average-cost-update.component';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { TranslateModule } from '@ngx-translate/core';
import { Ng2FlatpickrModule } from 'ng2-flatpickr';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';

const routes: Routes = [
  {
    path: 'list',
    component: AverageCostComponent,
    data: { animation: 'average-cost' }
  },
  {
    path: 'add',
    component : AverageCostAddComponent,
    data: {animation: 'AverageCostAddComponent'}
  },
  {
    path: 'update/:id',
    component : AverageCostUpdateComponent,
    data: {animation: 'AverageCostUpdateComponent'}
  }
]

@NgModule({
  declarations: [
    AverageCostAddComponent,
    AverageCostComponent,
    AverageCostUpdateComponent
  ],
  imports: [
    CommonModule,
    NgxDatatableModule,
    CoreCommonModule,
    HttpClientModule,
    RouterModule.forChild(routes),
    ContentHeaderModule,
    TranslateModule, 
    Ng2FlatpickrModule,
    CardSnippetModule,
    SweetAlert2Module.forRoot()
  ]
})
export class AverageCostModule { }
