import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { FlatpickrOptions } from 'ng2-flatpickr';
import { Nature } from '../../interfaces/nature';
import { NatureService } from '../nature.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-nature-add',
  templateUrl: './nature-add.component.html',
  styleUrls: ['./nature-add.component.scss']
})
export class NatureAddComponent implements OnInit {

  public article:Nature; 
  public contentHeader: object;
 

  public ColumnMode = ColumnMode;
  public kitchenSinkRows: Nature;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  constructor(private natureService:NatureService, private router: Router,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }
  addNatureForm = new FormGroup({
    title: new FormControl('', [
      Validators.required,
    ]),
    isList:new FormControl('')

  })

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: 'Ajouter Nature',
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
                  name: 'Nature',
                  isLink: true,
                  link: '/apps/nature/list'
              },
              {
                  name: 'List',
                  isLink: false
              }
          ]
      }
  };
  }
  onSubmit() {
    if (this.addNatureForm.valid) {
      console.log("Excecute create service", this.addNatureForm.value);
      if(this.addNatureForm.value.isList==""){
        this.addNatureForm.value.isList =false;
      }
      this.natureService.createNature(this.addNatureForm.value).subscribe({
        next: () => {
            this.ConfirmTextOpen();
            this.router.navigate(["/apps/nature/list"])
        },
        error: (err) => {
          console.log(err)
        }
      });
    }
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new nature!",
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
