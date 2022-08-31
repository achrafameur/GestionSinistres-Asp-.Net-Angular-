import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SinisterNatureComponent } from './sinister-nature.component';
import { AddSinisterNatureComponent } from './add-sinister-nature/add-sinister-nature.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CoreCommonModule } from '@core/common.module';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { SinisterNatureUpdateComponent } from './sinister-nature-update/sinister-nature-update.component';
import { SinisterNatureDetailsComponent } from './sinister-nature-details/sinister-nature-details.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';
import { CardSnippetModule } from '@core/components/card-snippet/card-snippet.module';
import { DragDropModule } from 'app/main/extensions/drag-drop/drag-drop.module';
import { TranslateModule } from '@ngx-translate/core';
import { DropdownsModule } from 'app/main/components/dropdowns/dropdowns.module';
import { SinisterDetailsViewComponent } from './sinister-details-view/sinister-details-view.component';

const routes: Routes = [
  {
    path: 'list',
    component: SinisterNatureComponent,
    data: { animation: 'sinister-nature' }
  },
  {
    path: 'add',
    component : AddSinisterNatureComponent,
    data: {animation: 'SinisterNatureAddComponent'}
  },
  {
    path: 'update/:id',
    component : SinisterNatureUpdateComponent,
    data: {animation: 'SinisterNatureUpdateComponent'}
  },
  {
    path: 'details/:id',
    component : SinisterDetailsViewComponent,
    data: {animation: 'SinisterDetailsViewComponent'}
  }
];


@NgModule({
  declarations: [
    SinisterNatureComponent,
    AddSinisterNatureComponent,
    SinisterNatureUpdateComponent,
    SinisterNatureDetailsComponent,
    SinisterDetailsViewComponent,
  ],
  imports: [
    CommonModule,
    NgxDatatableModule,
    CoreCommonModule,
    HttpClientModule,
    RouterModule.forChild(routes),
    NgbModule, 
    ContentHeaderModule, 
    CardSnippetModule, 
    CoreCommonModule,
    TranslateModule,
    ContentHeaderModule
  ]
})
export class SinisterNatureModule { }
