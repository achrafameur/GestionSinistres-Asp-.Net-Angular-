import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BranchService } from 'app/main/apps/branch/branch.service';
import { SinisterNatureService } from '../sinister-nature.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-sinister-nature',
  templateUrl: './add-sinister-nature.component.html',
  styleUrls: ['./add-sinister-nature.component.scss']
})
export class AddSinisterNatureComponent implements OnInit {

  branchList:any
  public contentHeader : object ; 

  constructor(private router:Router,private branchService:BranchService,private sinisterNatureService:SinisterNatureService,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  
  addSinisterNatureForm = new FormGroup({
    title:new FormControl( '' , [Validators.required] ),
    code:new FormControl( '' , [Validators.required] ),
    branchId:new FormControl( '' , [Validators.required]),
    idaEnabled:new FormControl(),
    transactionEnabled:new FormControl(),
    thirdPartyEnabled:new FormControl(),
    victimEnabled:new FormControl(),
    respEnabled:new FormControl(),
    respAutoEnabled:new FormControl(),
    affaireEnabled:new FormControl(),
    expertiseEnabled:new FormControl(),
    evalInterneEnabled:new FormControl(),
    evalInterneCorpEnabled:new FormControl(),
    regExpertEnabled:new FormControl(),
  })

  ngOnInit(): void {
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
                  name: 'add',
                  isLink: false
              }
          ]
      }
    };
  }

  add(){
    if(this.addSinisterNatureForm.value.idaEnabled==null){
      this.addSinisterNatureForm.value.idaEnabled =false;
    }
    if(this.addSinisterNatureForm.value.transactionEnabled==null){
      this.addSinisterNatureForm.value.transactionEnabled =false;
    }
    if(this.addSinisterNatureForm.value.thirdPartyEnabled==null){
      this.addSinisterNatureForm.value.thirdPartyEnabled =false;
    }
    if(this.addSinisterNatureForm.value.victimEnabled==null){
      this.addSinisterNatureForm.value.victimEnabled =false;
    }
    if(this.addSinisterNatureForm.value.respEnabled==null){
      this.addSinisterNatureForm.value.respEnabled =false;
    }
    if(this.addSinisterNatureForm.value.respAutoEnabled==null){
      this.addSinisterNatureForm.value.respAutoEnabled =false;
    }
    if(this.addSinisterNatureForm.value.affaireEnabled==null){
      this.addSinisterNatureForm.value.affaireEnabled =false;
    }
    if(this.addSinisterNatureForm.value.expertiseEnabled==null){
      this.addSinisterNatureForm.value.expertiseEnabled =false;
    }
    if(this.addSinisterNatureForm.value.evalInterneEnabled==null){
      this.addSinisterNatureForm.value.evalInterneEnabled =false;
    }
    if(this.addSinisterNatureForm.value.evalInterneCorpEnabled==null){
      this.addSinisterNatureForm.value.evalInterneCorpEnabled =false;
    }
    if(this.addSinisterNatureForm.value.regExpertEnabled==null){
      this.addSinisterNatureForm.value.regExpertEnabled =false;
    }
    this.sinisterNatureService.addSinisterNature(this.addSinisterNatureForm.value).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['apps/sinisterNature/list'])
    })
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new sinister nature!",
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
