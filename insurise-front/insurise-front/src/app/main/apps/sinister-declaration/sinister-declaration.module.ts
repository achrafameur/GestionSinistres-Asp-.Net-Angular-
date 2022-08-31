import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SinisterDeclarationComponent } from './sinister-declaration.component';
import { RouterModule, Routes } from '@angular/router';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { TranslateModule } from '@ngx-translate/core';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';

const routes: Routes = [
  {
    path: 'add',
    component: SinisterDeclarationComponent,
    data: { animation: 'SinisterDeclarationComponent' }
  }
];

@NgModule({
  declarations: [
    SinisterDeclarationComponent
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
export class SinisterDeclarationModule { }
