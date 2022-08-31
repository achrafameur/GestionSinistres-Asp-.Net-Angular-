import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BranchService } from 'app/main/apps/branch/branch.service';
import { SinisterNatureService } from '../sinister-nature.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-sinister-nature-update',
  templateUrl: './sinister-nature-update.component.html',
  styleUrls: ['./sinister-nature-update.component.scss']
})
export class SinisterNatureUpdateComponent implements OnInit {
  
  branchList:any
  id:any
  SinNature:any
  public contentHeader : object ; 
  
  constructor(private router : Router ,private sinisterNatureService : SinisterNatureService ,private ar: ActivatedRoute
    ,private branchService:BranchService,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.sinisterNatureService.getSinisterNatureById(this.id).subscribe((data)=>{
      this.SinNature=data
    })
    this.branchService.getBranches().subscribe((data)=>{
      this.branchList=data
    })
    this.contentHeader = {
      headerTitle: 'SinisterNature',
      actionButton: false,
      breadcrumb: {
          type: '',
          links: [
              {
                  name: 'Home',
                  isLink: true,
                  link: '/'
              },
              {
                  name: 'SinisterNature',
                  isLink: true,
                  link: '/apps/sinisterNature/list'
              },
              {
                  name: 'update',
                  isLink: false
              }
          ]
      }
    };
  }

  update(sinNat:NgForm){
    this.sinisterNatureService.updateSinisterNature(sinNat.value,this.id).subscribe( {next:()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/sinisterNature/list'])
      },
      error:(err)=>{
        console.log(err)
      }
    })
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully updated this sinister nature!",
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
