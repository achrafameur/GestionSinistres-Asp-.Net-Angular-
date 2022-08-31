import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import { IClient } from 'app/main/pages/interfaces/client';
import { IQuotation } from 'app/main/pages/interfaces/quotation';
import { IShop } from 'app/main/pages/interfaces/shop';
import { QuotationService } from '../quotation.service';
import Swal from 'sweetalert2';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';


@Component({
  selector: 'app-quotation-add',
  templateUrl: './quotation-add.component.html',
  styleUrls: ['./quotation-add.component.scss']
})
export class QuotationAddComponent implements OnInit {
  public contentHeader: object;

  public quotation: IQuotation;
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: IQuotation;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  form: FormGroup;
  shopList: IShop[];
  clientList :IClient[];
 
  
  constructor( private quotationService: QuotationService,
    private router: Router,
    private _coreTranslationService: CoreTranslationService) {
      this._coreTranslationService.translate(English,Francais);
     }

    addQuotationForm = new FormGroup({
      shopId: new FormControl(''),
      clientId: new FormControl('')});


      addClientForm = new FormGroup({
       
        idCard: new FormControl('', [Validators.required]), 
        firstName: new FormControl(''),
        lastName: new FormControl(''),
        birthDate: new FormControl(''), 
        gender: new FormControl(''), 
        phoneNumber: new FormControl(''), 
        mail: new FormControl('')});
  

  ngOnInit(): void {
    this.quotationService.loadShops().subscribe((data)=>{
      this.shopList = data
    })
    this.contentHeader = {
      headerTitle: ' Quotation',
      actionButton: false,
      breadcrumb: {
        type: '',
        links: [
          {
            name: 'Home',
            isLink: true,
            link: '/',
          },
          {
            name: 'Quotation',
            isLink: true,
            link: '/apps/quotation/list',
          },
          {
            name: 'Add',
            isLink: false,
          },
        ],
      },
    };
  }
  onSubmit() {
    if (this.addClientForm.valid) {
      console.log('Excecute create service', this.addClientForm.value);
      this.quotationService
      .addClient({
        ...this.addClientForm.value,
        gender : Number.parseInt(this.addClientForm.value.gender),
      }
      ).subscribe({
        next: (data) => {
          console.log(this.addClientForm.value);
          if (this.addQuotationForm.valid){
        this.quotationService.addQuotation({...this.addQuotationForm.value,
          shopId: Number.parseInt(this.addQuotationForm.value.shopId),
          clientId : this.addClientForm.value.clientId
        }).subscribe({
          next: () => {
            this.ConfirmTextOpen();
              this.router.navigate(["/apps/quotation/list"])
          },
          error: (err) => {
            console.log(err)
          }
        })}}
      });

      
    }}
    onSubmit1(){
      this.quotationService.loadClients
    }
    ConfirmTextOpen(){
      Swal.fire({
        title: 'Success!',
        text: "You have successfully added a new quotation!",
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
