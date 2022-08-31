import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThirdPartyAddComponent } from './third-party-add/third-party-add.component';
import { ThirdPartyComponent } from './third-party.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { ThirdPartyUpdateComponent } from './third-party-update/third-party-update.component';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { TranslateModule } from '@ngx-translate/core';


const routes: Routes = [
  {
    path: 'list',
    component: ThirdPartyComponent,
    data: { animation: 'third-party' }
  },
  {
    path: 'add',
    component : ThirdPartyAddComponent,
    data: {animation: 'ThirdPartyAddComponent'}
  },
  {
    path: 'update/:id',
    component : ThirdPartyUpdateComponent,
    data: {animation: 'ThirdPartyUpdateComponent'}
  }
]

@NgModule({
  declarations: [
    ThirdPartyComponent,
    ThirdPartyAddComponent,
    ThirdPartyUpdateComponent
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
export class ThirdPartyModule { }
