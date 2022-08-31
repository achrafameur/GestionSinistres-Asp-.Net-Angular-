import {Component, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';

import {combineLatest, Subject} from 'rxjs';
import {ColumnMode, DatatableComponent, SelectionType} from '@swimlane/ngx-datatable';

import {CoreTranslationService} from '@core/services/translation.service';

import {locale as german} from 'app/main/apps/production/product/i18n/de';
import {locale as english} from 'app/main/apps/production/product/i18n/en';
import {locale as french} from 'app/main/apps/production/product/i18n/fr';
import {locale as portuguese} from 'app/main/apps/production/product/i18n/pt';

import {ProductService} from "./product.service";
import {BranchService} from "../../branch/branch.service";
import {IProduct} from "./model/product";
import {ProductDeleteDialogComponent} from "./product-delete/product-delete-dialog.component";
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {ASC, DESC, ITEMS_PER_PAGE, SORT} from "../../config/pagination.constants";
import {HttpHeaders, HttpResponse} from "@angular/common/http";
import {ActivatedRoute, Router} from "@angular/router";
import { Console } from 'console';


@Component({
    selector: 'app-product',
    templateUrl: './product.component.html',
    styleUrls: ['./product.component.scss'],
    encapsulation: ViewEncapsulation.None
})
export class ProductComponent implements OnInit {
    // Private
    private tempData = [];
  
    // public
    public selectedBranch = [];
    public selectBranch: any = [];
    public contentHeader: object;
    public rows: any;
    public selected = [];
    public kitchenSinkRows: any;
    public selectedOption = 10;
    public ColumnMode = ColumnMode;
    public expanded = {};
    public editingName = {};
    public editingStatus = {};
    public editingAge = {};
    public editingSalary = {};
    public chkBoxSelected = [];
    public SelectionType = SelectionType;
    public exportCSVData;
    readonly headerHeight = 50;
    readonly rowHeight = 50;
    readonly pageLimit = 10;
    readonly footerHeight = 50;
    isLoading: boolean = false;
    pageTitle = 'Product List';
    public previousBranchFilter = '';
    public temp = [];
    public searchValue = '';
    ShowHide: boolean = false;
    products?: IProduct[];
    totalItems = 0;
    itemsPerPage = ITEMS_PER_PAGE;
    page?: number;
    predicate!: string;
    ascending!: boolean;
    ngbPaginationPage = 1;
    public branchfilter = '';

    @ViewChild(DatatableComponent) table: DatatableComponent;
    @ViewChild('tableRowDetails') tableRowDetails: any;


    // Public Methods
    // -----------------------------------------------------------------------------------------------------

    /**
     * Filter By Branches
     *
     * @param event
     */
    filterByBranch(event) {
        const filter = event ? event.title : '';
        this.searchValue = event.branchId;
        this.loadPage(1, true);
     /*   this.temp = this.filterRows(filter);
        this.products = this.temp;*/
    }
    filterByselectedOption(event) {
        this.itemsPerPage = this.selectedOption;
        this.loadPage(1, true);
    }
    /**
     * Filter Rows
     *
     * @param branchFilter
     */
    filterRows(branchFilter): any[] {
        // Reset search on select change

        branchFilter = branchFilter.toLowerCase();

        return this.tempData.filter(row => {
            return row.branch.toLowerCase().indexOf(branchFilter) !== -1 || !branchFilter  ;
        });
    }


    /**
     * Search (filter)
     *
     * @param event
     */
    filterUpdate(event) {
        this.selectedBranch = this.selectBranch[0];
        const val = event.target.value.toLowerCase();

        // filter our data
        // update the rows
        this.products = this.tempData.filter(function (d) {
            return d.title.toLowerCase().indexOf(val) !== -1 || !val;
        });
        // Whenever the filter changes, always go back to the first page
        this.table.offset = 0;
    }

    /**
     * Row Details Toggle
     *
     * @param row
     */
    rowDetailsToggleExpand(row) {
        this.tableRowDetails.rowDetail.toggleExpandRow(row);
    }

    /**
     * For ref only, log selected values
     *
     * @param selected
     */
    onSelect({ selected }): void {
        console.log('Select Event', selected, this.selected);

        this.selected.splice(0, this.selected.length);
        // this.selected.push(...selected);
    }

    /**
     * For ref only, log activate events
     *
     * @param selected
     */
    onActivate(event) {
        // console.log('Activate Event', event);
    }

    /**
     * Custom Chkbox On Select
     *
     * @param { selected }
     */
    customChkboxOnSelect({ selected }) {
        this.chkBoxSelected.splice(0, this.chkBoxSelected.length);
        // this.chkBoxSelected.push(...selected);
    }



    // Lifecycle Hooks
    // -----------------------------------------------------------------------------------------------------
    /**
     * Constructor
     *
     * @param {DatatablesService} _datatablesService
     * @param {CoreTranslationService} _coreTranslationService
     */
    constructor(private _productService: ProductService, private _branchService : BranchService,protected activatedRoute: ActivatedRoute
        , private _coreTranslationService: CoreTranslationService , protected modalService: NgbModal,   protected router: Router) {
       // this._unsubscribeAll = new Subject();
        this._coreTranslationService.translate(english, french, german, portuguese);
    }
    /**
     * On init
     */
    ngOnInit() {

        this.handleNavigation();
        this._branchService.getBranches().subscribe((data)=>{
            this.selectBranch=data;
            console.log(data);
            
        })
        // content header

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
                        isLink: false,
                        link: '/'
                    },
                    {
                        name: 'List',
                        isLink: false
                    }
                ]
            }
        };
    }

    protected handleNavigation(): void {
        combineLatest([
            this.activatedRoute.data,
            this.activatedRoute.queryParamMap,
        ]).subscribe(([data, params]) => {
            const page = params.get("page");
            const pageNumber = +(page ?? 1);
            const sort = (params.get(SORT) ?? data["defaultSort"]).split(",");
            const predicate = sort[0];
            const ascending = sort[1] === ASC;
            if (
                pageNumber !== this.page ||
                predicate !== this.predicate ||
                ascending !== this.ascending
            ) {
                this.predicate = predicate;
                this.ascending = ascending;
                this.loadPage(pageNumber, true);
            }
        });
    }
    trackId(_index: number, item: IProduct): number {
        return item.productId!;
    }
    delete(product: IProduct): void {
        const modalRef = this.modalService.open(ProductDeleteDialogComponent, {
            size: "lg",
            backdrop: "static",
        });
        modalRef.componentInstance.product = product;
        // unsubscribe not needed because closed completes on modal close
        modalRef.closed.subscribe((reason) => {
            if (reason === "deleted") {
                this.loadPage();
            }
        });
    }
    loadPage(page?: number, dontNavigate?: boolean): void {
        this.isLoading = true;
        const pageToLoad: number = page ?? this.page ?? 1;

        this._productService
            .query({
                page: pageToLoad  ,
                pageSize: this.itemsPerPage,
                sort: this.sort(),
                branchId: this.searchValue
            })
            .subscribe({
                next: (res: HttpResponse<IProduct[]>) => {
                    this.isLoading = false;
                    this.onSuccess(res.body, res.headers, pageToLoad, !dontNavigate);
                },
                error: () => {
                    this.isLoading = false;
                    this.onError();
                },
            });
    }

    protected sort(): string[] {
        const result = [this.predicate + "," + (this.ascending ? ASC : DESC)];
        if (this.predicate !== "id") {
            result.push("id");
        }
        return result;
    }
    protected onError(): void {
        this.ngbPaginationPage = this.page ?? 1;
    }
    protected onSuccess(
        data: IProduct[] | null,
        headers: HttpHeaders,
        page: number,
        navigate: boolean
    ): void {
        this.totalItems = Number(headers.get("X-Total-Count"));
        this.page = page;
        if (navigate) {
            this.router.navigate(["/apps/product"], {
                queryParams: {
                    page: this.page,
                    pageSize: this.itemsPerPage,
                    sort: this.predicate + "," + (this.ascending ? ASC : DESC),
                    branchId: this.searchValue
                },
            });
        }
        this.products = data ?? [];
        this.tempData = this.products;
        // this.exportCSVData = this.products;
        this.ngbPaginationPage = this.page;
    }


    // exportCSV() {

    // }
}
