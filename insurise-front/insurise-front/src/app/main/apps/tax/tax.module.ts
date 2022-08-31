import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaxAddComponent } from './tax-add/tax-add.component';
import { TaxUpdateComponent } from './tax-update/tax-update.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { TaxComponent } from './tax.component';
import { TranslateModule } from '@ngx-translate/core';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';


const routes: Routes = [
  {
    path: 'list',
    component: TaxComponent,
    data: { animation: 'Tax' }
  },
  {
    path: 'add',
    component : TaxAddComponent,
    data: {animation: 'TaxAddComponent'}
  },
  {
    path: 'update/:id',
    component : TaxUpdateComponent,
    data: {animation: 'TaxUpdateComponent'}
  }
]


@NgModule({
  declarations: [
    TaxComponent,
    TaxAddComponent,
    TaxUpdateComponent
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
export class TaxModule { }
