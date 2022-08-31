import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { StatusService } from "../status.service";
import { CoreTranslationService } from "@core/services/translation.service";
import { locale as english } from "../i18n/en";
import { locale as french } from "../i18n/fr";
import Swal from "sweetalert2";

@Component({
  selector: "app-status-update",
  templateUrl: "./status-update.component.html",
  styleUrls: ["./status-update.component.scss"],
})
export class StatusUpdateComponent implements OnInit {
  itemList: any;
  Status: any;
  id: any;
  public contentHeader: object;

  constructor(
    private router: Router,
    private statusService: StatusService,
    private ar: ActivatedRoute,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.id = this.ar.snapshot.params.id;
    this.statusService
      .getStatusById(this.id)
      .subscribe((data) => (this.Status = data));
    this.statusService.getItems().subscribe((data) => {
      this.itemList = data;
    });
    this.contentHeader = {
      headerTitle: "Status",
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
            name: "Status",
            isLink: true,
            link: "/apps/status/list",
          },
          {
            name: "update",
            isLink: false,
          },
        ],
      },
    };
  }

  update(status: NgForm) {
    this.statusService.updateStatus(status.value, this.id).subscribe({
      next: () => {
        this.ConfirmTextOpen();
        this.router.navigate(["/apps/status/list"]);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this status!",
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
