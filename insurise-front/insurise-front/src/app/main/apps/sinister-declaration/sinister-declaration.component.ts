import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, NgForm ,Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { SinisterDeclarationService } from './sinister-declaration.service';
import { CoreTranslationService } from '@core/services/translation.service';
import {locale as english} from "../sinister-list/i18n/en";
import {locale as french} from "../sinister-list/i18n/fr";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-sinister-declaration',
  templateUrl: './sinister-declaration.component.html',
  styleUrls: ['./sinister-declaration.component.scss']
})
export class SinisterDeclarationComponent implements OnInit {
  public contentHeader : object ; 
  constructor(private router:Router,private sinisterDeclarationservice:SinisterDeclarationService,protected fb: FormBuilder,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }

  addSinisterBinderForm = new FormGroup({
    sinisterDate:new FormControl( '' , [Validators.required] ),
    sinisterTime:new FormControl( '' , [Validators.required] ),
    sinisterPlace:new FormControl( '' , [Validators.required] ),
    policyNumber:new FormControl( '' , [Validators.required] ),
    insuredName:new FormControl( '' , [Validators.required] ),
    insuredObject:new FormControl( '' , [Validators.required] ),
    description:new FormControl( '' , [Validators.required] ),
    reclamationDate:new FormControl( '' , [Validators.required] ) 
  })

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: 'Sinister Binders',
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
                  name: 'Sinister Binders',
                  isLink: true,
                  link: '/apps/sinister-list/list'
              },
              {
                  name: 'Declare',
                  isLink: false
              }
          ]
      }
  };
  }

  declare(){
    if (this.ConfirmReclamationDate() == false ){
      this.error={isError:true,errorMessage:`Reclamation date can't be before Sinister date`};
    }else{
    this.sinisterDeclarationservice.adSinisterBinder(this.addSinisterBinderForm.value).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/SinisterBinders/all'])
    })
  }
  }

  error:any={isError:false,errorMessage:''};
  ConfirmReclamationDate():Boolean{
    var sinisterDate = (<HTMLInputElement>document.getElementById('sinisterDate')).value;
    console.log(sinisterDate)
    var reclamationDate = (<HTMLInputElement>document.getElementById('reclamationDate')).value;
    console.log(reclamationDate)
    if (sinisterDate>reclamationDate) {
      this.error={isError:true,errorMessage:''};
      return false ;
    }else{
      return true ;
    }
  }

  validerror:any={isError:false,errorMessage:''};
  ConfirmReclamationDate2():Boolean{
    var sinisterDate = (<HTMLInputElement>document.getElementById('sinisterDate')).value;
    console.log(sinisterDate)
    var sDate = new Date(sinisterDate);
    console.log(sDate.getDate())
    var reclamationDate = (<HTMLInputElement>document.getElementById('reclamationDate')).value;
    var rDate = new Date(reclamationDate);
    console.log(rDate.getDate())
    console.log(reclamationDate)
    if (sinisterDate+2<reclamationDate) {
      this.validerror={isError:true,errorMessage:''};
      return false ;
    }else{
      return true ;
    }
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully declared a new sinister!",
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
