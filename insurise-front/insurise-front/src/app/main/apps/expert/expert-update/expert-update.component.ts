import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import Swal from "sweetalert2";
import { SinisterNatureService } from "../../sinister-nature/sinister-nature.service";
import { ExpertService } from "../expert.service";
import { attachedSinisterNature } from "../models/AttachedSinisterNature";
import { Chain } from "../models/Chain";
import { ExpertSpec } from "../models/ExpertSpec";
import { sinisterNature } from "../models/SinisterNature";

@Component({
  selector: "app-expert-update",
  templateUrl: "./expert-update.component.html",
  styleUrls: ["./expert-update.component.scss"],
})
export class ExpertUpdateComponent implements OnInit {
  sexObj = [
    { sexId: 1, title: "Men" },
    { sexId: 2, title: "Women" },
  ];
  id: any;
  Expert: any;
  SinNatures: any;
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
  public attachedSinNatures = [];
  public contentHeader: object;
  public regDate: any ;
  public canDate: any ;
  public birthDate: any ;

  constructor(
    private router: Router,
    private expertService: ExpertService,
    private ar: ActivatedRoute,
    private sinNatureService: SinisterNatureService
  ) {}

  ngOnInit(): void {
    this.id = this.ar.snapshot.params.id;
    this.expertService
      .getExpertById(this.id)
      .subscribe((data) =>{ 
        this.Expert = data
        var regdateTimeInParts = this.Expert.registrationDate
        .toString()
        .split("T");
        console.log(regdateTimeInParts);
        this.regDate = regdateTimeInParts[0];
        console.log(this.regDate);

        var candateTimeInParts = this.Expert.cancellationDate
        .toString()
        .split("T");
        console.log(candateTimeInParts);
        this.canDate = candateTimeInParts[0];
        console.log(this.canDate);

        var birthdateTimeInParts = this.Expert.birthDate
        .toString()
        .split("T");
        console.log(birthdateTimeInParts);
        this.birthDate = birthdateTimeInParts[0];
        console.log(this.birthDate);
      
      });
      
    this.expertService.getExpertSinisterNatures(this.id).subscribe((data) => {
      this.attachedSinNatures = data;
      console.log(this.attachedSinNatures);
    });
    this.sinNatureService.getSinisterNatures().subscribe((data) => {
      this.sinisterNatures = data;
      // for (let i = 0; i < this.sinisterNatures.length; i++) {
      //   for (let j = 0; j < this.attachedSinNatures.length; j++) {
      //     if (this.attachedSinNatures[j].sinisterNatureId = this.sinisterNatures[i].sinisterNatureId )
      //     {
      //       this.sinisterNatures[i].isChecked = true;
      //     }
      //   }
      // }
      console.log(this.sinisterNatures);
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
            name: "update",
            isLink: false,
          },
        ],
      },
    };
  }

  update(expert: NgForm) {
    this.expertService.updateExpert(expert.value, this.id).subscribe(() => {
      this.ConfirmTextOpen();
      this.router.navigate(["/apps/expert/list"]);
    });
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully updated this expert!",
      icon: 'success',
      confirmButtonColor: '#7367F0',
      cancelButtonColor: '#E42728',
      // confirmButtonText: 'Ok',
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
