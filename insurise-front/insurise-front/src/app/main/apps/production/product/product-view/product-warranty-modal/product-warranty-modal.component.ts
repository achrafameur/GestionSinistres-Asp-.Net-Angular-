import { Component, Injectable, Input, OnInit, TemplateRef, ViewChild } from '@angular/core'
import { NgbModal, NgbModalRef } from '@ng-bootstrap/ng-bootstrap'
import {ModalConfig} from "./ModalConfig";

@Component({
    selector: 'modal',
    templateUrl: 'product-warranty-modal.component.html'
    //styleUrls: ['product-warranty-modal.component.scss']
})
@Injectable()
export class ProductWarrantyModalComponent  implements OnInit {
    @Input() public modalConfig: ModalConfig
    @ViewChild('modal') private modalContent: TemplateRef<ProductWarrantyModalComponent>
    @ViewChild('modal') private modalComponent: ProductWarrantyModalComponent
    private modalRef: NgbModalRef

    constructor(private modalService: NgbModal) {
    }

    async openModal() {
        return await this.modalComponent.open()
    }

    ngOnInit(): void {
    }

    open(): Promise<boolean> {
        return new Promise<boolean>(resolve => {
            this.modalRef = this.modalService.open(this.modalContent)
            this.modalRef.result.then(resolve, resolve)
        })
    }

    async close(): Promise<void> {
        if (this.modalConfig.shouldClose === undefined || (await this.modalConfig.shouldClose())) {
            const result = this.modalConfig.onClose === undefined || (await this.modalConfig.onClose())
            this.modalRef.close(result)
        }
    }

    async dismiss(): Promise<void> {
        if (this.modalConfig.shouldDismiss === undefined || (await this.modalConfig.shouldDismiss())) {
            const result = this.modalConfig.onDismiss === undefined || (await this.modalConfig.onDismiss())
            this.modalRef.dismiss(result)
        }
    }
}
