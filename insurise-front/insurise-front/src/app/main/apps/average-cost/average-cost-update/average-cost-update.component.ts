import { ClassGetter } from "@angular/compiler/src/output/output_ast";
import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CoreTranslationService } from "@core/services/translation.service";
import Swal from "sweetalert2";
import { AverageCostService } from "../average-cost.service";
import { locale as english } from "../i18n/en";
import { locale as french } from "../i18n/fr";

@Component({
  selector: "app-average-cost-update",
  templateUrl: "./average-cost-update.component.html",
  styleUrls: ["./average-cost-update.component.scss"],
})
export class AverageCostUpdateComponent implements OnInit {
  sinisterNatureList: any;
  AVGCost: any;
  id: any;
  public StartDate: any;
  public EndDate: any;
  public contentHeader: object;
  public sDate : any ;
  public eDate : any ;

  constructor(
    private router: Router,
    private averageCostService: AverageCostService,
    private ar: ActivatedRoute,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.id = this.ar.snapshot.params.id;
    this.averageCostService.getAverageCostById(this.id).subscribe((data) => {
      this.AVGCost = data;
      console.log(this.AVGCost);
      var sdateTimeInParts = this.AVGCost.startDate
          .toString()
          .split("T");
        console.log(sdateTimeInParts);
        this.sDate = sdateTimeInParts[0];
        console.log(this.sDate);

      var edateTimeInParts = this.AVGCost.endDate
      .toString()
      .split("T");
      console.log(edateTimeInParts);
      this.eDate = edateTimeInParts[0];
      console.log(this.eDate);
      // const day = this.AVGCost.startDate.getDate();
      // const month = this.AVGCost.startDate.getMonth();
      // const year = this.AVGCost.startDate.getFullYear();
      // this.StartDate= year+"-"+(month+1)+"-"+day;
      // console.log(this.AVGCost.startDate)
    });
    this.averageCostService.getSinisterNatures().subscribe((data) => {
      this.sinisterNatureList = data;
    });

    this.contentHeader = {
      headerTitle: "SinisterNatureAverageCost",
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
            name: "SinisterNatureAverageCost",
            isLink: true,
            link: "/apps/average-cost/list",
          },
          {
            name: "update",
            isLink: false,
          },
        ],
      },
    };
  }

  update(avgcost: NgForm) {
    this.averageCostService
      .updateAverageCost(avgcost.value, this.id)
      .subscribe({
        next: () => {
          this.ConfirmTextOpen();
          this.router.navigate(["/apps/average-cost/list"]);
        },
        error: (err) => {
          console.log(err);
        },
      });
  }

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully updated this average cost!",
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
