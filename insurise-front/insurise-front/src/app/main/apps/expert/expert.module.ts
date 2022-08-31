import { NgModule } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { ExpertAddComponent } from './expert-add/expert-add.component';
import { RouterModule, Routes } from '@angular/router';
import { ExpertComponent } from './expert.component';
import { HttpClientModule } from '@angular/common/http';
import { CoreCommonModule } from '@core/common.module';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ExpertUpdateComponent } from './expert-update/expert-update.component';
import { ExpertDetailsComponent } from './expert-details/expert-details.component';
import { TranslateModule } from '@ngx-translate/core';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';

const routes: Routes = [
  {
    path: 'list',
    component: ExpertComponent,
    data: { animation: 'expert' }
  },
  {
    path: 'add',
    component : ExpertAddComponent,
    data: {animation: 'ExpertAddComponent'}
  },
  {
    path: 'update/:id',
    component : ExpertUpdateComponent,
    data: {animation: 'ExpertUpdateComponent'}
  },
  {
    path: 'details/:id',
    component : ExpertDetailsComponent,
    data: {animation: 'ExpertDetailsComponent'}
  }
]

@NgModule({
  declarations: [
    ExpertComponent,
    ExpertAddComponent,
    ExpertUpdateComponent,
    ExpertDetailsComponent
  ],
  imports: [
    CommonModule,
    NgxDatatableModule,
    CoreCommonModule,
    HttpClientModule,
    RouterModule.forChild(routes),
    TranslateModule,
    ContentHeaderModule
  ],
})
export class ExpertModule { }
