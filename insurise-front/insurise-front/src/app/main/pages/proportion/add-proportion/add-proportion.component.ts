import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { Proportion } from '../../interfaces/proportion';
import { ProportionService } from '../proportion.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
import { CoreTranslationService } from '@core/services/translation.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-proportion',
  templateUrl: './add-proportion.component.html',
  styleUrls: ['./add-proportion.component.scss']
})
export class AddProportionComponent implements OnInit {
  public contentHeader: object;
  public proportion:Proportion; 
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: Proportion;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  constructor(private proportionService : ProportionService,private router: Router,private _coreTranslationService: CoreTranslationService) {
    this._coreTranslationService.translate(English,Francais);
   }

  addProportionForm = new FormGroup({
    title: new FormControl('', [
      Validators.required,]),
    occurence: new FormControl('',[
      Validators.required,]),
    additionalCosts: new FormControl('',[
      Validators.required,]),
  })
  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: ' Proportion',
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
                  name: 'Proportion',
                  isLink: true,
                  link: '/apps/proportion/list'
              },
              {
                  name: 'Add',
                  isLink: false
              }
          ]
      }
  };
   
  }
  onSubmit() {
    if (this.addProportionForm.valid) {
      console.log("Excecute create service", this.addProportionForm.value);
      this.proportionService.createProportion(this.addProportionForm.value).subscribe({
        next: () => {
            this.ConfirmTextOpen();
            this.router.navigate(["/apps/proportion/list"])
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
      text: "You have successfully added a new proportion!",
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
