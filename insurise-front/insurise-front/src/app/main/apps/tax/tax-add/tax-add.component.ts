import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TaxService } from '../tax.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tax-add',
  templateUrl: './tax-add.component.html',
  styleUrls: ['./tax-add.component.scss']
})
export class TaxAddComponent implements OnInit {

  Products:any
  Warranties : any 
  public contentHeader : object ;
  constructor(private router : Router ,private taxService : TaxService,private _coreTranslationService: CoreTranslationService)
  {
    this._coreTranslationService.translate(english, french);
  }

  
  addTaxForm = new FormGroup({
    title:new FormControl( '' , [Validators.required] ),
    description:new FormControl( '' , [Validators.required] ),
    coefficient:new FormControl( '' , [Validators.required] ),
    constant:new FormControl( '' , [Validators.required] ),
  })

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: 'Tax',
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
                  name: 'Tax',
                  isLink: true,
                  link: '/apps/tax/list'
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
    this.taxService.addTax(this.addTaxForm.value).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/tax/list'])
    })
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new tax!",
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
