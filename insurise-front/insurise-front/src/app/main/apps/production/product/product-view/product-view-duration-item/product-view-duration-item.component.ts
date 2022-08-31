import {Component, Input, OnInit, ViewEncapsulation} from "@angular/core";
import {EcommerceService} from "../../../../ecommerce/ecommerce.service";

@Component({
    selector: 'product-view-duration-item',
    templateUrl: './product-view-duration-item.component.html',
    styleUrls: ['../../product.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class ProductViewDurationItemComponent implements OnInit {
    // Input Decorator
    @Input() product;

    /**
     * Constructor
     *
     * @param {EcommerceService} _ecommerceService
     */
    constructor(private _ecommerceService: EcommerceService) {
    }

    /**
     * Remove From Cart
     *
     * @param product
     */
    removeFromCart(product) {
        if (product.isInCart === true) {
            this._ecommerceService.removeFromCart(product.id).then(res => {
                product.isInCart = false;
            });
        }
    }

    /**
     * Toggle Wishlist
     *
     * @param product
     */
    toggleWishlist(product) {
        if (product.isInWishlist === true) {
            this._ecommerceService.removeFromWishlist(product.id).then(res => {
                product.isInWishlist = false;
            });
        } else {
            this._ecommerceService.addToWishlist(product.id).then(res => {
                product.isInWishlist = true;
            });
        }
    }

    // Lifecycle Hooks
    // -----------------------------------------------------------------------------------------------------
    ngOnInit(): void {
    }
}