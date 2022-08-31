import { HttpClient, HttpClientModule } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, NgForm, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { CoreTranslationService } from "@core/services/translation.service";
import { ExpertService } from "../expert.service";
import { Chain } from "../models/Chain";
import { ExpertSpec } from "../models/ExpertSpec";
import { sinisterNature } from "../models/SinisterNature";
import { locale as english } from "../i18n/en";
import { locale as french } from "../i18n/fr";
import { SinisterNatureService } from "../../sinister-nature/sinister-nature.service";
import Swal from "sweetalert2";

@Component({
  selector: "app-expert-add",
  templateUrl: "./expert-add.component.html",
  styleUrls: ["./expert-add.component.scss"],
})
export class ExpertAddComponent implements OnInit {
  sexObj = [
    { sexId: 1, title: "Men" },
    { sexId: 2, title: "Women" },
  ];
  public chains: Chain[] = [];
  public chainElements: Chain[] = [];
  public chainsElements: ExpertSpec[] = [];
  public sinisterNatures: sinisterNature[] = [];
  sinNatureId: any;
  chainElmId: any;
  chainElmIds: any;
  sinNatureIds: any;
  public expertSinisterNatures = [];
  public expertSpecialities = [];
  public id: number;
  public contentHeader: object;

  constructor(
    private router: Router,
    private expertService: ExpertService,
    private sinNatureService: SinisterNatureService,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(english, french);
  }

  addExpertForm = new FormGroup({
    typeExpert: new FormControl("", [Validators.required]),
    code: new FormControl("", [Validators.required]),
    fName: new FormControl("", [Validators.required]),
    lName: new FormControl("", [Validators.required]),
    cin: new FormControl("", [Validators.required]),
    email: new FormControl("", [Validators.required]),
    birthDate: new FormControl(),
    sexId: new FormControl("", [Validators.required]),
    tel: new FormControl("", [Validators.required]),
    fixe: new FormControl("", [Validators.required]),
    fax: new FormControl("", [Validators.required]),
    governorate: new FormControl("", [Validators.required]),
    address: new FormControl("", [Validators.required]),
    cancellationDate: new FormControl(),
    registrationDate: new FormControl(),
  });

