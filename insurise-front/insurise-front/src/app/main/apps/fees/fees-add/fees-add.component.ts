import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { DuartionService } from '../../duration/duartion.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { FeesService } from '../fees.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-fees-add',
  templateUrl: './fees-add.component.html',
  styleUrls: ['./fees-add.component.scss']
})
export class FeesAddComponent implements OnInit {
  typesList=[
    {"id":1,"title":"Fond"},
    {"id":2,"title":"Frais"}
  ]
  public contentHeader : object ;
  constructor(private router : Router ,private feesService : FeesService,private _coreTranslationService: CoreTranslationService) {
    this._coreTranslationService.translate(english, french);
  }

  
  addFeeForm = new FormGroup({
    title:new FormControl( '' , [Validators.required] ),
    symbol:new FormControl( '' , [Validators.required]),
    description:new FormControl( '' , [Validators.required] ),
    equation:new FormControl( '' , [Validators.required] ),
    type:new FormControl( '' , [Validators.required] ),
  })

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: 'Fee',
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
                  name: 'Fee',
                  isLink: true,
                  link: '/apps/fees/list'
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
    this.feesService.addFee(this.addFeeForm.value).subscribe(()=>{
        this.ConfirmTextOpen();
        this.router.navigate(['/apps/fees/list'])
    })
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new fee!",
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
