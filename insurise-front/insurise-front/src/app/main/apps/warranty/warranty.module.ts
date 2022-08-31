import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WarrantyAddComponent } from './warranty-add/warranty-add.component';
import { WarrantyComponent } from './warranty.component';
import { CoreCommonModule } from '@core/common.module';
import { RouterModule, Routes } from '@angular/router';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { WarrantyDetailComponent } from './warranty-detail/warranty-detail.component';
import { WarrantyUpdateComponent } from './warranty-update/warranty-update.component';
import { NgbDropdownModule, NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { Ng2FlatpickrModule } from 'ng2-flatpickr';
import { CorePipesModule } from '@core/pipes/pipes.module';
import { CoreDirectivesModule } from '@core/directives/directives';
import { CoreSidebarModule } from '@core/components';
import { TranslateModule } from '@ngx-translate/core';
import { ModalsComponent } from 'app/main/components/modals/modals.component';
import { ModalsModule } from 'app/main/components/modals/modals.module';

// routing
const routes: Routes = [
  {
    path: 'list',
    component: WarrantyComponent,
    data: { animation: 'WarrantyComponent' }
  },
  {
    path: 'add',
    component : WarrantyAddComponent,
    data: {animation: 'WarrantyAddComponent'}
  },
  {
    path:'update/:id',
    component : WarrantyUpdateComponent,
    data: {animation: 'WarrantyUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : WarrantyDetailComponent,
    data: {animation: 'WarrantyDetailComponent'}
  }
  

];
@NgModule({
  declarations: [
    WarrantyComponent,
    WarrantyAddComponent,
    WarrantyDetailComponent,
    WarrantyUpdateComponent
  ],
  imports: [
    CommonModule,
    NgxDatatableModule,
    CoreCommonModule,
    RouterModule.forChild(routes),
    NgbDropdownModule,
    ContentHeaderModule,
    CardSnippetModule,
    NgSelectModule,
    FormsModule,
    NgbModule,
    Ng2FlatpickrModule,
    CorePipesModule,
    CoreDirectivesModule,
    CoreSidebarModule,
    TranslateModule,
    NgbModule,
  ]
})
export class WarrantyModule { }
