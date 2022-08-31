import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';

import {CoreCommonModule} from '@core/common.module';
import {ProductComponent} from './product.component';
import {TranslateModule} from '@ngx-translate/core';
import {NgbDropdownModule, NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {ContentHeaderModule} from '../../../../layout/components/content-header/content-header.module';
import {CardSnippetModule} from '../../../../../@core/components/card-snippet/card-snippet.module';
import {CsvModule} from '@ctrl/ngx-csv';
import {NgSelectModule} from '@ng-select/ng-select';
import {ProductViewComponent} from './product-view/product-view.component';
import {UserViewService} from '../../user/user-view/user-view.service';
import {ProductService} from './product.service';
import {FormsModule} from '@angular/forms';
import {CorePipesModule} from '../../../../../@core/pipes/pipes.module';
import {CoreDirectivesModule} from '../../../../../@core/directives/directives';
import {CoreSidebarModule} from '../../../../../@core/components';
import {CoreTouchspinModule} from '../../../../../@core/components/core-touchspin/core-touchspin.module';
import {Ng2FlatpickrModule} from 'ng2-flatpickr';

import {
    ProductViewDurationItemComponent
} from './product-view/product-view-duration-item/product-view-duration-item.component';
import {ProductUpdateComponent} from './product-update/product-update.component';
import {ProductRoutingModule} from './route/product-routing.module';
import {ProductDeleteDialogComponent} from './product-delete/product-delete-dialog.component';
import {NgxDatatableModule} from '@swimlane/ngx-datatable';
import {ProductWarrantyModalComponent} from "./product-view/product-warranty-modal/product-warranty-modal.component";
import {DragDropModule} from "@angular/cdk/drag-drop";
import {ProductShopModalComponent} from "./product-view/product-shop-modal/product-shop-modal.component";
import {ProductDurationModalComponent} from "./product-view/product-duration-modal/product-duration-modal.component";




@NgModule({
    declarations: [
        ProductComponent,
        ProductViewComponent,
        ProductUpdateComponent,
        ProductViewDurationItemComponent,
        ProductDeleteDialogComponent,
        ProductWarrantyModalComponent,
        ProductShopModalComponent,
        ProductDurationModalComponent
    ],
    entryComponents: [ProductDeleteDialogComponent],
    imports: [
        ProductRoutingModule,
        CommonModule,
        NgxDatatableModule,
        CoreCommonModule,
        TranslateModule,
        NgbDropdownModule,
        ContentHeaderModule,
        CardSnippetModule,
        CsvModule,
        NgSelectModule,
        FormsModule,
        NgbModule,
        CorePipesModule,
        CoreDirectivesModule,
        CoreSidebarModule,
        CoreTouchspinModule,
        Ng2FlatpickrModule,
        DragDropModule
    ],
    providers: [ProductService, UserViewService]
})
export class ProductModule {
}
