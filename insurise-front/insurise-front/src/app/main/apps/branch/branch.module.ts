import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BranchComponent } from './branch.component';
import {NgxDatatableModule, SelectionType} from '@swimlane/ngx-datatable';
import {CoreCommonModule} from "../../../../@core/common.module";
import {RouterModule, Routes} from "@angular/router";
import { BranchAddComponent } from './branch-add/branch-add.component';
import { HttpClientModule } from '@angular/common/http';
import { BranchUpdateComponent } from './branch-update/branch-update.component';
import { TranslateModule } from '@ngx-translate/core';
import { ContentHeaderModule } from 'app/layout/components/content-header/content-header.module';


// routing
const routes: Routes = [
  {
    path: 'list',
    component: BranchComponent,
    data: { animation: 'branch' }
  },
  {
    path: 'add',
    component : BranchAddComponent,
    data: {animation: 'BranchAddComponent'}
  },
  {
    path: 'update/:id',
    component : BranchUpdateComponent,
    data: {animation: 'BranchUpdateComponent'}
  }
];

@NgModule({
  declarations: [
    BranchComponent,
    BranchAddComponent,
    BranchUpdateComponent
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
export class BranchModule {


}
