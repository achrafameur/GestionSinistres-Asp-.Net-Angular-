import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DuartionAddComponent } from './duartion-add/duartion-add.component';
import { DuartionUpdateComponent } from './duartion-update/duartion-update.component';
import { RouterModule, Routes } from '@angular/router';
import { DuartionComponent } from './duartion.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { TranslateModule } from '@ngx-translate/core';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';


const routes: Routes = [
  {
    path: 'list',
    component: DuartionComponent,
    data: { animation: 'Duration' }
  },
  {
    path: 'add',
    component : DuartionAddComponent,
    data: {animation: 'DuartionAddComponent'}
  },
  {
    path: 'update/:id',
    component : DuartionUpdateComponent,
    data: {animation: 'DuartionUpdateComponent'}
  }
]

@NgModule({
  declarations: [
    DuartionComponent,
    DuartionAddComponent,
    DuartionUpdateComponent
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
export class DuartionModule { }
