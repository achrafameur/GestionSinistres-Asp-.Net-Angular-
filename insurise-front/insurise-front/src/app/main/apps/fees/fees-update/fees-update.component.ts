import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import Swal from "sweetalert2";
import { FeesService } from "../fees.service";

@Component({
  selector: "app-fees-update",
  templateUrl: "./fees-update.component.html",
  styleUrls: ["./fees-update.component.scss"],
})
export class FeesUpdateComponent implements OnInit {
  typesList = [
    { id: 1, title: "Fond" },
    { id: 2, title: "Frais" },
  ];
  public contentHeader: object;
  id: any;
  Fee: any;
  constructor(
    private router: Router,
    private feesService: FeesService,
    private ar: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.id = this.ar.snapshot.params.id;
    this.feesService.getFeeById(this.id).subscribe((data) => {
      this.Fee = data;
    });
    this.contentHeader = {
      headerTitle: "Fee",
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
            name: "Fee",
            isLink: true,
            link: "/apps/fees/list",
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
    this.feesService.updateFee(duration.value, this.id).subscribe({
      next: () => {
        this.ConfirmTextOpen();
        this.router.navigate(["/apps/fees/list"]);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this fee!",
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
