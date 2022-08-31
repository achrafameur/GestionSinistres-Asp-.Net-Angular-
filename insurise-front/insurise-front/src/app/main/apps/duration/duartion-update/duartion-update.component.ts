import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import Swal from "sweetalert2";
import { DuartionService } from "../duartion.service";

@Component({
  selector: "app-duartion-update",
  templateUrl: "./duartion-update.component.html",
  styleUrls: ["./duartion-update.component.scss"],
})
export class DuartionUpdateComponent implements OnInit {
  typesList = [
    { id: 1, title: "Variable" },
    { id: 2, title: "Fixe" },
  ];
  id: any;
  Duration: any;
  public contentHeader: object;
  constructor(
    private router: Router,
    private durationService: DuartionService,
    private ar: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id = this.ar.snapshot.params.id;
    this.durationService.getDurationById(this.id).subscribe((data) => {
      this.Duration = data;
    });
    this.contentHeader = {
      headerTitle: "Duration",
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
            name: "Duration",
            isLink: true,
            link: "/apps/duration/list",
          },
          {
            name: "update",
            isLink: false,
          },
        ],
      },
    };
  }

  update(duration: NgForm) {
    if (this.compareDates() == false) {
      this.error = {
        isError: true,
        errorMessage: `End Date can't be before Start date`,
      };
    } else {
      this.durationService.updateDuration(duration.value, this.id).subscribe({
        next: () => {
          this.ConfirmTextOpen();
          this.router.navigate(["/apps/duration/list"]);
        },
        error: (err) => {
          console.log(err);
        },
      });
    }
  }

  error: any = { isError: false, errorMessage: "" };
  compareDates(): Boolean {
    var startDate = (<HTMLInputElement>document.getElementById("startDate"))
      .value;
    console.log(startDate);
    var endDate = (<HTMLInputElement>document.getElementById("endDate")).value;
    console.log(endDate);
    if (startDate > endDate) {
      this.error = { isError: true, errorMessage: "" };
      return false;
    } else {
      return true;
    }
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this duration!",
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
