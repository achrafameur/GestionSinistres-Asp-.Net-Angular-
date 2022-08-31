import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThirdCompanyAddComponent } from './third-company-add/third-company-add.component';
import { ThirdCompanyUpdateComponent } from './third-company-update/third-company-update.component';
import { RouterModule, Routes } from '@angular/router';
import { ThirdCompanyComponent } from './third-company.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { TranslateModule } from '@ngx-translate/core';

const routes: Routes = [
  {
    path: 'list',
    component: ThirdCompanyComponent,
    data: { animation: 'third-company' }
  },
  {
    path: 'add',
    component : ThirdCompanyAddComponent,
    data: {animation: 'ThirdCompanyAddComponent'}
  },
  {
    path: 'update/:id',
    component : ThirdCompanyUpdateComponent,
    data: {animation: 'ThirdCompanyUpdateComponent'}
  }
]


@NgModule({
  declarations: [
    ThirdCompanyComponent,
    ThirdCompanyAddComponent,
    ThirdCompanyUpdateComponent
  ],
  imports: [
    CommonModule,
    NgxDatatableModule,
    CoreCommonModule,
    HttpClientModule,
    RouterModule.forChild(routes),
    ContentHeaderModule,
    TranslateModule
  ]
})
export class ThirdCompanyModule { }
