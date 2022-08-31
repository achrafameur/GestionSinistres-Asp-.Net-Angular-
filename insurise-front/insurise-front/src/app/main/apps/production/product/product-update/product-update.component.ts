import {Component, OnDestroy, OnInit, ViewEncapsulation} from '@angular/core';
import {Observable, Subject} from 'rxjs';
import {finalize} from 'rxjs/operators';
import {FormBuilder, NgForm, Validators} from '@angular/forms';
import {ProductUpdateService} from './product-update.service';
import {ActivatedRoute, Router} from '@angular/router';
import {IProduct, Product} from '../model/product';
import {CoreTranslationService} from '../../../../../../@core/services/translation.service';
import {locale as english} from '../i18n/en';
import {locale as french} from '../i18n/fr';
import {locale as german} from '../i18n/de';
import {locale as portuguese} from '../i18n/pt';
import {FlatpickrOptions} from 'ng2-flatpickr';
import {BranchService} from '../../../branch/branch.service';
import {HttpResponse} from '@angular/common/http';
import dayjs from 'dayjs';
import {Branch} from '../../../branch/branch';


@Component({
    selector: 'app-product-update',
    templateUrl: './product-update.component.html',
    styleUrls: ['./product-update.component.scss'],
    encapsulation: ViewEncapsulation.None
})


export class ProductUpdateComponent implements OnInit, OnDestroy {
    // Public
    public avatar = 'assets/images/product/vehiculeAffaire.png';
    public contentHeader: object;
    // public productForm:IProduct | null = null;
    public selectBranches: Branch[];
    public branchSelected;
    public selectCategoriesSelected = [];
    public selectCertificate: Observable<any[]>;
    public selectCertificateSelected = [];
    public ProductImage: string | null = null;
    public fileName = undefined;
    public basicDateOptions: FlatpickrOptions = {
        altInput: true,
        defaultDate: new Date()
    };
    public basicDateFinOptions: FlatpickrOptions = {
        altInput: true
    };
    isSaving = false;
    editForm = this.fb.group({
        productId: [],
        title: [null, [Validators.required]],
        description: [],
        branchId: [],
        branches: [],
        code: [null, [Validators.required]],
        startDate: [Date.now()],
        expirationDate: [],
        certificateId: [null],
        defaultDiscount: [null, [Validators.required, Validators.min(0)]],
    });
    // Private
    private _unsubscribeAll: Subject<any>;

    constructor(private router: Router,
                private _productService: ProductUpdateService,
                private _branchService: BranchService,
                private _coreTranslationService: CoreTranslationService,
                protected activatedRoute: ActivatedRoute,
                protected fb: FormBuilder) {
        this._unsubscribeAll = new Subject();
        this._coreTranslationService.translate(english, french, german, portuguese);
    }

    ngOnInit(): void {

        this.activatedRoute.data.subscribe(({product}) => {
            this.updateForm(product);
            this.loadRelationshipsOptions();
            if (product.productId !== undefined) {
                this.ProductImage = product.image;
                this.fileName = product.fileName;

                this.basicDateOptions.defaultDate = product.startDate;
                this.basicDateFinOptions.defaultDate = product.expirationDate;
                this.contentHeader = {
                    headerTitle: 'Product',
                    actionButton: false,
                    breadcrumb: {
                        type: '',
                        links: [
                            {
                                name: 'Home',
                                isLink: true,
                                link: '/'
                            },
                            {
                                name: 'Product',
                                isLink: true,
                                link: '/apps/product'
                            },
                            {
                                name: 'Edit',
                                isLink: false
                            }
                        ]
                    }
                };
            }
            if (product.productId === undefined) {
                this.basicDateOptions.defaultDate = new Date();
                this.basicDateFinOptions.defaultDate = new Date(Date.now() + 24 * 60 * 60 * 1000);
                this.editForm.get(['startDate'])!.setValue(    this.basicDateOptions.defaultDate );
                this.editForm.get(['expirationDate'])!.setValue(  this.basicDateFinOptions.defaultDate);
                this.ProductImage = this.avatar;
                this._branchService.getBranches().subscribe((data) => {
                    this.selectBranches = data;
                     this.branchSelected= data.at(0);
                    this.editForm.get(['branchId'])!.setValue(this.branchSelected.branchId);
                });
                this.contentHeader = {
                    headerTitle: 'Produit',
                    actionButton: false,
                    breadcrumb: {
                        type: '',
                        links: [
                            {
                                name: 'Home',
                                isLink: true,
                                link: '/'
                            },
                            {
                                name: 'Produit',
                                isLink: true,
                                link: '/apps/product'
                            },
                            {
                                name: 'Add',
                                isLink: false
                            }
                        ]
                    }
                };
            }
        });
    }

