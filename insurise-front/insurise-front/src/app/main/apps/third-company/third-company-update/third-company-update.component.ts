import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ThirdCompanyService } from '../third-company.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-third-company-update',
  templateUrl: './third-company-update.component.html',
  styleUrls: ['./third-company-update.component.scss']
})
export class ThirdCompanyUpdateComponent implements OnInit {

  ThirdCompany:any
  id:any
  public contentHeader : object ; 
  
  constructor(private router : Router ,private thirdCompanyService : ThirdCompanyService ,private ar: ActivatedRoute,private _coreTranslationService: CoreTranslationService) 
  { 
    this._coreTranslationService.translate(english, french);
  }


  ngOnInit(): void {
    this.id=this.ar.snapshot.params.id;
    this.thirdCompanyService.getThirdPartyCompanyById(this.id).subscribe(data=>this.ThirdCompany=data)
    this.contentHeader = {
      headerTitle: 'ThirdCompany',
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
                  name: 'ThirdCompany',
                  isLink: true,
                  link: '/apps/third-company/list'
              },
              {
                  name: 'update',
                  isLink: false
              }
          ]
      }
    };
  }

  update(thirdCompany:NgForm){
    this.thirdCompanyService.updateThirdPartyCompany(thirdCompany.value,this.id).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/third-company/list'])
    })
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully updated this third company!",
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
