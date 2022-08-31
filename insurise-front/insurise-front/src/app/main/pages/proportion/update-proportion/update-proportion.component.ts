import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { Proportion } from "../../interfaces/proportion";
import { ProportionService } from "../proportion.service";
import { locale as English } from "../i18n/en";
import { locale as Francais } from "../i18n/fr";
import { CoreTranslationService } from "@core/services/translation.service";
import Swal from "sweetalert2";

@Component({
  selector: "app-update-proportion",
  templateUrl: "./update-proportion.component.html",
  styleUrls: ["./update-proportion.component.scss"],
})
export class UpdateProportionComponent implements OnInit {
  Proportion: Proportion;
  public contentHeader: object;

  constructor(
    private router: Router,
    private proportionService: ProportionService,
    private activatedroute: ActivatedRoute,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(English, Francais);
  }

  ngOnInit(): void {
    this.proportionService
      .loadProportionById(this.activatedroute.snapshot.params.id)
      .subscribe((data) => {
        this.Proportion = data;
        console.log(data);
      });
    this.contentHeader = {
      headerTitle: "Proportion",
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
            name: "Proportion",
            isLink: true,
            link: "/apps/proportion/list",
          },
          {
            name: "Update",
            isLink: false,
          },
        ],
      },
    };
  }
  onUpdate(proportion: NgForm) {
    this.proportionService
      .updateProportion(proportion.value, this.Proportion.proportionId)
      .subscribe({
        next: () => {
          console.log(proportion);
          this.ConfirmTextOpen();
          this.router.navigate(["/apps/proportion/list"]);
        },
        error: (error) => {
          console.log(error);
        },
      });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this proportion!",
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
