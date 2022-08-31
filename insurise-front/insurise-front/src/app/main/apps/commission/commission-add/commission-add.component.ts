import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { ICommission } from 'app/main/pages/interfaces/commission';
import { CommissionService } from '../commission.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-commission-add',
  templateUrl: './commission-add.component.html',
  styleUrls: ['./commission-add.component.scss']
})
export class CommissionAddComponent implements OnInit {

  public commission :ICommission; 
  public contentHeader: object;
 

  public ColumnMode = ColumnMode;
  public kitchenSinkRows: ICommission;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  constructor(private commissionService:CommissionService, private router: Router,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }
  addCommissionForm = new FormGroup({
    value: new FormControl('', [
      Validators.required,
    ]),
  })


  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: 'Commission',
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
                  name: 'Commission',
                  isLink: true,
                  link: '/apps/commission/list'
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
    if (this.addCommissionForm.valid) {
      console.log("Excecute create service", this.addCommissionForm.value);
    
      this.commissionService.CreateCommission(this.addCommissionForm.value).subscribe({
        next: () => {
          this.ConfirmTextOpen();
            this.router.navigate(["/apps/commission/list"])
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
      text: "You have successfully added a new commission!",
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