  ngOnInit(): void {
    this.sinNatureService.getSinisterNatures().subscribe((data) => {
      this.sinisterNatures = data;
    });
    this.expertService.getChains().subscribe((data) => {
      this.chains = data;
    });
    this.contentHeader = {
      headerTitle: "Expert",
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
            name: "Expert",
            isLink: true,
            link: "/apps/expert/list",
          },
          {
            name: "add",
            isLink: false,
          },
        ],
      },
    };
  }

  // add(expert: NgForm) {
  //   this.expertService.addExpert(expert.value).subscribe((data) => {
  //     this.id = data;
  //     return this.id;
  //   });
  // }

  submit(expertSpecialities: NgForm, expertSinNatures: NgForm) {
    if (this.confirmCinSubmit() == false) {
      this.Error = {
        isError: true,
        errorMessage: `This field must contain a valid CIN number`,
      };
      this.FError = { isError: true, errorMessage: `` };
      this.FaxError = { isError: true, errorMessage: `` };
      this.PError = { isError: true, errorMessage: `` };
    } else if (this.confirmPhoneSubmit() == false) {
      this.Error = { isError: true, errorMessage: `` };
      this.FError = { isError: true, errorMessage: `` };
      this.FaxError = { isError: true, errorMessage: `` };
      this.PError = {
        isError: true,
        errorMessage: `This field must contain a valid Phone number`,
      };
    } else if (this.confirmFaxSubmit() == false) {
      this.Error = { isError: true, errorMessage: `` };
      this.FError = { isError: true, errorMessage: `` };
      this.FaxError = {
        isError: true,
        errorMessage: `This field must contain a valid fax number`,
      };
      this.PError = { isError: true, errorMessage: `` };
    } else if (this.confirmFixeSubmit() == false) {
      this.Error = { isError: true, errorMessage: `` };
      this.FError = {
        isError: true,
        errorMessage: `This field must contain a valid fixe number`,
      };
      this.FaxError = { isError: true, errorMessage: `` };
      this.PError = { isError: true, errorMessage: `` };
    } else {
      this.expertService
        .addExpert(this.addExpertForm.value)
        .subscribe((data) => {
          this.id = data;
          this.sinNatureId = this.sinisterNatures
            .filter((x) => x.isChecked == true)
            .map((x) => x.sinisterNatureId)
            .toString();
          console.log(this.sinNatureId);
          this.sinNatureIds = this.sinNatureId.split(",");
          for (let i = 0; i < this.sinNatureIds.length; i++) {
            if (expertSinNatures.value.sinisterNatureId == true) {
              this.expertSinisterNatures.push({
                sinisterNatureId: this.sinNatureIds[i],
              });
            }
          }
          this.expertService
            .setSinisterNatures(this.expertSinisterNatures, this.id)
            .subscribe(() => {});

          for (let i = 0; i < this.chains.length; i++) {
            if (this.chains[i].title == "specialities") {
              this.chainElmId = this.chains[i].elements
                .filter((x) => x.isChecked == true)
                .map((x) => x.chainElementId)
                .toString();
              console.log(this.chainElmId);
              this.chainElmIds = this.chainElmId.split(",");
              console.log(this.chainElmIds);
              for (let i = 0; i < this.chainElmIds.length; i++) {
                if (expertSpecialities.value.chainElementId == true) {
                  this.expertSpecialities.push({
                    mandatory: false,
                    chainElementId: this.chainElmIds[i],
                  });
                }
              }
            }
          }
          this.expertService
            .setSpecialities(this.expertSpecialities, this.id)
            .subscribe(() => {
              this.ConfirmTextOpen();
              this.router.navigate(["/apps/expert/list"]);
            });
        });
    }
  }

  onChange() {
    console.log(this.chains);
    console.log(this.chainsElements);
  }
  onChangeSinNat() {
    console.log(this.sinisterNatures);
  }

  Error: any = { isError: false, errorMessage: "" };
  confirmCinSubmit(): Boolean {
    var phoneInputLength = (<HTMLInputElement>document.getElementById("cin"))
      .value.length;
    console.log(phoneInputLength);
    if (phoneInputLength !== 8) {
      this.Error = { isError: true, errorMessage: "" };
      return false;
    } else {
      return true;
    }
  }

  PError: any = { isError: false, errorMessage: "" };
  confirmPhoneSubmit(): Boolean {
    var phoneInputLength = (<HTMLInputElement>document.getElementById("phone"))
      .value.length;
    console.log(phoneInputLength);
    if (phoneInputLength !== 8) {
      this.Error = { isError: true, errorMessage: "" };
      return false;
    } else {
      return true;
    }
  }

  FaxError: any = { isError: false, errorMessage: "" };
  confirmFaxSubmit(): Boolean {
    var phoneInputLength = (<HTMLInputElement>document.getElementById("fax"))
      .value.length;
    console.log(phoneInputLength);
    if (phoneInputLength !== 8) {
      this.Error = { isError: true, errorMessage: "" };
      return false;
    } else {
      return true;
    }
  }

  FError: any = { isError: false, errorMessage: "" };
  confirmFixeSubmit(): Boolean {
    var phoneInputLength = (<HTMLInputElement>document.getElementById("fixe"))
      .value.length;
    console.log(phoneInputLength);
    if (phoneInputLength !== 8) {
      this.Error = { isError: true, errorMessage: "" };
      return false;
    } else {
      return true;
    }
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new expert!",
      icon: 'success',
      confirmButtonColor: '#7367F0',
      cancelButtonColor: '#E42728',
      confirmButtonText: 'Ok',
      customClass: {
        confirmButton: 'btn btn-success',
        cancelButton: 'btn btn-danger ml-1'
      }
    }).then((result) =>{
      if (result) {
        // this.add();
      }
    });
  }
}
