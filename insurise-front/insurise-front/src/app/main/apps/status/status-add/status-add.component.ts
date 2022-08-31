import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { StatusService } from '../status.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import Swal from 'sweetalert2';

@Component({
  selector: 'app-status-add',
  templateUrl: './status-add.component.html',
  styleUrls: ['./status-add.component.scss']
})
export class StatusAddComponent implements OnInit {

  itemList : any 
  public contentHeader : object ; 

  constructor(private router : Router , private statusService: StatusService,private _coreTranslationService: CoreTranslationService)
  { 
    this._coreTranslationService.translate(english, french);
  }

  addStatusForm = new FormGroup({
    title:new FormControl( '' , [Validators.required] ),
    symbol:new FormControl( '' , [Validators.required] ),
    itemId:new FormControl( '' , [Validators.required]),
  })

  ngOnInit(): void {
    this.statusService.getItems().subscribe((data)=>{
      this.itemList=data
    })

    this.contentHeader = {
      headerTitle: 'Status',
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
                  name: 'Status',
                  isLink: true,
                  link: '/apps/status/list'
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
    this.statusService.addStatus(this.addStatusForm.value).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/status/list'])
    })
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new status!",
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