    uploadImage(event: any) {
        if (event.target.files && event.target.files[0]) {
            const reader = new FileReader();

            reader.onload = (event: any) => {
                this.ProductImage = event.target.result;
            };

            this.fileName = event.target.files[0].name;
            reader.readAsDataURL(event.target.files[0]);
        }
    }

    onSubmit(product: NgForm) {

        this._productService.addProduct(product.value).subscribe(() => {
            this.router.navigate(['/apps/product']);
        });

    }

    save(): void {
        this.isSaving = true;
        const product = this.createFromForm();
      //  console.log('Your form data : ', product);
        product.image = this.ProductImage !== undefined ? this.ProductImage : null;
        product.fileName = this.fileName !== undefined ? this.fileName : null;
        if (product.productId !== undefined) {
            product.productId = this.editForm.get(['productId'])!.value;
            this.subscribeToSaveResponse(this._productService.updateProduct(product));
        } else {
            this.subscribeToSaveResponse(this._productService.addProduct(product));
        }
    }

    previousState(): void {
        window.history.back();
    }

    /**
     * On destroy
     */
    ngOnDestroy(): void {
        // Unsubscribe from all subscriptions
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }

    protected loadRelationshipsOptions(): void {
    }

    protected updateForm(product: IProduct): void {
        this.editForm.patchValue({
            productId: product.productId,
            title: product.title,
            description: product.description,
            branchId: product.branchId,
            code: product.code,
            image: product.image,
            fileName: product.fileName,
            startDate: product.startDate,
            expirationDate: product.expirationDate,
            certificateId: product.certificateId,
            defaultDiscount: product.defaultDiscount,
        });
        this._branchService.getBranches().subscribe((data) => {
            this.selectBranches = data;
            this.editForm.patchValue({
                branches: data
            });
            this.branchSelected = data.find(item => item.branchId === product.branchId);
            this.editForm.get(['branches'])!.setValue(this.branchSelected);
        });
    }

    protected subscribeToSaveResponse(
        result: Observable<HttpResponse<IProduct>>
    ): void {
        result.pipe(finalize(() => this.onSaveFinalize())).subscribe({
            next: () => this.onSaveSuccess(),
            error: () => this.onSaveError(),
        });
    }

    protected onSaveSuccess(): void {
        this.router.navigate(['/apps/product']);
    }

    protected onSaveError(): void {
        // Api for inheritance.
    }

    protected onSaveFinalize(): void {
        this.isSaving = false;
    }

    // Lifecycle Hooks
    // -----------------------------------------------------------------------------------------------------

    /**
     * On Changes
     */

    public createFromForm(): IProduct {
        if (this.editForm.get(['branchId']).value !== undefined) {
            return {
                ...new Product(),
                productId: this.editForm.get(['productId'])!.value,
                title: this.editForm.get(['title'])!.value,
                description: this.editForm.get(['description'])!.value,
                branchId: this.editForm.get(['branchId'])!.value,
                code: this.editForm.get(['code'])!.value,
                startDate: this.editForm.get(['startDate'])!.value
                    ? dayjs(this.editForm.get(['startDate'])!.value).format('YYYY-MM-DD')

                    : null,
                expirationDate: this.editForm.get(['expirationDate'])!.value
                    ? dayjs(this.editForm.get(['expirationDate'])!.value).format('YYYY-MM-DD')
                    : null,
                certificateId: this.editForm.get(['certificateId'])!.value,
                defaultDiscount: this.editForm.get(['defaultDiscount'])!.value,

            };
        }
        return undefined;
    }

    changeBranch(e: any) {
        this.branchId?.setValue(e.target.value, {
            onlySelf: true,
        });

    }

    get branchId() {
        return this.editForm.get('branchId');
    }

    get productId() {
        return this.editForm.get('productId');
    }

    get title() {
        return this.editForm.get('title');
    }

    get description() {
        return this.editForm.get('description');
    }
    get branches() {
        return this.editForm.get('branches');
    }
    get code() {
        return this.editForm.get('code');
    }
    get startDate() {
        return this.editForm.get('startDate');
    }
    get expirationDate() {
        return this.editForm.get('expirationDate');
    }
    get defaultDiscount() {
        return this.editForm.get('defaultDiscount');
    }
}
