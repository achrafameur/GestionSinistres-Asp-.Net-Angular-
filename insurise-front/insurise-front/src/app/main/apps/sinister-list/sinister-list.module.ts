import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { SinisterListComponent } from './sinister-list.component';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { TranslateModule } from '@ngx-translate/core';

const routes: Routes = [
  {
    path: 'all',
    component: SinisterListComponent,
    data: { animation: 'SinisterListComponent' }
  },
]

@NgModule({
  declarations: [
    SinisterListComponent
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
export class SinisterListModule { }
