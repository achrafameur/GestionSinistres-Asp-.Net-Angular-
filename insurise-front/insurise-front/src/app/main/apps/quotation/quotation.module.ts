import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { QuotationAddComponent } from './quotation-add/quotation-add.component';
import { QuotationUpdateComponent } from './quotation-update/quotation-update.component';
import { QuotationDetailComponent } from './quotation-detail/quotation-detail.component';
import { RouterModule, Routes } from '@angular/router';
import { QuotationComponent } from './quotation.component';
import { CoreCommonModule } from '@core/common.module';
import { NgbDropdownModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { NgSelectModule } from '@ng-select/ng-select';
import { FormsModule } from '@angular/forms';
import { Ng2FlatpickrModule } from 'ng2-flatpickr';
import { CorePipesModule } from '@core/pipes/pipes.module';
import { CoreDirectivesModule } from '@core/directives/directives';
import { CoreSidebarModule } from '@core/components';
import { TranslateModule } from '@ngx-translate/core';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


// routing
const routes: Routes = [
  {
    path: 'list',
    component: QuotationComponent,
    data: { animation: 'QuotationComponent' }
  },
  {
    path: 'add',
    component : QuotationAddComponent,
    data: {animation: 'QuotationAddComponent'}
  },
  {
    path:'update/:id',
    component : QuotationUpdateComponent,
    data: {animation: 'QuotationUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : QuotationDetailComponent,
    data: {animation: 'QuotationDetailComponent'}
  }
  

];
@NgModule({
  declarations: [
    QuotationComponent,
    QuotationAddComponent,
    QuotationUpdateComponent,
    QuotationDetailComponent
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
export class QuotationModule { }
