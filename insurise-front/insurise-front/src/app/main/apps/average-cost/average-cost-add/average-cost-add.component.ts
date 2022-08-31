import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, NgForm, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AverageCostService } from "../average-cost.service";
import { CoreTranslationService } from "@core/services/translation.service";
import { locale as english } from "../i18n/en";
import { locale as french } from "../i18n/fr";
import {
  basicDateSnippetCode,
  customDateSnippetCode,
  DateRangeSnippetCode,
  dateTimeSnippetCode,
  DefaultDateSnippetCode,
  multipleDateSnippetCode,
  timeSnippetCode,
} from "app/main/forms/form-elements/flatpickr/flatpickr.snippetcode";
import { FlatpickrOptions } from "ng2-flatpickr";
import Swal from "sweetalert2";

@Component({
  selector: "app-average-cost-add",
  templateUrl: "./average-cost-add.component.html",
  styleUrls: ["./average-cost-add.component.scss"],
})
export class AverageCostAddComponent implements OnInit {
  public _basicDateSnippetCode = basicDateSnippetCode;
  public _dateTimeSnippetCode = dateTimeSnippetCode;
  public _DefaultDateSnippetCode = DefaultDateSnippetCode;
  public _DateRangeSnippetCode = DateRangeSnippetCode;
  public _timeSnippetCode = timeSnippetCode;
  public _customDateSnippetCode = customDateSnippetCode;
  public _multipleDateSnippetCode = multipleDateSnippetCode;
  AllAverageCosts: any;
  sinisterNatureList: any;
  year = new Date().getFullYear();
  public contentHeader: object;

  constructor(
    private router: Router,
    private averageCostService: AverageCostService,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(english, french);
  }

  addAveragCostForm = new FormGroup({
    averageCost: new FormControl("", [Validators.required]),
    dateStart: new FormControl("", [Validators.required]),
    dateEnd: new FormControl("", [Validators.required]),
    sinisterNatureId: new FormControl("", [Validators.required]),
  });

  ngOnInit(): void {
    this.averageCostService.getSinisterNatures().subscribe((data) => {
      this.sinisterNatureList = data;
    });
    this.averageCostService.getAverageCosts().subscribe((data) => {
      this.AllAverageCosts = data;
      console.log(this.AllAverageCosts);
    });
    document
      .getElementById("dateStart")
      .setAttribute("min", this.year + "-01-01");
    document
      .getElementById("dateStart")
      .setAttribute("max", this.year + "-12-31");

    document
      .getElementById("dateEnd")
      .setAttribute("min", this.year + "-01-01");
    document
      .getElementById("dateEnd")
      .setAttribute("max", this.year + "-12-31");

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
            name: "add",
            isLink: false,
          },
        ],
      },
    };
  }

  FormError: any = { isError: false, errorMessage: "" };
  add() {
    if (this.compareDates() == false) {
      this.FormError = {
        isError: true,
        errorMessage: `End Date can't be before Start date`,
      };
      this.intervalDateError = { isError: true, errorMessage: `` };
    } else if (this.confirmStartDate() == false) {
      this.intervalDateError = {
        isError: true,
        errorMessage: `this date interval is already used`,
      };
      this.FormError = { isError: true, errorMessage: `` };
    } else {
      this.averageCostService
        .addAverageCost(this.addAveragCostForm.value)
        .subscribe(() => {
          this.ConfirmTextOpen();
          this.router.navigate(["/apps/average-cost/list"]);
        });
    }
  }

  error: any = { isError: false, errorMessage: "" };
  compareDates(): Boolean {
    var startDate = (<HTMLInputElement>document.getElementById("dateStart"))
      .value;
    console.log(startDate);
    var endDate = (<HTMLInputElement>document.getElementById("dateEnd")).value;
    console.log(endDate);
    if (startDate > endDate) {
      this.error = { isError: true, errorMessage: "" };
      return false;
    } else {
      return true;
    }
  }

  intervalDateError: any = { isError: false, errorMessage: "" };
  confirmStartDate(): Boolean {
    var startdate = (<HTMLInputElement>document.getElementById("dateStart"))
      .value;
    console.log(startdate);
    var endDate = (<HTMLInputElement>document.getElementById("dateEnd")).value;
    console.log(endDate);
    var sinisterNature = (<HTMLInputElement>(
      document.getElementById("sinisterNature")
    )).value;
    console.log(sinisterNature);
    for (let el = 0; el < this.AllAverageCosts.length; el++) {
      console.log(this.AllAverageCosts);
      // if (this.AllAverageCosts[el].sinisterNature == sinisterNature) {
        var dateTable = []
        var sdateTimeInParts = this.AllAverageCosts[el].startDate
          .toString()
          .split("T");
        console.log(sdateTimeInParts);
        const sDate = sdateTimeInParts[0];
        console.log(sDate);

        var edateTimeInParts = this.AllAverageCosts[el].endDate
          .toString()
          .split("T");
        console.log(edateTimeInParts);
        const eDate = edateTimeInParts[0];
        console.log(eDate);

        if (
          (startdate == sDate || endDate == eDate)
        ) {
          this.intervalDateError = { isError: true, errorMessage: "" };
          return false;
        } else {
          return true;
        }
      }
    // }
  }

  public basicDateOptions: FlatpickrOptions = {
    altInput: true,
  };

  ConfirmTextOpen() {
    Swal.fire({
      title: "Success!",
      text: "You have successfully added a new average cost!",
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
