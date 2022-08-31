import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CoreTranslationService } from '@core/services/translation.service';
import { ColumnMode, SelectionType } from '@swimlane/ngx-datatable';
import Swal from 'sweetalert2';
import { Autoplay } from 'swiper';
import { ChainDto } from '../../interfaces/chain';
import { ChainService } from '../chain.service';
import { locale as English } from '../i18n/en';
import { locale as Francais } from '../i18n/fr';

@Component({
  selector: 'app-chain-add',
  templateUrl: './chain-add.component.html',
  styleUrls: ['./chain-add.component.scss']
})
export class ChainAddComponent implements OnInit {
  public contentHeader: object;
  public article:ChainDto; 
  public ColumnMode = ColumnMode;
  public kitchenSinkRows: ChainDto;
  public basicSelectedOption: number = 10;
  public SelectionType = SelectionType;
  public rows: any;
public selected = [];

public selectedOption = 10;

readonly headerHeight = 50;
readonly rowHeight = Autoplay;
readonly pageLimit = 10;
readonly footerHeight = 50;
Elements :string[]=[]

  constructor(private chainService:ChainService, private router:Router,private fb:FormBuilder,private _coreTranslationService: CoreTranslationService ) {
    this._coreTranslationService.translate(English,Francais);
   }
  addChainForm =this.fb.group({
    title : this.fb.control('', [
      Validators.required]),
      elements:this.fb.array([]),
  });
   
   
  get elements(){
    return this.addChainForm.controls["elements"] as FormArray;
  }

addElement(){
  const elementForm = this.fb.group({
    title:['',Validators.required]
  });
  this.elements.push(elementForm);
}

deleteElement(elementIndex:number){
  this.elements.removeAt(elementIndex);
}

  ngOnInit(): void {
    this.contentHeader = {
      headerTitle: ' Chain',
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
                  name: 'Chain',
                  isLink: true,
                  link: '/apps/chain/list'
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
    if (this.addChainForm.valid) {
      console.log("Excecute create service", this.addChainForm.value);
      this.chainService.addChain(this.addChainForm.value).subscribe({
        next: () => {
            this.ConfirmTextOpen();
            this.router.navigate(["/apps/chain/list"])
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
      text: "You have successfully added a new chain!",
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

