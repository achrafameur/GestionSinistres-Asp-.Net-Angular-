import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FeatureAddComponent } from './feature-add/feature-add.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CoreCommonModule } from '@core/common.module';
import { RouterModule, Routes } from '@angular/router';
import { FeatureComponent } from './feature.component';
import { FeatureUpdateComponent } from './feature-update/feature-update.component';
import { FeatureDetailComponent } from './feature-detail/feature-detail.component';
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

const routes: Routes = [
  {
    path: 'list',
    component: FeatureComponent,
    // resolve: {
    //   data: CalendarService
    // },
    data: { animation: 'feature' }
  },
  {
    path: 'add',
    component : FeatureAddComponent,
    data: {animation: 'FeatureAddComponent'}
  },
  {
    path: 'update/:id',
    component : FeatureUpdateComponent,
    data: {animation: 'FeatureUpdateComponent'}
  },
  {
    path: 'detail/:id',
    component : FeatureDetailComponent,
    data: {animation: 'FeatureDetailComponent'}
  },
];

@NgModule({
  declarations: [
    FeatureComponent,
    FeatureAddComponent,
    FeatureUpdateComponent,
    FeatureDetailComponent
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
export class FeatureModule { }
