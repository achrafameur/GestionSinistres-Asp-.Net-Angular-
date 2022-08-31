import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChainComponent } from './chain.component';
import { ChainAddComponent } from './chain-add/chain-add.component';
import { RouterModule, Routes } from '@angular/router';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { ChainUpdateComponent } from './chain-update/chain-update.component';
import { ChainDetailComponent } from './chain-detail/chain-detail.component';
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


// routing
const routes: Routes = [
  {
    path: 'list',
    component: ChainComponent,
    data: { animation: 'chain' }
  },
  {
    path: 'add',
    component : ChainAddComponent,
    data: {animation: 'ChainAddComponent'}
  },
  {
    path: 'update/:id',
    component : ChainUpdateComponent,
    data: {animation: 'ChainUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : ChainDetailComponent,
    data: {animation: 'ChainDetailComponent'}
  },
];

@NgModule({
  declarations: [
    ChainComponent,
    ChainAddComponent,
    ChainUpdateComponent,
    ChainDetailComponent
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
  ]
})
export class ChainModule { }





