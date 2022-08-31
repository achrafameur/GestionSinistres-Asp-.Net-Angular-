import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CoreTranslationService } from "@core/services/translation.service";
import { Nature } from "../../interfaces/nature";
import { NatureService } from "../nature.service";
import { locale as English } from "../i18n/en";
import { locale as Francais } from "../i18n/fr";
import Swal from "sweetalert2";

@Component({
  selector: "app-nature-update",
  templateUrl: "./nature-update.component.html",
  styleUrls: ["./nature-update.component.scss"],
})
export class NatureUpdateComponent implements OnInit {
  Nature: Nature;
  public contentHeader: object;

  constructor(
    private router: Router,
    private natureService: NatureService,
    private activatedroute: ActivatedRoute,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(English, Francais);
  }

  ngOnInit(): void {
    this.natureService
      .loadNatureById(this.activatedroute.snapshot.params.id)
      .subscribe((data) => (this.Nature = data));
    this.contentHeader = {
      headerTitle: "Nature",
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
            name: "Nature",
            isLink: true,
            link: "/apps/nature/list",
          },
          {
            name: "Update",
            isLink: false,
          },
        ],
      },
    };
  }
  onUpdate(nature: NgForm) {
    this.natureService.updateNature(nature.value, this.Nature.id).subscribe({
      next: () => {
        this.ConfirmTextOpen();
        this.router.navigate(["/apps/nature/list"]);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this nature!",
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
