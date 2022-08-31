import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ProductRoutingResolveService } from "./product-routing-resolve.service";
import {ProductComponent} from "../product.component";
import {ProductViewComponent} from "../product-view/product-view.component";
import {ProductUpdateComponent} from "../product-update/product-update.component";
import {ProductViewService} from "../product-view/product-view.service";

const productRoute: Routes = [
  {
    path: "",
    component: ProductComponent,
    data: {
      defaultSort: "id,asc",
    },
    //canActivate: [UserRouteAccessService],
  },
  /*{
    path: "list",
    component: ProductComponent,
    data: {
      defaultSort: "id,asc",
    },
   // canActivate: [UserRouteAccessService],
  },*/
  {
    path: 'product-view/:id',
    component: ProductViewComponent,
    resolve: {
      product: ProductViewService,
    },
    data: {animation: 'ProductViewComponent' }
    // canActivate: [UserRouteAccessService],
  },
  {
    path: "add",
    component: ProductUpdateComponent,
    resolve: {
      product: ProductRoutingResolveService,
    },
    // canActivate: [UserRouteAccessService],
  },
  {
    path: ":id/edit",
    component: ProductUpdateComponent,
    resolve: {
      product: ProductRoutingResolveService,
    },
    // canActivate: [UserRouteAccessService],
  },
];

@NgModule({
  imports: [RouterModule.forChild(productRoute)],
  exports: [RouterModule],
})
export class ProductRoutingModule {}
