import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DuartionService } from '../duartion.service';
import {locale as english} from "../i18n/en";
import {locale as french} from "../i18n/fr";
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-duartion-add',
  templateUrl: './duartion-add.component.html',
  styleUrls: ['./duartion-add.component.scss']
})
export class DuartionAddComponent implements OnInit {

  typesList=[
    {"id":1,"title":"Variable"},
    {"id":2,"title":"Fixe"}
  ]
  
  StartDate : any 
  public contentHeader : object ; 

  constructor(private router : Router , private durationService : DuartionService,private _coreTranslationService: CoreTranslationService)
  {
    this._coreTranslationService.translate(english, french);
  }

  addDurationForm = new FormGroup({
    title:new FormControl( '' , [Validators.required] ),
    type:new FormControl( '' , [Validators.required] ),
    value:new FormControl( '' , [Validators.required]),
    coefficient:new FormControl( '' , [Validators.required] ),
    startDate:new FormControl( '' , [Validators.required] ),
    endDate:new FormControl(),
    renewable:new FormControl(),
  })

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: 'Duration',
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
                  name: 'Duration',
                  isLink: true,
                  link: '/apps/duration/list'
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
    if(this.addDurationForm.value.renewable==null){
      this.addDurationForm.value.renewable =false;
    }
    if (this.compareDates() == false ){
      this.error={isError:true,errorMessage:`End Date can't be before Start date`};
    }else{
    this.durationService.addDuration(this.addDurationForm.value).subscribe(()=>{
      this.ConfirmTextOpen();
      this.router.navigate(['/apps/duration/list'])
    })
  }
  }

  error:any={isError:false,errorMessage:''};
  compareDates():Boolean{
    var startDate = (<HTMLInputElement>document.getElementById('startDate')).value;
    console.log(startDate)
    var endDate = (<HTMLInputElement>document.getElementById('endDate')).value;
    console.log(endDate)
    if (startDate>endDate) {
      this.error={isError:true,errorMessage:''};
      return false ;
    }else{
      return true ;
    }
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new duration!",
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
