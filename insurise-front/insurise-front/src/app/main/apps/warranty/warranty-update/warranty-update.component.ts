import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { IWarranty, TypeTarif } from "app/main/pages/interfaces/warranty";
import { WarrantyService } from "../warranty.service";
import { locale as English } from "../i18n/en";
import { locale as Francais } from "../i18n/fr";
import { CoreTranslationService } from "@core/services/translation.service";
import { FeatureDto } from "app/main/pages/interfaces/feature";
import { IWarrantyFeatures } from "app/main/pages/interfaces/warrantyFeatures";
import { FeatureService } from "../../feature/feature.service";
import Swal from "sweetalert2";

@Component({
  selector: "app-warranty-update",
  templateUrl: "./warranty-update.component.html",
  styleUrls: ["./warranty-update.component.scss"],
})
export class WarrantyUpdateComponent implements OnInit {
  Warranty: IWarranty;
  public types: TypeTarif;
  public thisWarrantyFeatureList: IWarrantyFeatures[];
  public contentHeader: object;

  constructor(
    private warrantyService: WarrantyService,
    private router: Router,
    private activatedroute: ActivatedRoute,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(English, Francais);
  }

  ngOnInit(): void {
    this.warrantyService
      .loadWarrantyById(this.activatedroute.snapshot.params.id)
      .subscribe((data) => {
        this.Warranty = data;
        console.log(this.Warranty);
      });
    this.contentHeader = {
      headerTitle: " Warranty ",
      actionButton: false,
      breadcrumb: {
        type: "",
        links: [
          {
            name: "Home",
            isLink: true,
            link: "/",
          },
          {
            name: "Warranty",
            isLink: true,
            link: "/apps/warranty/list",
          },
          {
            name: "Update",
            isLink: false,
          },
        ],
      },
    };
  }
  onUpdate(warranty: NgForm) {
    console.log(warranty.value.typeTarif);
    this.warrantyService
      .updateWarranty(warranty.value, this.Warranty.warrantyId)
      .subscribe({
        next: () => {
          this.ConfirmTextOpen();
          this.router.navigate(["/apps/warranty/list"]);
        },
        error: (error) => {
          console.log(error);
        },
      });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this warranty!",
      icon: "success",
      confirmButtonColor: "#7367F0",
      cancelButtonColor: "#E42728",
      // confirmButtonText: 'Ok',
      customClass: {
        confirmButton: "btn btn-success",
        cancelButton: "btn btn-danger ml-1",
      },
    }).then((result) => {
      if (result) {
        // this.add();
      }
    });
  }
}
