import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ThirdPartyService } from "../third-party.service";
import { locale as english } from "../i18n/en";
import { locale as french } from "../i18n/fr";
import { CoreTranslationService } from "@core/services/translation.service";
import Swal from "sweetalert2";

@Component({
  selector: "app-third-party-update",
  templateUrl: "./third-party-update.component.html",
  styleUrls: ["./third-party-update.component.scss"],
})
export class ThirdPartyUpdateComponent implements OnInit {
  thirdPartyCompaniesList: any;
  ThirdParty: any;
  id: any;
  public contentHeader: object;

  constructor(
    private router: Router,
    private thirdPartyService: ThirdPartyService,
    private ar: ActivatedRoute,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.id = this.ar.snapshot.params.id;
    this.thirdPartyService
      .getThirdPartyById(this.id)
      .subscribe((data) => (this.ThirdParty = data));
    this.thirdPartyService.getThirdPartyCompanies().subscribe((data) => {
      this.thirdPartyCompaniesList = data;
    });
    this.contentHeader = {
      headerTitle: "ThirdParty",
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
            name: "ThirdParty",
            isLink: true,
            link: "/apps/third-party/list",
          },
          {
            name: "update",
            isLink: false,
          },
        ],
      },
    };
  }

  update(third: NgForm) {
    this.thirdPartyService.updateThirdParty(third.value, this.id).subscribe({
      next: () => {
        this.ConfirmTextOpen();
        this.router.navigate(["/apps/third-party/list"]);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this third party!",
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
