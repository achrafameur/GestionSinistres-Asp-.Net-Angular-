import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ThirdPartyService } from '../third-party.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-third-party-add',
  templateUrl: './third-party-add.component.html',
  styleUrls: ['./third-party-add.component.scss']
})
export class ThirdPartyAddComponent implements OnInit {
  
  thirdPartyCompaniesList : any 
  public contentHeader : object ; 
  

  constructor(private router : Router , private thirdPartyService: ThirdPartyService,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  addThirdPartyForm = new FormGroup({
    title:new FormControl( '' , [Validators.required] ),
    label:new FormControl( '' , [Validators.required] ),
    description:new FormControl( '' , [Validators.required] ),
    taxRegistrationNumber:new FormControl( '' , [Validators.required] ),
    phone:new FormControl( '' , [Validators.required] ),
    fax:new FormControl( '' , [Validators.required] ),
    email:new FormControl( '' , [Validators.required] ),
    tiersCompanyId:new FormControl( '' , [Validators.required] )
  })

  ngOnInit(): void {
    this.thirdPartyService.getThirdPartyCompanies().subscribe((data)=>{
      this.thirdPartyCompaniesList=data
    })
    this.contentHeader = {
      headerTitle: 'ThirdParty',
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
                  name: 'ThirdParty',
                  isLink: true,
                  link: '/apps/third-party/list'
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
    if(this.confirmSubmit() == false){
      this.Error={isError:true,errorMessage:`This field must contain a valid phone number`};
      this.TError={isError:true,errorMessage:``};
    }else if (this.confirmTaxSubmit() == false ){
      this.TError={isError:true,errorMessage:`This field must contain a valid tax number`};
      this.Error={isError:true,errorMessage:``};
    }else{
      this.thirdPartyService.addThirdParty(this.addThirdPartyForm.value).subscribe(()=>{
        this.ConfirmTextOpen();
        this.router.navigate(['/apps/third-party/list'])
      })
    }
  }

  Error:any={isError:false,errorMessage:''};
  confirmSubmit():Boolean{
    var phoneInputLength = (<HTMLInputElement>document.getElementById('phone')).value.length;
    console.log(phoneInputLength)
    if (phoneInputLength !== 8) {
      this.Error={isError:true,errorMessage:''};
      return false ;
    }else{
      return true ;
    }
  }
  TError:any={isError:false,errorMessage:''};
  confirmTaxSubmit():Boolean{
    var taxInputLength = (<HTMLInputElement>document.getElementById('tax')).value.length;
    console.log(taxInputLength)
    if (taxInputLength !== 8) {
      this.TError={isError:true,errorMessage:''};
      return false ;
    }else{
      return true ;
    }
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new third party!",
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
