import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, Keys, SelectionType } from '@swimlane/ngx-datatable';
import {
  IWarranty,
  TypeTarif,
  Warranty,
} from 'app/main/pages/interfaces/warranty';
import { WarrantyService } from '../warranty.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';
import dayjs from 'dayjs';
import { FlatpickrOptions } from 'ng2-flatpickr';
import { FeatureDto } from 'app/main/pages/interfaces/feature';
import { FeatureService } from '../../feature/feature.service';
import { ITax } from 'app/main/pages/interfaces/tax';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-warranty-add',
  templateUrl: './warranty-add.component.html',
  styleUrls: ['./warranty-add.component.scss'],
})
export class WarrantyAddComponent implements OnInit {
  public contentHeader: object;

  public taxeList: ITax[];
  public warrantyTaxeId: any;
  public taxIds: any;
  public warrantyTaxes: any[] = [];
  public featureList: FeatureDto[];
  public warrantyFeatureId: any;
  public featureIds: any;
  public warrantyFeatures: any[] = [];
  public id: number;
  public warrantyIdd: any;
  public Warranty: IWarranty;
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: Warranty;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  form: FormGroup;

  public basicDateOptions: FlatpickrOptions = {
    altInput: true,
    defaultDate: new Date(),
  };
  public basicDateFinOptions: FlatpickrOptions = {
    altInput: true,
  };

  constructor(
    private warrantyService: WarrantyService,
    private featureService: FeatureService,
    private router: Router,
    private _coreTranslationService: CoreTranslationService
  ) {
    this._coreTranslationService.translate(English, Francais);
  }

  addWarrantyForm = new FormGroup({
    title: new FormControl('', [Validators.required]),
    symbol: new FormControl(''),
    description: new FormControl(''),
    startDate: new FormControl(''),
    endDate: new FormControl(''),
    defaultPeriod: new FormControl(''),
    isCommercialRate: new FormControl(''),
    typeTarif: new FormControl(''),
  });

  ngOnInit(): void {
   
   
    this.contentHeader = {
      headerTitle: ' Warranty',
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
            name: 'Warranty',
            isLink: true,
            link: '/apps/warranty/list',
          },
          {
            name: 'Add',
            isLink: false,
          },
        ],
      },
    };

    this.basicDateOptions.defaultDate = new Date();
    this.basicDateFinOptions.defaultDate = new Date(
      Date.now() + 24 * 60 * 60 * 1000
    );
   
  }

  onSubmit() {
    if (this.compareDates() == false) {
      this.error = {
        isError: true,
       
      };
    }
    else{
    if (this.addWarrantyForm.valid) {
      console.log('Excecute create service', this.addWarrantyForm.value);
      if (this.addWarrantyForm.value.isCommercialRate == '') {
        this.addWarrantyForm.value.isCommercialRate = false;
      }
    
      this.warrantyService
        .addWarranty({
          ...this.addWarrantyForm.value,
          typeTarif: Number.parseInt(this.addWarrantyForm.value.typeTarif),
        })
        .subscribe({
          next: () => {
            this.ConfirmTextOpen();
            this.router.navigate(['/apps/warranty/list']);
          },
          error: (err) => {
            console.log(err);
          },
        });
    }
  }}
 
  error: any = { isError: false, errorMessage: '' };

  compareDates(): Boolean {
    var startDate = (<HTMLInputElement>document.getElementById('dateStart'))
      .value;

    console.log(startDate);

    var endDate = (<HTMLInputElement>document.getElementById('dateEnd')).value;

    console.log(endDate);

    if (startDate > endDate) {
      this.error = { isError: true, errorMessage: '' };

      return false;
    } else {
      return true;
    }
  }

  ConfirmTextOpen(){
    Swal.fire({
      title: 'Success!',
      text: "You have successfully added a new warranty!",
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
